namespace ViewCulling
{
    partial class FormSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbSegmentation = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRadiusOfStartFilling = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbKeyPoints = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gbMainSettings = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSizeOfClaster = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbSumOfClasters = new System.Windows.Forms.TextBox();
            this.gbImposition = new System.Windows.Forms.GroupBox();
            this.tbAcceptablePercent = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbEdgeArea = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.msMain.SuspendLayout();
            this.gbSegmentation.SuspendLayout();
            this.gbMainSettings.SuspendLayout();
            this.gbImposition.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.msMain.Font = new System.Drawing.Font("Candara", 10.875F);
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.msMain.Size = new System.Drawing.Size(1188, 48);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(90, 40);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(244, 40);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(244, 40);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // gbSegmentation
            // 
            this.gbSegmentation.Controls.Add(this.label3);
            this.gbSegmentation.Controls.Add(this.tbRadiusOfStartFilling);
            this.gbSegmentation.Controls.Add(this.label2);
            this.gbSegmentation.Controls.Add(this.radioButton1);
            this.gbSegmentation.Controls.Add(this.rbKeyPoints);
            this.gbSegmentation.Controls.Add(this.label1);
            this.gbSegmentation.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbSegmentation.Location = new System.Drawing.Point(48, 412);
            this.gbSegmentation.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbSegmentation.Name = "gbSegmentation";
            this.gbSegmentation.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbSegmentation.Size = new System.Drawing.Size(1084, 382);
            this.gbSegmentation.TabIndex = 1;
            this.gbSegmentation.TabStop = false;
            this.gbSegmentation.Text = "Сегментация";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(158, 293);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 37);
            this.label3.TabIndex = 6;
            this.label3.Text = "px";
            // 
            // tbRadiusOfStartFilling
            // 
            this.tbRadiusOfStartFilling.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tbRadiusOfStartFilling.Location = new System.Drawing.Point(50, 290);
            this.tbRadiusOfStartFilling.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbRadiusOfStartFilling.Name = "tbRadiusOfStartFilling";
            this.tbRadiusOfStartFilling.Size = new System.Drawing.Size(84, 41);
            this.tbRadiusOfStartFilling.TabIndex = 5;
            this.tbRadiusOfStartFilling.Text = "7";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(44, 242);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(810, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "Радиус начальной области закрашивания фоновой области :";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.Location = new System.Drawing.Point(50, 166);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(258, 41);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.Text = "Анализ пикселей";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rbKeyPoints
            // 
            this.rbKeyPoints.AutoSize = true;
            this.rbKeyPoints.Checked = true;
            this.rbKeyPoints.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbKeyPoints.Location = new System.Drawing.Point(50, 110);
            this.rbKeyPoints.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rbKeyPoints.Name = "rbKeyPoints";
            this.rbKeyPoints.Size = new System.Drawing.Size(262, 41);
            this.rbKeyPoints.TabIndex = 2;
            this.rbKeyPoints.TabStop = true;
            this.rbKeyPoints.Text = "Ключевые точки";
            this.rbKeyPoints.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(44, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(623, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Режим определения цвета фоновой области :";
            // 
            // gbMainSettings
            // 
            this.gbMainSettings.Controls.Add(this.label6);
            this.gbMainSettings.Controls.Add(this.label7);
            this.gbMainSettings.Controls.Add(this.tbSizeOfClaster);
            this.gbMainSettings.Controls.Add(this.label5);
            this.gbMainSettings.Controls.Add(this.label4);
            this.gbMainSettings.Controls.Add(this.tbSumOfClasters);
            this.gbMainSettings.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbMainSettings.Location = new System.Drawing.Point(48, 82);
            this.gbMainSettings.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbMainSettings.Name = "gbMainSettings";
            this.gbMainSettings.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbMainSettings.Size = new System.Drawing.Size(1084, 318);
            this.gbMainSettings.TabIndex = 2;
            this.gbMainSettings.TabStop = false;
            this.gbMainSettings.Text = "Основные параметры визуального контроля";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(222, 114);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 37);
            this.label6.TabIndex = 11;
            this.label6.Text = "px";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(44, 62);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(864, 37);
            this.label7.TabIndex = 9;
            this.label7.Text = "Минимальное количество пикселей несогласованного кластера :";
            // 
            // tbSizeOfClaster
            // 
            this.tbSizeOfClaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSizeOfClaster.Location = new System.Drawing.Point(50, 108);
            this.tbSizeOfClaster.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbSizeOfClaster.Name = "tbSizeOfClaster";
            this.tbSizeOfClaster.Size = new System.Drawing.Size(156, 41);
            this.tbSizeOfClaster.TabIndex = 10;
            this.tbSizeOfClaster.Text = "80";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(222, 236);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 37);
            this.label5.TabIndex = 8;
            this.label5.Text = "px";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(44, 188);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(980, 37);
            this.label4.TabIndex = 7;
            this.label4.Text = "Максимальная сумма пикселей несогласованных кластеров годного чипа :";
            // 
            // tbSumOfClasters
            // 
            this.tbSumOfClasters.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSumOfClasters.Location = new System.Drawing.Point(50, 230);
            this.tbSumOfClasters.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbSumOfClasters.Name = "tbSumOfClasters";
            this.tbSumOfClasters.Size = new System.Drawing.Size(156, 41);
            this.tbSumOfClasters.TabIndex = 7;
            this.tbSumOfClasters.Text = "250";
            // 
            // gbImposition
            // 
            this.gbImposition.Controls.Add(this.tbAcceptablePercent);
            this.gbImposition.Controls.Add(this.label9);
            this.gbImposition.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.gbImposition.Location = new System.Drawing.Point(48, 806);
            this.gbImposition.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbImposition.Name = "gbImposition";
            this.gbImposition.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.gbImposition.Size = new System.Drawing.Size(1084, 214);
            this.gbImposition.TabIndex = 7;
            this.gbImposition.TabStop = false;
            this.gbImposition.Text = "Совмещение";
            // 
            // tbAcceptablePercent
            // 
            this.tbAcceptablePercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tbAcceptablePercent.Location = new System.Drawing.Point(50, 142);
            this.tbAcceptablePercent.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbAcceptablePercent.Name = "tbAcceptablePercent";
            this.tbAcceptablePercent.Size = new System.Drawing.Size(156, 41);
            this.tbAcceptablePercent.TabIndex = 5;
            this.tbAcceptablePercent.Text = "0.12";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(44, 58);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(659, 74);
            this.label9.TabIndex = 4;
            this.label9.Text = "Максимальная процентная доля несоотвествия \r\nпотенциальных областей совмещения :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(566, 1308);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 37);
            this.label8.TabIndex = 7;
            this.label8.Text = "<>";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tbEdgeArea);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Font = new System.Drawing.Font("Candara", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.groupBox1.Location = new System.Drawing.Point(48, 1032);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(1084, 214);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Анализ краев";
            // 
            // tbEdgeArea
            // 
            this.tbEdgeArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tbEdgeArea.Location = new System.Drawing.Point(50, 112);
            this.tbEdgeArea.Margin = new System.Windows.Forms.Padding(6);
            this.tbEdgeArea.Name = "tbEdgeArea";
            this.tbEdgeArea.Size = new System.Drawing.Size(84, 41);
            this.tbEdgeArea.TabIndex = 5;
            this.tbEdgeArea.Text = "2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(44, 58);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(478, 37);
            this.label10.TabIndex = 4;
            this.label10.Text = "Доверительная зона вблизи краев :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(158, 112);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 37);
            this.label11.TabIndex = 7;
            this.label11.Text = "px";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1222, 996);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gbImposition);
            this.Controls.Add(this.gbMainSettings);
            this.Controls.Add(this.gbSegmentation);
            this.Controls.Add(this.msMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки проекта";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.gbSegmentation.ResumeLayout(false);
            this.gbSegmentation.PerformLayout();
            this.gbMainSettings.ResumeLayout(false);
            this.gbMainSettings.PerformLayout();
            this.gbImposition.ResumeLayout(false);
            this.gbImposition.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbSegmentation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rbKeyPoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRadiusOfStartFilling;
        private System.Windows.Forms.GroupBox gbMainSettings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbSumOfClasters;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSizeOfClaster;
        private System.Windows.Forms.GroupBox gbImposition;
        private System.Windows.Forms.TextBox tbAcceptablePercent;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbEdgeArea;
        private System.Windows.Forms.Label label10;
    }
}