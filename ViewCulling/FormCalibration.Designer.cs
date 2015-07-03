namespace ViewCulling
{
    partial class FormCalibration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalibration));
            this.pbSegmentationShow = new System.Windows.Forms.PictureBox();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPosition = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbRightArrow = new System.Windows.Forms.PictureBox();
            this.pbLeftArrow = new System.Windows.Forms.PictureBox();
            this.lblSegmLimit = new System.Windows.Forms.Label();
            this.trbLimit = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNameOfFile = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.gbTrackBar = new System.Windows.Forms.GroupBox();
            this.gbImage = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSegmentationShow)).BeginInit();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLimit)).BeginInit();
            this.gbInfo.SuspendLayout();
            this.gbTrackBar.SuspendLayout();
            this.gbImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbSegmentationShow
            // 
            this.pbSegmentationShow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSegmentationShow.Location = new System.Drawing.Point(6, 25);
            this.pbSegmentationShow.Name = "pbSegmentationShow";
            this.pbSegmentationShow.Size = new System.Drawing.Size(926, 413);
            this.pbSegmentationShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSegmentationShow.TabIndex = 0;
            this.pbSegmentationShow.TabStop = false;
            // 
            // msMain
            // 
            this.msMain.Font = new System.Drawing.Font("Candara", 10.875F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(968, 26);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(53, 22);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblPosition.Location = new System.Drawing.Point(281, 43);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(28, 18);
            this.lblPosition.TabIndex = 3;
            this.lblPosition.Text = "<>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(204, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Позиция :";
            // 
            // pbRightArrow
            // 
            this.pbRightArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbRightArrow.Image = ((System.Drawing.Image)(resources.GetObject("pbRightArrow.Image")));
            this.pbRightArrow.Location = new System.Drawing.Point(110, 34);
            this.pbRightArrow.Name = "pbRightArrow";
            this.pbRightArrow.Size = new System.Drawing.Size(66, 51);
            this.pbRightArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRightArrow.TabIndex = 1;
            this.pbRightArrow.TabStop = false;
            this.pbRightArrow.Click += new System.EventHandler(this.pbRightArrow_Click);
            // 
            // pbLeftArrow
            // 
            this.pbLeftArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLeftArrow.Image = ((System.Drawing.Image)(resources.GetObject("pbLeftArrow.Image")));
            this.pbLeftArrow.Location = new System.Drawing.Point(22, 34);
            this.pbLeftArrow.Name = "pbLeftArrow";
            this.pbLeftArrow.Size = new System.Drawing.Size(66, 51);
            this.pbLeftArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLeftArrow.TabIndex = 0;
            this.pbLeftArrow.TabStop = false;
            this.pbLeftArrow.Click += new System.EventHandler(this.pbLeftArrow_Click);
            // 
            // lblSegmLimit
            // 
            this.lblSegmLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSegmLimit.AutoSize = true;
            this.lblSegmLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSegmLimit.Location = new System.Drawing.Point(76, 79);
            this.lblSegmLimit.Name = "lblSegmLimit";
            this.lblSegmLimit.Size = new System.Drawing.Size(28, 18);
            this.lblSegmLimit.TabIndex = 5;
            this.lblSegmLimit.Text = "<>";
            // 
            // trbLimit
            // 
            this.trbLimit.BackColor = System.Drawing.SystemColors.Control;
            this.trbLimit.Location = new System.Drawing.Point(6, 25);
            this.trbLimit.Maximum = 250;
            this.trbLimit.Name = "trbLimit";
            this.trbLimit.Size = new System.Drawing.Size(436, 45);
            this.trbLimit.TabIndex = 0;
            this.trbLimit.Scroll += new System.EventHandler(this.trbLimit_Scroll);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic);
            this.label4.Location = new System.Drawing.Point(16, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Порог :";
            // 
            // lblNameOfFile
            // 
            this.lblNameOfFile.AutoSize = true;
            this.lblNameOfFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblNameOfFile.Location = new System.Drawing.Point(327, 61);
            this.lblNameOfFile.Name = "lblNameOfFile";
            this.lblNameOfFile.Size = new System.Drawing.Size(28, 18);
            this.lblNameOfFile.TabIndex = 5;
            this.lblNameOfFile.Text = "<>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic);
            this.label3.Location = new System.Drawing.Point(204, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Название файла :";
            // 
            // gbInfo
            // 
            this.gbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbInfo.Controls.Add(this.pbLeftArrow);
            this.gbInfo.Controls.Add(this.lblNameOfFile);
            this.gbInfo.Controls.Add(this.pbRightArrow);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.Controls.Add(this.label3);
            this.gbInfo.Controls.Add(this.lblPosition);
            this.gbInfo.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbInfo.Location = new System.Drawing.Point(12, 482);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(470, 111);
            this.gbInfo.TabIndex = 6;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Информация";
            // 
            // gbTrackBar
            // 
            this.gbTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTrackBar.Controls.Add(this.trbLimit);
            this.gbTrackBar.Controls.Add(this.label4);
            this.gbTrackBar.Controls.Add(this.lblSegmLimit);
            this.gbTrackBar.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbTrackBar.Location = new System.Drawing.Point(508, 482);
            this.gbTrackBar.Name = "gbTrackBar";
            this.gbTrackBar.Size = new System.Drawing.Size(448, 111);
            this.gbTrackBar.TabIndex = 7;
            this.gbTrackBar.TabStop = false;
            this.gbTrackBar.Text = "Настройка";
            // 
            // gbImage
            // 
            this.gbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbImage.Controls.Add(this.pbSegmentationShow);
            this.gbImage.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbImage.Location = new System.Drawing.Point(12, 32);
            this.gbImage.Name = "gbImage";
            this.gbImage.Size = new System.Drawing.Size(938, 444);
            this.gbImage.TabIndex = 8;
            this.gbImage.TabStop = false;
            this.gbImage.Text = "Изображение";
            // 
            // FormCalibrationAndSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(968, 605);
            this.Controls.Add(this.gbImage);
            this.Controls.Add(this.gbTrackBar);
            this.Controls.Add(this.gbInfo);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Name = "FormCalibrationAndSettings";
            this.Text = "FormCalibrationAndSettings";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormCalibrationOfSegmLim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSegmentationShow)).EndInit();
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLimit)).EndInit();
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.gbTrackBar.ResumeLayout(false);
            this.gbTrackBar.PerformLayout();
            this.gbImage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSegmentationShow;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbRightArrow;
        private System.Windows.Forms.PictureBox pbLeftArrow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TrackBar trbLimit;
        private System.Windows.Forms.Label lblSegmLimit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNameOfFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.GroupBox gbTrackBar;
        private System.Windows.Forms.GroupBox gbImage;
    }
}