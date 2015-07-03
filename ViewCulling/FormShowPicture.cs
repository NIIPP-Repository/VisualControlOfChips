using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewCulling
{
    public partial class FormShowPicture : Form
    {
        public FormShowPicture()
        {
            InitializeComponent();
        }

        public void SetImage(Bitmap image)
        {
            pbUnitedImage.Image = image;
        }

        private void FormUnionOfPictures_Load(object sender, EventArgs e)
        {

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog {Filter = "bmp files (*.bmp)|*.bmp"};

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pbUnitedImage.Image.Save(sfd.FileName);
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
