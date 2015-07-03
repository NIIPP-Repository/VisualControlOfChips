using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NIIPP.ComputerVision;

namespace ViewCulling
{
    public partial class FormRgbAnalyze : Form
    {
        public FormRgbAnalyze()
        {
            InitializeComponent();
        }

        private void InitChart()
        {
            Bitmap bmp = new Bitmap(FormMain.Instance.PathToGoodChipFile);
            byte[, ,] currMas = Utils.BitmapToByteRgb(bmp);

            Font currFont = chartRgbAnalyzeOfGoodChip.ChartAreas[0].AxisX.TitleFont;
            Font font = new Font(currFont.Name, 14, currFont.Style, currFont.Unit);

            chartRgbAnalyzeOfGoodChip.Series.Clear();
            chartRgbAnalyzeOfGoodChip.Titles.Clear();

            chartRgbAnalyzeOfGoodChip.BackColor = Color.WhiteSmoke;
            chartRgbAnalyzeOfGoodChip.ChartAreas[0].AxisX.TitleFont = font;
            chartRgbAnalyzeOfGoodChip.ChartAreas[0].AxisY.TitleFont = font;
            chartRgbAnalyzeOfGoodChip.Titles.Add("Спектральный анализ цветовой гаммы чипа-образца");
            chartRgbAnalyzeOfGoodChip.Titles[0].Font = font;
            chartRgbAnalyzeOfGoodChip.ChartAreas[0].AxisY.Title = "Количество пикселей";
            chartRgbAnalyzeOfGoodChip.ChartAreas[0].AxisX.Title = "Интенсивность";
            chartRgbAnalyzeOfGoodChip.ChartAreas[0].AxisX.IntervalOffset = 1;
            chartRgbAnalyzeOfGoodChip.ChartAreas[0].AxisX.Interval = 5;

            Series seriesRComp = chartRgbAnalyzeOfGoodChip.Series.Add("R-компонента");
            seriesRComp.ChartType = SeriesChartType.Spline;
            seriesRComp.BorderWidth = 2;
            seriesRComp.Color = Color.Red;
            int[] rIntensity = GetIntensityMas(currMas, 0);
            for (int i = 0; i < rIntensity.Length; i++)
            {
                seriesRComp.Points.AddXY(i, rIntensity[i]);
            }

            Series seriesGComp = chartRgbAnalyzeOfGoodChip.Series.Add("G-компонента");
            seriesGComp.ChartType = SeriesChartType.Spline;
            seriesGComp.BorderWidth = 2;
            seriesGComp.Color = Color.Green;
            int[] gIntensity = GetIntensityMas(currMas, 1);
            for (int i = 0; i < gIntensity.Length; i++)
            {
                seriesGComp.Points.AddXY(i, gIntensity[i]);
            }

            Series seriesBComp = chartRgbAnalyzeOfGoodChip.Series.Add("B-компонента");
            seriesBComp.ChartType = SeriesChartType.Spline;
            seriesBComp.BorderWidth = 2;
            seriesBComp.Color = Color.Blue;
            int[] bIntensity = GetIntensityMas(currMas, 2);
            for (int i = 0; i < bIntensity.Length; i++)
            {
                seriesBComp.Points.AddXY(i, bIntensity[i]);
            }

        }

        private int[] GetIntensityMas(byte[,,] currMas, int color)
        {
            int[] res = new int[256];
            for (int i = 0; i < currMas.GetUpperBound(0); i++)
                for (int j = 0; j < currMas.GetUpperBound(1); j++)
                {
                    res[currMas[i, j, color]]++;
                }
            return res;
        }

        private void FormRgbAnalyzeOfGoodChip_Load(object sender, EventArgs e)
        {
            InitChart();
        }
    }
}
