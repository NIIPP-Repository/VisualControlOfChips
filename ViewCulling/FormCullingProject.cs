using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NIIPP.ComputerVision;

namespace ViewCulling
{
    public partial class FormCullingProject : Form
    {
        private string _currResume = Resume.None;
        private string CurrResume
        {
            get { return _currResume; }
            set
            {
                lblCurrentResume.Text = value;
                _currResume = value;
            }
        }

        private readonly List<string> _pathToGoodChips = new List<string>();
        private readonly List<Bitmap> _images = new List<Bitmap>();
        private readonly List<Color> _backgroundColors = new List<Color>();
        private readonly List<Point> _keyPoints = new List<Point>();
        private Bitmap _currImage;

        private Point _offset = new Point(0, 0);

        private const int WidthOfLine = 2;

        private struct Resume
        {
            public const string Cutting = "Cutting";
            public const string Segmentation = "Segmentation";
            public const string ChooseKeyPoints = "ChooseKeyPoints";
            public const string None = "None";
        }

        public FormCullingProject()
        {
            InitializeComponent();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetDimensionsOfPositionTrackBars(Bitmap bmp)
        {
            trbLeftPosition.Maximum = bmp.Width / 2;
            trbRightPosition.Maximum = bmp.Width / 2;
            trbUpPosition.Maximum = bmp.Height / 2;
            trbDownPosition.Maximum = bmp.Height / 2;
        }

        private Bitmap DrawFrames(Bitmap bmp, int offsetRight, int offsetLeft, int offsetUp, int offsetDown)
        {
            Bitmap temp = (Bitmap) bmp.Clone();
            Graphics g = Graphics.FromImage(temp);
            Pen pen = new Pen(Brushes.OrangeRed, WidthOfLine);

            if (offsetRight > 0)
                g.DrawLine(pen, bmp.Width - offsetRight, bmp.Height - 1, bmp.Width - offsetRight, 1);
            if (offsetLeft > 0)
                g.DrawLine(pen, offsetLeft, bmp.Height - 1, offsetLeft, 1);
            if (offsetUp > 0)
                g.DrawLine(pen, 1, offsetUp, bmp.Width - 1, offsetUp);
            if (offsetDown > 0)
                g.DrawLine(pen, 1, bmp.Height - offsetDown, bmp.Width - 1, bmp.Height - offsetDown);

            return temp;
        }

        private void DrawFrame()
        {
            pbGoodChipImage.Image = DrawFrames(_currImage, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);
            GC.Collect();
        }

        private void trbLeftPosition_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Cutting)
            {
                DrawFrame();
            }

            RefreshCuttingLabels();
        }

        private void trbRightPosition_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Cutting)
            {
                DrawFrame();
            }

            RefreshCuttingLabels();
        }

        private void trbUpPosition_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Cutting)
            {
                DrawFrame();
            }

            RefreshCuttingLabels();
        }

        private void trbDownPosition_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Cutting)
            {
                DrawFrame();
            }

            RefreshCuttingLabels();
        }

        private void RefreshSegmentationLabels()
        {
            lblRComp.Text = trbRComp.Value.ToString();
            lblGComp.Text = trbGComp.Value.ToString();
            lblBComp.Text = trbBComp.Value.ToString();
            lblLimit.Text = trbToleranceLimit.Value.ToString();
        }

        private void FillColorIndicator()
        {
            pbBackgroundColor.BackColor = Color.FromArgb(trbRComp.Value, trbGComp.Value, trbBComp.Value);
        }

        private void FormAddNewProject_Load(object sender, EventArgs e)
        {
            gbSamplesOfGoodChips.Width = (Width - panelRightSide.Width) - Width / 25;
            gbSamplesOfGoodChips.Height = (Height - panelDownSide.Height) - Height / 10;

            RefreshSegmentationLabels();
            RefreshCuttingLabels();
            FillColorIndicator();
        }

        private void SegmentationWithCurrentParameters()
        {
            Segmentation segmentation = new Segmentation(GetCorrectedPoints(), trbToleranceLimit.Value);
            pbGoodChipImage.Image = segmentation.GetSegmentedPicture(_currImage);
        }

        private void SegmentationWithEdgeDetection()
        {
            Segmentation segmentation = new Segmentation(GetCorrectedPoints(), trbToleranceLimit.Value);
            Bitmap res = segmentation.GetSegmentedPicture(_currImage);
            EdgeFinder edgeFinder = new EdgeFinder(res);
            res = edgeFinder.GetEdgePic();

            pbGoodChipImage.Image = res;
        }

        private void trbRComp_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Segmentation)
                SegmentationWithCurrentParameters();
            RefreshSegmentationLabels();
            FillColorIndicator();
        }

        private void trbGComp_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Segmentation)
                SegmentationWithCurrentParameters();
            RefreshSegmentationLabels();
            FillColorIndicator();
        }

        private void trbBComp_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Segmentation)
                SegmentationWithCurrentParameters();
            RefreshSegmentationLabels();
            FillColorIndicator();
        }

        private void trbToleranceLimit_Scroll(object sender, EventArgs e)
        {
            if (CurrResume == Resume.Segmentation)
                SegmentationWithCurrentParameters();
            RefreshSegmentationLabels();
        }

        private Bitmap CutBitmapImage(Bitmap bmp, int left, int right, int up, int down)
        {
            Rectangle rect = new Rectangle(left, up, bmp.Width - (left + right), bmp.Height - (up + down));
            return bmp.Clone(rect, bmp.PixelFormat);
        }

        private Bitmap CutBitmapImage(Bitmap bmp, Point offset, int width, int height)
        {
            Rectangle rect = new Rectangle(offset.X, offset.Y, width, height);
            return bmp.Clone(rect, bmp.PixelFormat);
        }

        private List<Point> GetCorrectedPoints()
        {
            return _keyPoints.Select(point => new Point(point.X - _offset.X, point.Y - _offset.Y)).ToList();
        }

        private void обрезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrResume != Resume.Cutting)
                return;

            // сохраняем отступ по которому будет обрезание изображения
            _offset.X += trbLeftPosition.Value;
            _offset.Y += trbUpPosition.Value;

            // определяем позицию текущего изображения на форме
            int pos = _images.IndexOf(_currImage);

            // обрезаем изображение на форме
            _images[pos] = CutBitmapImage(_images[pos], trbLeftPosition.Value, trbRightPosition.Value, trbUpPosition.Value, trbDownPosition.Value);

            Segmentation segmentationOrigin = new Segmentation(GetCorrectedPoints(), trbToleranceLimit.Value);
            byte[,,] originMas = segmentationOrigin.GetSegmentedMass(_images[pos]);

            SuperImposition superImposition = new SuperImposition(originMas);
            Segmentation segmentation = new Segmentation(_keyPoints, trbToleranceLimit.Value);
            for (int i = 0; i < _images.Count; i++)
            {
                if (i == pos)
                    continue;

                byte[, ,] currMas = segmentation.GetSegmentedMass(_images[i]);
                Point offset = superImposition.FindBestImposition(currMas, new Point(trbLeftPosition.Value, trbUpPosition.Value));
                _images[i] = CutBitmapImage(_images[i], offset, _images[pos].Width, _images[pos].Height);
            }

            _currImage = _images[pos];
            pbGoodChipImage.Image = _currImage;

            // сбрасываем показания контролов
            trbRightPosition.Value = 0;
            trbLeftPosition.Value = 0;
            trbUpPosition.Value = 0;
            trbDownPosition.Value = 0;
            RefreshCuttingLabels();
            SetDimensionsOfPositionTrackBars(_currImage);
        }

        private void RefreshCuttingLabels()
        {
            lblRightOffset.Text = String.Format("{0} px", trbRightPosition.Value);
            lblLeftOffset.Text = String.Format("{0} px", trbLeftPosition.Value);
            lblUpOffset.Text = String.Format("{0} px", trbUpPosition.Value);
            lblDownOffset.Text = String.Format("{0} px", trbDownPosition.Value);
        }

        private void сегментироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SegmentationWithCurrentParameters();
        }

        private void показатьОригиналToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbGoodChipImage.Image = _currImage;
            SetTsmiChecked(sender);
        }

        private void выборОбластиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CurrResume = Resume.Cutting;
            pbGoodChipImage.Image = DrawFrames(_currImage, trbRightPosition.Value, trbLeftPosition.Value, trbUpPosition.Value, trbDownPosition.Value);
            GC.Collect();

            SetTsmiChecked(sender);
        }

        private void сегментацияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CurrResume = Resume.Segmentation;
            SegmentationWithCurrentParameters();

            SetTsmiChecked(sender);
        }

        private void SetTsmiChecked(object sender)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;

            foreach (var next in tsmi.GetCurrentParent().Items)
            {
                ((ToolStripMenuItem) next).Checked = false;
            }
            tsmi.Checked = true;
        }

        private void выборЦветаФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrResume = Resume.ChooseKeyPoints;
            pbGoodChipImage.Image = Utils.DrawKeyPointsOnImage(_currImage, GetCorrectedPoints(), true);

            SetTsmiChecked(sender);
        }

        private void нетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrResume = Resume.None;
            pbGoodChipImage.Image = _currImage;

            SetTsmiChecked(sender);
        }

        private void показатьСегментациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SegmentationWithCurrentParameters();
            SetTsmiChecked(sender);
        }

        private void добавитьИзображениеГодногоЧипаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGoodChipImage();
        }

        private void CreateUnion()
        {
            Bitmap res = Utils.UnionOfImages(GetCorrectedPoints(), trbToleranceLimit.Value, _images);

            FormShowPicture formShowPicture = new FormShowPicture {TopLevel = false};
            FormMain.Instance.Controls.Add(formShowPicture);
            formShowPicture.Show();
            formShowPicture.SetImage(res);
        }

        private void CreateUnionAndEdge()
        {
            Bitmap res = Utils.UnionOfImages(GetCorrectedPoints(), trbToleranceLimit.Value, _images);

            EdgeFinder edgeFinder = new EdgeFinder(res);
            res = edgeFinder.GetEdgePic();

            FormShowPicture formShowPicture = new FormShowPicture {TopLevel = false};
            FormMain.Instance.Controls.Add(formShowPicture);
            formShowPicture.Show();
            formShowPicture.SetImage(res);
        }

        private void LoadGoodChipImage()
        {
            OpenFileDialog ofd = new OpenFileDialog {Multiselect = true};
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbGoodChipImage.SizeMode = PictureBoxSizeMode.StretchImage;

                foreach (string path in ofd.FileNames)
                {
                    AddImage(path);
                }
                lblPosition.Text = String.Format("{0} из {1}", _images.IndexOf(_currImage) + 1, _images.Count);
                lblNameOfFile.Text = Path.GetFileName(_pathToGoodChips[_images.IndexOf(_currImage)]);
                pbGoodChipImage.Image = _currImage;
                SetDimensionsOfPositionTrackBars(_currImage);
            }
        }

        private void AddImage(string path)
        {
            _pathToGoodChips.Add(path);
            _currImage = new Bitmap(path);
            _images.Add(_currImage);
        }

        private void ChooseBackground(MouseEventArgs e)
        {
            double xZoom = ((double)(e.X) / pbGoodChipImage.Width);
            double yZoom = ((double)(e.Y) / pbGoodChipImage.Height);
            int x = (int)(xZoom * _currImage.Width);
            int y = (int)(yZoom * _currImage.Height);

            y = (y >= _currImage.Height) ? _currImage.Height - 1 : y;
            x = (x >= _currImage.Width) ? _currImage.Width - 1 : x;

            _backgroundColors.Add(_currImage.GetPixel(x, y));
            _keyPoints.Add(new Point(x, y));

            double r = 0, g = 0, b = 0;
            foreach (Color col in _backgroundColors)
            {
                r += col.R;
                g += col.G;
                b += col.B;
            }
            r /= _backgroundColors.Count;
            g /= _backgroundColors.Count;
            b /= _backgroundColors.Count;

            trbRComp.Value = (int)r;
            trbGComp.Value = (int)g;
            trbBComp.Value = (int)b;

            RefreshSegmentationLabels();
            FillColorIndicator();
        }

        private void pbRightArrow_Click(object sender, EventArgs e)
        {
            int pos = _images.IndexOf(_currImage);
            if (pos < _images.Count - 1)
            {
                pos++;
            }
            else
            {
                pos = 0;
            }
            
            _currImage = _images[pos];
            pbGoodChipImage.Image = _currImage;

            lblPosition.Text = String.Format("{0} из {1}", pos + 1, _images.Count);
            lblNameOfFile.Text = Path.GetFileName(_pathToGoodChips[pos]);

            if (CurrResume == Resume.Segmentation)
                SegmentationWithCurrentParameters();
            if (CurrResume == Resume.Cutting)
                DrawFrame();
            if (CurrResume == Resume.ChooseKeyPoints)
                pbGoodChipImage.Image = Utils.DrawKeyPointsOnImage((Bitmap) pbGoodChipImage.Image, GetCorrectedPoints(), true);
        }

        private void pbLeftArrow_Click(object sender, EventArgs e)
        {
            int pos = _images.IndexOf(_currImage);
            if (pos > 0)
            {
                pos--;
            }
            else
            {
                pos = _images.Count - 1;
            }

            _currImage = _images[pos];
            pbGoodChipImage.Image = _currImage;

            lblPosition.Text = String.Format("{0} из {1}", pos + 1, _images.Count);
            lblNameOfFile.Text = Path.GetFileName(_pathToGoodChips[pos]);

            if (CurrResume == Resume.Segmentation)
                SegmentationWithCurrentParameters();
            if (CurrResume == Resume.Cutting)
                DrawFrame();
            if (CurrResume == Resume.ChooseKeyPoints)
                pbGoodChipImage.Image = Utils.DrawKeyPointsOnImage((Bitmap)pbGoodChipImage.Image, GetCorrectedPoints(), true);
        }

        private void создатьОбъединениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUnion();
        }

        private void объединениеКраяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUnionAndEdge();
        }

        private void показатьКраяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SegmentationWithEdgeDetection();
            SetTsmiChecked(sender);
        }

        private void pbGoodChipImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (_currResume == Resume.None)
            {
                LoadGoodChipImage();
            }

            if (CurrResume == Resume.ChooseKeyPoints)
            {
                ChooseBackground(e);
                pbGoodChipImage.Image = Utils.DrawKeyPointsOnImage( (Bitmap) pbGoodChipImage.Image, GetCorrectedPoints(), false);
            }
        }

        private void очиститьТекущийНаборToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _backgroundColors.Clear();
            _keyPoints.Clear();

            trbRComp.Value = 0;
            trbGComp.Value = 0;
            trbBComp.Value = 0;

            RefreshSegmentationLabels();
            FillColorIndicator();

            pbGoodChipImage.Image = _currImage;
        }

        private void сохранитьПроектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap res = Utils.UnionOfImages(GetCorrectedPoints(), trbToleranceLimit.Value, _images);
            byte[,,] union = Utils.BitmapToByteRgb(res);

            CullingProject cullingProject = new CullingProject(tbNameOfProject.Text, rtbDescription.Text, union, _keyPoints, _offset, trbToleranceLimit.Value);
            cullingProject.SaveObject();
        }

        private void удалитьПоследнююТочкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _keyPoints.RemoveAt(_keyPoints.Count - 1);

            pbGoodChipImage.Image = Utils.DrawKeyPointsOnImage(_currImage, _keyPoints, false);
        }

    }
}
