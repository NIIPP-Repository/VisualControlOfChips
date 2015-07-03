using System;
using System.Drawing;
using System.Windows.Forms;
using NIIPP.ComputerVision;

namespace ViewCulling
{
    public partial class FormMain : Form
    {
        public string PathToGoodChipFile { get; private set; }
        public static FormMain Instance { get; private set; }

        public FormMain()
        {
            Instance = this;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string nameOfImage = String.Format("vision_{0}.jpg", rnd.Next(4) + 1);
            BackgroundImage = new Bitmap("assets\\" + nameOfImage);
            Utils.CreateCache();

            //string path = "C:\\123 one two three.txt";
            //Mailer.SendMessage("новое сообщение", "важно!", path);
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rGBКомпонентаОбразцаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRgbAnalyze formRgbAnalyzeOfGoodChip = new FormRgbAnalyze {TopLevel = false};
            Controls.Add(formRgbAnalyzeOfGoodChip);

            formRgbAnalyzeOfGoodChip.Show();
        }

        private void запускАнализаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAnalyze formStartAnalyze = new FormAnalyze {TopLevel = false};
            Controls.Add(formStartAnalyze);

            formStartAnalyze.Show();
        }

        private void добавитьНовыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCullingProject formAddNewProject = new FormCullingProject();
            formAddNewProject.TopLevel = false;
            this.Controls.Add(formAddNewProject);
            formAddNewProject.Show();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Utils.DeleteCache();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
