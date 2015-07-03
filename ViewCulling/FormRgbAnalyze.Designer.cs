namespace ViewCulling
{
    partial class FormRgbAnalyze
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRgbAnalyze));
            this.chartRgbAnalyzeOfGoodChip = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartRgbAnalyzeOfGoodChip)).BeginInit();
            this.SuspendLayout();
            // 
            // chartRgbAnalyzeOfGoodChip
            // 
            this.chartRgbAnalyzeOfGoodChip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chartRgbAnalyzeOfGoodChip.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartRgbAnalyzeOfGoodChip.Legends.Add(legend1);
            this.chartRgbAnalyzeOfGoodChip.Location = new System.Drawing.Point(1, 1);
            this.chartRgbAnalyzeOfGoodChip.Name = "chartRgbAnalyzeOfGoodChip";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartRgbAnalyzeOfGoodChip.Series.Add(series1);
            this.chartRgbAnalyzeOfGoodChip.Size = new System.Drawing.Size(1118, 700);
            this.chartRgbAnalyzeOfGoodChip.TabIndex = 0;
            this.chartRgbAnalyzeOfGoodChip.Text = "chartRgbAnalyzeOfGoodChip";
            // 
            // FormRgbAnalyzeOfGoodChip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 701);
            this.Controls.Add(this.chartRgbAnalyzeOfGoodChip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRgbAnalyzeOfGoodChip";
            this.Text = "FormRgbAnalyzeOfGoodChip";
            this.Load += new System.EventHandler(this.FormRgbAnalyzeOfGoodChip_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartRgbAnalyzeOfGoodChip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartRgbAnalyzeOfGoodChip;
    }
}