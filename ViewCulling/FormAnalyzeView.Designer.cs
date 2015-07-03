namespace ViewCulling
{
    partial class FormAnalyzeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnalyzeView));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оригиналToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.спрайтыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сегментацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.краяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ключевыеТочкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.шаблонToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbViewPicture = new System.Windows.Forms.PictureBox();
            this.pbStatus = new System.Windows.Forms.PictureBox();
            this.rbGood = new System.Windows.Forms.RadioButton();
            this.rbBad = new System.Windows.Forms.RadioButton();
            this.gbImage = new System.Windows.Forms.GroupBox();
            this.gbInstruments = new System.Windows.Forms.GroupBox();
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCoeff = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNameOfChip = new System.Windows.Forms.Label();
            this.gbView = new System.Windows.Forms.GroupBox();
            this.pbPosition = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrPos = new System.Windows.Forms.Label();
            this.pbLeftArrow = new System.Windows.Forms.PictureBox();
            this.rbShowGoods = new System.Windows.Forms.RadioButton();
            this.rbShowAll = new System.Windows.Forms.RadioButton();
            this.pbRightArrow = new System.Windows.Forms.PictureBox();
            this.rbShowBads = new System.Windows.Forms.RadioButton();
            this.dgvCorrectStatus = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).BeginInit();
            this.gbImage.SuspendLayout();
            this.gbInstruments.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.gbView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightArrow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorrectStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.msMain.Font = new System.Drawing.Font("Candara", 10.875F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.видToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.msMain.Size = new System.Drawing.Size(748, 24);
            this.msMain.TabIndex = 0;
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
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оригиналToolStripMenuItem,
            this.спрайтыToolStripMenuItem,
            this.сегментацияToolStripMenuItem,
            this.краяToolStripMenuItem,
            this.ключевыеТочкиToolStripMenuItem,
            this.шаблонToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(45, 22);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // оригиналToolStripMenuItem
            // 
            this.оригиналToolStripMenuItem.Name = "оригиналToolStripMenuItem";
            this.оригиналToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.оригиналToolStripMenuItem.Text = "Оригинал";
            this.оригиналToolStripMenuItem.Click += new System.EventHandler(this.оригиналToolStripMenuItem_Click);
            // 
            // спрайтыToolStripMenuItem
            // 
            this.спрайтыToolStripMenuItem.Checked = true;
            this.спрайтыToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.спрайтыToolStripMenuItem.Name = "спрайтыToolStripMenuItem";
            this.спрайтыToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.спрайтыToolStripMenuItem.Text = "Подсветка повреждений";
            this.спрайтыToolStripMenuItem.Click += new System.EventHandler(this.спрайтыToolStripMenuItem_Click);
            // 
            // сегментацияToolStripMenuItem
            // 
            this.сегментацияToolStripMenuItem.Name = "сегментацияToolStripMenuItem";
            this.сегментацияToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.сегментацияToolStripMenuItem.Text = "Сегментация";
            this.сегментацияToolStripMenuItem.Click += new System.EventHandler(this.сегментацияToolStripMenuItem_Click);
            // 
            // краяToolStripMenuItem
            // 
            this.краяToolStripMenuItem.Name = "краяToolStripMenuItem";
            this.краяToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.краяToolStripMenuItem.Text = "Края";
            this.краяToolStripMenuItem.Click += new System.EventHandler(this.краяToolStripMenuItem_Click);
            // 
            // ключевыеТочкиToolStripMenuItem
            // 
            this.ключевыеТочкиToolStripMenuItem.Name = "ключевыеТочкиToolStripMenuItem";
            this.ключевыеТочкиToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.ключевыеТочкиToolStripMenuItem.Text = "Ключевые точки";
            this.ключевыеТочкиToolStripMenuItem.Click += new System.EventHandler(this.ключевыеТочкиToolStripMenuItem_Click);
            // 
            // шаблонToolStripMenuItem
            // 
            this.шаблонToolStripMenuItem.Name = "шаблонToolStripMenuItem";
            this.шаблонToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this.шаблонToolStripMenuItem.Text = "Шаблон";
            this.шаблонToolStripMenuItem.Click += new System.EventHandler(this.шаблонToolStripMenuItem_Click);
            // 
            // pbViewPicture
            // 
            this.pbViewPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbViewPicture.Location = new System.Drawing.Point(12, 20);
            this.pbViewPicture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbViewPicture.Name = "pbViewPicture";
            this.pbViewPicture.Size = new System.Drawing.Size(512, 628);
            this.pbViewPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbViewPicture.TabIndex = 1;
            this.pbViewPicture.TabStop = false;
            this.pbViewPicture.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbViewPicture_MouseDoubleClick);
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(32, 120);
            this.pbStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(100, 100);
            this.pbStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStatus.TabIndex = 2;
            this.pbStatus.TabStop = false;
            // 
            // rbGood
            // 
            this.rbGood.AutoSize = true;
            this.rbGood.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbGood.Location = new System.Drawing.Point(14, 224);
            this.rbGood.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbGood.Name = "rbGood";
            this.rbGood.Size = new System.Drawing.Size(65, 22);
            this.rbGood.TabIndex = 3;
            this.rbGood.TabStop = true;
            this.rbGood.Text = "Годен";
            this.rbGood.UseVisualStyleBackColor = true;
            this.rbGood.CheckedChanged += new System.EventHandler(this.rbGood_CheckedChanged);
            // 
            // rbBad
            // 
            this.rbBad.AutoSize = true;
            this.rbBad.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbBad.Location = new System.Drawing.Point(84, 224);
            this.rbBad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbBad.Name = "rbBad";
            this.rbBad.Size = new System.Drawing.Size(85, 22);
            this.rbBad.TabIndex = 4;
            this.rbBad.TabStop = true;
            this.rbBad.Text = "Не годен";
            this.rbBad.UseVisualStyleBackColor = true;
            this.rbBad.CheckedChanged += new System.EventHandler(this.rbBad_CheckedChanged);
            // 
            // gbImage
            // 
            this.gbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbImage.Controls.Add(this.pbViewPicture);
            this.gbImage.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbImage.Location = new System.Drawing.Point(11, 26);
            this.gbImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbImage.Name = "gbImage";
            this.gbImage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbImage.Size = new System.Drawing.Size(536, 662);
            this.gbImage.TabIndex = 1;
            this.gbImage.TabStop = false;
            this.gbImage.Text = "Изображение";
            // 
            // gbInstruments
            // 
            this.gbInstruments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInstruments.Controls.Add(this.dgvCorrectStatus);
            this.gbInstruments.Controls.Add(this.gbInfo);
            this.gbInstruments.Controls.Add(this.gbView);
            this.gbInstruments.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbInstruments.Location = new System.Drawing.Point(551, 26);
            this.gbInstruments.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbInstruments.Name = "gbInstruments";
            this.gbInstruments.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbInstruments.Size = new System.Drawing.Size(191, 662);
            this.gbInstruments.TabIndex = 2;
            this.gbInstruments.TabStop = false;
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.pbStatus);
            this.gbInfo.Controls.Add(this.rbBad);
            this.gbInfo.Controls.Add(this.label2);
            this.gbInfo.Controls.Add(this.lblCoeff);
            this.gbInfo.Controls.Add(this.rbGood);
            this.gbInfo.Controls.Add(this.label1);
            this.gbInfo.Controls.Add(this.lblNameOfChip);
            this.gbInfo.Location = new System.Drawing.Point(8, 20);
            this.gbInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbInfo.Size = new System.Drawing.Size(176, 258);
            this.gbInfo.TabIndex = 0;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Информация";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Коэфф. расхождения :";
            // 
            // lblCoeff
            // 
            this.lblCoeff.AutoSize = true;
            this.lblCoeff.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCoeff.Location = new System.Drawing.Point(8, 89);
            this.lblCoeff.Name = "lblCoeff";
            this.lblCoeff.Size = new System.Drawing.Size(28, 18);
            this.lblCoeff.TabIndex = 9;
            this.lblCoeff.Text = "<>";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Название чипа :";
            // 
            // lblNameOfChip
            // 
            this.lblNameOfChip.AutoSize = true;
            this.lblNameOfChip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNameOfChip.Location = new System.Drawing.Point(8, 46);
            this.lblNameOfChip.Name = "lblNameOfChip";
            this.lblNameOfChip.Size = new System.Drawing.Size(28, 18);
            this.lblNameOfChip.TabIndex = 7;
            this.lblNameOfChip.Text = "<>";
            // 
            // gbView
            // 
            this.gbView.Controls.Add(this.pbPosition);
            this.gbView.Controls.Add(this.label3);
            this.gbView.Controls.Add(this.lblCurrPos);
            this.gbView.Controls.Add(this.pbLeftArrow);
            this.gbView.Controls.Add(this.rbShowGoods);
            this.gbView.Controls.Add(this.rbShowAll);
            this.gbView.Controls.Add(this.pbRightArrow);
            this.gbView.Controls.Add(this.rbShowBads);
            this.gbView.Location = new System.Drawing.Point(8, 286);
            this.gbView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbView.Name = "gbView";
            this.gbView.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbView.Size = new System.Drawing.Size(176, 238);
            this.gbView.TabIndex = 1;
            this.gbView.TabStop = false;
            this.gbView.Text = "Просмотр";
            // 
            // pbPosition
            // 
            this.pbPosition.Location = new System.Drawing.Point(14, 209);
            this.pbPosition.Name = "pbPosition";
            this.pbPosition.Size = new System.Drawing.Size(149, 16);
            this.pbPosition.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(18, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Позиция :";
            // 
            // lblCurrPos
            // 
            this.lblCurrPos.AutoSize = true;
            this.lblCurrPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrPos.Location = new System.Drawing.Point(18, 187);
            this.lblCurrPos.Name = "lblCurrPos";
            this.lblCurrPos.Size = new System.Drawing.Size(28, 18);
            this.lblCurrPos.TabIndex = 11;
            this.lblCurrPos.Text = "<>";
            // 
            // pbLeftArrow
            // 
            this.pbLeftArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbLeftArrow.Image = ((System.Drawing.Image)(resources.GetObject("pbLeftArrow.Image")));
            this.pbLeftArrow.Location = new System.Drawing.Point(21, 27);
            this.pbLeftArrow.Name = "pbLeftArrow";
            this.pbLeftArrow.Size = new System.Drawing.Size(50, 50);
            this.pbLeftArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLeftArrow.TabIndex = 5;
            this.pbLeftArrow.TabStop = false;
            this.pbLeftArrow.Click += new System.EventHandler(this.pbLeftArrow_Click);
            // 
            // rbShowGoods
            // 
            this.rbShowGoods.AutoSize = true;
            this.rbShowGoods.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbShowGoods.Location = new System.Drawing.Point(21, 134);
            this.rbShowGoods.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbShowGoods.Name = "rbShowGoods";
            this.rbShowGoods.Size = new System.Drawing.Size(75, 22);
            this.rbShowGoods.TabIndex = 13;
            this.rbShowGoods.Text = "Годные";
            this.rbShowGoods.UseVisualStyleBackColor = true;
            // 
            // rbShowAll
            // 
            this.rbShowAll.AutoSize = true;
            this.rbShowAll.Checked = true;
            this.rbShowAll.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbShowAll.Location = new System.Drawing.Point(21, 86);
            this.rbShowAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbShowAll.Name = "rbShowAll";
            this.rbShowAll.Size = new System.Drawing.Size(50, 22);
            this.rbShowAll.TabIndex = 11;
            this.rbShowAll.TabStop = true;
            this.rbShowAll.Text = "Все";
            this.rbShowAll.UseVisualStyleBackColor = true;
            // 
            // pbRightArrow
            // 
            this.pbRightArrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbRightArrow.Image = ((System.Drawing.Image)(resources.GetObject("pbRightArrow.Image")));
            this.pbRightArrow.Location = new System.Drawing.Point(92, 27);
            this.pbRightArrow.Name = "pbRightArrow";
            this.pbRightArrow.Size = new System.Drawing.Size(50, 50);
            this.pbRightArrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbRightArrow.TabIndex = 6;
            this.pbRightArrow.TabStop = false;
            this.pbRightArrow.Click += new System.EventHandler(this.pbRightArrow_Click);
            // 
            // rbShowBads
            // 
            this.rbShowBads.AutoSize = true;
            this.rbShowBads.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbShowBads.Location = new System.Drawing.Point(21, 110);
            this.rbShowBads.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbShowBads.Name = "rbShowBads";
            this.rbShowBads.Size = new System.Drawing.Size(95, 22);
            this.rbShowBads.TabIndex = 12;
            this.rbShowBads.Text = "Не годные";
            this.rbShowBads.UseVisualStyleBackColor = true;
            // 
            // dgvCorrectStatus
            // 
            this.dgvCorrectStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCorrectStatus.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCorrectStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCorrectStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCorrectStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvCorrectStatus.Location = new System.Drawing.Point(8, 529);
            this.dgvCorrectStatus.Name = "dgvCorrectStatus";
            this.dgvCorrectStatus.Size = new System.Drawing.Size(176, 118);
            this.dgvCorrectStatus.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 98.47716F;
            this.Column1.HeaderText = "#";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 101.5228F;
            this.Column2.HeaderText = "Status";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FormAnalyzeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(748, 723);
            this.Controls.Add(this.gbInstruments);
            this.Controls.Add(this.gbImage);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormAnalyzeView";
            this.Text = "Просмотр и редактирование";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormAnalyzeView_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbViewPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStatus)).EndInit();
            this.gbImage.ResumeLayout(false);
            this.gbInstruments.ResumeLayout(false);
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
            this.gbView.ResumeLayout(false);
            this.gbView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeftArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRightArrow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorrectStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbViewPicture;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оригиналToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem спрайтыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сегментацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem краяToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbStatus;
        private System.Windows.Forms.RadioButton rbBad;
        private System.Windows.Forms.RadioButton rbGood;
        private System.Windows.Forms.GroupBox gbImage;
        private System.Windows.Forms.GroupBox gbInstruments;
        private System.Windows.Forms.ToolStripMenuItem ключевыеТочкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem шаблонToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbRightArrow;
        private System.Windows.Forms.PictureBox pbLeftArrow;
        private System.Windows.Forms.Label lblNameOfChip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCoeff;
        private System.Windows.Forms.RadioButton rbShowGoods;
        private System.Windows.Forms.RadioButton rbShowAll;
        private System.Windows.Forms.RadioButton rbShowBads;
        private System.Windows.Forms.GroupBox gbView;
        private System.Windows.Forms.GroupBox gbInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCurrPos;
        private System.Windows.Forms.ProgressBar pbPosition;
        private System.Windows.Forms.DataGridView dgvCorrectStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn Column2;
    }
}