using System;
using System.Drawing;
using System.Windows.Forms;
using NIIPP.ComputerVision;

namespace ViewCulling
{
    public partial class FormWaferMap : Form
    {
        private WaferMap _waferMap;
        public static FormWaferMap Instance { get; private set; }

        public FormWaferMap()
        {
            InitializeComponent();
            Instance = this;
        }

        private void RefreshWaferMapPicture()
        {
            pbWaferMap.Image = _waferMap.GetBmpWaferMap(pbWaferMap.Width, pbWaferMap.Height);
        }

        private void ShowStatInfo()
        {
            lblCountOfAll.Text = _waferMap.CountOfChips.ToString();
            lblCountOfVisualBad.Text = _waferMap.CountOfVisBad.ToString();
            lblCountOfParBad.Text = _waferMap.CountOfParBad.ToString();
            lblCountOfBad.Text = _waferMap.CountOfBad.ToString();
            lblCountOfGood.Text = _waferMap.CountOfGood.ToString();
            lblWidth.Text = String.Format("{0} мкм", _waferMap.Width);
            lblHeight.Text = String.Format("{0} мкм", _waferMap.Height);
            lblPercentOfOut.Text = _waferMap.PercentOfOut.ToString("P");

            if (_waferMap.CurrUserSelectedChipCoord != null)
            {
                lblCurrX.Text = ((Point)_waferMap.CurrUserSelectedChipCoord).X.ToString();
                lblCurrY.Text = ((Point)_waferMap.CurrUserSelectedChipCoord).Y.ToString();
            }
        }

        public void SetWaferMap(WaferMap waferMap)
        {
            _waferMap = waferMap;
            Text = waferMap.PathToSourceFile;

            RefreshWaferMapPicture();
            ShowStatInfo();
        }

        private void FormWaferMap_Load(object sender, EventArgs e)
        {

        }

        private void FormWaferMap_SizeChanged(object sender, EventArgs e)
        {
            if (_waferMap != null)
            {
                RefreshWaferMapPicture();
            }
        }

        private void pbWaferMap_MouseClick(object sender, MouseEventArgs e)
        {
            Bitmap currImage = (Bitmap) pbWaferMap.Image;
            
            double xZoom = ((double)(e.X) / pbWaferMap.Width);
            double yZoom = ((double)(e.Y) / pbWaferMap.Height);
            int x = (int)(xZoom * currImage.Width);
            int y = (int)(yZoom * currImage.Height);
            y = (y >= currImage.Height) ? currImage.Height - 1 : y;
            x = (x >= currImage.Width) ? currImage.Width - 1 : x;
            _waferMap.SetCoordOfUserSelectedChip(x, y);

            RefreshWaferMapPicture();
            ShowStatInfo();
        }

        private void pbWaferMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_waferMap.CurrUserSelectedChipCoord != null)
            {
                Point point = (Point) _waferMap.CurrUserSelectedChipCoord;
                string prefixOfFile = String.Format("{0:000}{1:000}", point.X, point.Y);
                FormAnalyze.Instance.SendDataToShow(prefixOfFile);
            }
        }
    }
}
