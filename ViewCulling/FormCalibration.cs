using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NIIPP.ComputerVision;

namespace ViewCulling
{
    public partial class FormCalibration : Form
    {
        private readonly List<Bitmap> _images = new List<Bitmap>();
        private List<string> _pathes = new List<string>();

        private List<Point> _keyPoints;
        private int _currIndex;

        public FormCalibration()
        {
            InitializeComponent();
        }

        public void LoadInfo(List<String> pathesToFiles, int lim, List<Point> keyPoints)
        {
            trbLimit.Value = lim;
            _keyPoints = keyPoints;

            _pathes = Utils.GetPicturesFromDifferentPointsOfWafer(pathesToFiles);
            foreach (string path in _pathes)
                _images.Add(new Bitmap(path));

            _currIndex = 0;
            SetCurrImage();

            lblSegmLimit.Text = lim.ToString();
        }

        private void SetCurrImage()
        {
            Segmentation segm = new Segmentation(_keyPoints, trbLimit.Value);
            pbSegmentationShow.Image = segm.GetSegmentedPicture(_images[_currIndex]);

            lblPosition.Text = String.Format("{0} из {1}", _currIndex + 1, _images.Count);
            lblNameOfFile.Text = Path.GetFileName(_pathes[_currIndex]);
        }

        private void FormCalibrationOfSegmLim_Load(object sender, EventArgs e)
        {

        }

        private void trbLimit_Scroll(object sender, EventArgs e)
        {
            lblSegmLimit.Text = trbLimit.Value.ToString();
            SetCurrImage();

            FormAnalyze.Instance.SetNewSegmentationLim(trbLimit.Value);
        }

        private void pbRightArrow_Click(object sender, EventArgs e)
        {
            if (_currIndex < _images.Count - 1)
            {
                _currIndex++;
                SetCurrImage();
            }
        }

        private void pbLeftArrow_Click(object sender, EventArgs e)
        {
            if (_currIndex > 0)
            {
                _currIndex--;
                SetCurrImage();
            }
        }
    }
}
