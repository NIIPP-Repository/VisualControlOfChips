using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NIIPP.ComputerVision;

namespace ViewCulling
{
    public partial class FormAnalyzeView : Form
    {
        public static FormAnalyzeView Instance { get; private set; }

        private string _pathToSpritePic;
        private string _pathToOriginalPic;
        private CullingProject _cullingProject;
        private string _nameOfFile;
        private int _pos;
        private int _countOfRows;

        public FormAnalyzeView()
        {
            InitializeComponent();
            Instance = this;
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private Bitmap GetOriginal()
        {
            return new Bitmap(_pathToOriginalPic);
        }

        private Bitmap GetSegmentation()
        {
            Bitmap innerPic = new Bitmap(_pathToOriginalPic);
            Segmentation segmentation = new Segmentation(_cullingProject.KeyPoints, _cullingProject.Lim);
            Bitmap res = segmentation.GetSegmentedPicture(innerPic);
            return res;
        }

        private Bitmap GetSpriteImage()
        {
            return new Bitmap(_pathToSpritePic);
        }

        private Bitmap GetKeyPointsImage()
        {
            return Utils.DrawKeyPointsOnImage(new Bitmap(_pathToOriginalPic), _cullingProject.KeyPoints, true);
        }

        private Bitmap GetEdgeImage()
        {
            Bitmap innerPic = new Bitmap(_pathToOriginalPic);
            Segmentation segmentation = new Segmentation(_cullingProject.KeyPoints, _cullingProject.Lim);
            Bitmap res = segmentation.GetSegmentedPicture(innerPic);
            EdgeFinder edgeFinder = new EdgeFinder(res);
            return edgeFinder.GetEdgePic();
        }

        private Bitmap GetPatternImage()
        {
            return Utils.ByteToBitmapRgb(_cullingProject.UnitedImage);
        }

        private void SetCurrResumeImage()
        {
            if (оригиналToolStripMenuItem.Checked)
                pbViewPicture.Image = GetOriginal();
            if (сегментацияToolStripMenuItem.Checked)
                pbViewPicture.Image = GetSegmentation();
            if (спрайтыToolStripMenuItem.Checked)
                pbViewPicture.Image = GetSpriteImage();
            if (ключевыеТочкиToolStripMenuItem.Checked)
                pbViewPicture.Image = GetKeyPointsImage();
            if (краяToolStripMenuItem.Checked)
                pbViewPicture.Image = GetEdgeImage();
            if (шаблонToolStripMenuItem.Checked)
                pbViewPicture.Image = GetPatternImage();
        }

        public void LoadMainData(CullingProject cullingProject, int countOfRows)
        {
            _countOfRows = countOfRows;
            _cullingProject = cullingProject;

            pbPosition.Maximum = countOfRows;
        }

        public void LoadData(string nameOfFile, string pathSpritePic, string pathToOriginalPic, string coeff, int pos)
        {
            _nameOfFile = nameOfFile;
            _pathToOriginalPic = pathToOriginalPic;
            _pathToSpritePic = pathSpritePic;
            _pos = pos;

            lblCoeff.Text = coeff;
            lblNameOfChip.Text = Path.GetFileNameWithoutExtension(nameOfFile);
            lblCurrPos.Text = String.Format("{0} из {1}", _pos + 1, _countOfRows);
            pbPosition.Value = _pos;

            SetCurrResumeImage();
        }

        public void SetStatus(string verdict)
        {
            if (verdict == Verdict.Good.Name)
                rbGood.Checked = true;
            else
                if (verdict == Verdict.Bad.Name)
                    rbBad.Checked = true;
        }

        private void pbViewPicture_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            pbViewPicture.Image.Save("\\tempPic.bmp");
            Process.Start("\\tempPic.bmp");
        }

        private void сегментацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTsmiChecked(sender);
            SetCurrResumeImage();
        }

        private void оригиналToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTsmiChecked(sender);
            SetCurrResumeImage();
        }

        private void SetTsmiChecked(object sender)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;

            foreach (var next in tsmi.GetCurrentParent().Items)
            {
                ((ToolStripMenuItem)next).Checked = false;
            }
            tsmi.Checked = true;
        }

        private void спрайтыToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            SetTsmiChecked(sender);
            SetCurrResumeImage();
        }

        private void SetVerdictStatus()
        {
            if (rbGood.Checked)
            {
                pbStatus.Image = new Bitmap("assets\\good.png");
                gbImage.BackColor = Color.GreenYellow;
            }
            if (rbBad.Checked)
            {
                pbStatus.Image = new Bitmap("assets\\bad.png");
                gbImage.BackColor = Color.LightSalmon;
            }
            FormAnalyze.Instance.SetUserCorrectedStatus(_nameOfFile, rbGood.Checked ? Verdict.Good : Verdict.Bad);
        }

        private void rbGood_CheckedChanged(object sender, EventArgs e)
        {
            SetVerdictStatus();
        }

        private void rbBad_CheckedChanged(object sender, EventArgs e)
        {
            SetVerdictStatus();
        }

        private void ключевыеТочкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTsmiChecked(sender);
            SetCurrResumeImage();
        }

        private void краяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTsmiChecked(sender);
            SetCurrResumeImage();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog {FileName = "save.bmp", Filter = "Image (*.bmp)|*.bmp"};
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pbViewPicture.Image.Save(sfd.FileName);
            }
        }

        private void шаблонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTsmiChecked(sender);
            SetCurrResumeImage();
        }

        private string CurrFilter()
        {
            string filter = "";
            if (rbShowBads.Checked)
                filter = Verdict.Bad.Name;
            if (rbShowGoods.Checked)
                filter = Verdict.Good.Name;
            if (rbShowAll.Checked)
                filter = "";

            return filter;
        }

        private void pbLeftArrow_Click(object sender, EventArgs e)
        {
            FormAnalyze.Instance.SendDataToShow(_pos, false, CurrFilter());
        }

        private void pbRightArrow_Click(object sender, EventArgs e)
        {
            FormAnalyze.Instance.SendDataToShow(_pos, true, CurrFilter());
        }

        private void FormAnalyzeView_Load(object sender, EventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int wmKeydown = 0x100;
            const int wmSyskeydown = 0x104;

            if ((msg.Msg == wmKeydown) || (msg.Msg == wmSyskeydown))
            {
                switch (keyData)
                {
                    case Keys.OemOpenBrackets:
                        FormAnalyze.Instance.SendDataToShow(_pos, false, CurrFilter());
                        break;
                    case Keys.OemCloseBrackets:
                        FormAnalyze.Instance.SendDataToShow(_pos, true, CurrFilter());
                        break;
                    case Keys.G:
                        rbGood.Checked = true;
                        break;
                    case Keys.B:
                        rbBad.Checked = true;
                        break;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
