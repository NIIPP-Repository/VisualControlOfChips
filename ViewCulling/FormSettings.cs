using System;
using System.Globalization;
using System.Windows.Forms;
using NIIPP.ComputerVision;

namespace ViewCulling
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetTextBoxValue(TextBox tb, string value)
        {
            tb.Text = value;
            tb.SelectionStart = tb.Text.Length;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            SetTextBoxValue(tbSizeOfClaster, Settings.CountOfPixelsInClaster.ToString());
            SetTextBoxValue(tbSumOfClasters, Settings.SumOfPixelsInClusters.ToString());
            SetTextBoxValue(tbRadiusOfStartFilling, Settings.RadiusOfStartFilling.ToString());
            SetTextBoxValue(tbAcceptablePercent, Settings.ImpositionAcceptablePercent.ToString(CultureInfo.InvariantCulture));
            SetTextBoxValue(tbEdgeArea, Settings.EdgeNearArea.ToString());
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.CountOfPixelsInClaster = Int32.Parse(tbSizeOfClaster.Text);
                Settings.SumOfPixelsInClusters = Int32.Parse(tbSumOfClasters.Text);
                Settings.RadiusOfStartFilling = Int32.Parse(tbRadiusOfStartFilling.Text);
                Settings.ImpositionAcceptablePercent = Double.Parse(tbAcceptablePercent.Text,
                    CultureInfo.InvariantCulture);
                Settings.EdgeNearArea = Int32.Parse(tbEdgeArea.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Проверьте данные на корректность!\n" + ex.Message);
            }
        }
    }
}
