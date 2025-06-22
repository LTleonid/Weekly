using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Menu
{
    public partial class Settings : Form
    {
        private bool show;
        public Settings()
        {
            show = true;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (show == false)
            {
                show = true;
                pictureBox3.Visible = true;
            }
            else if (show == true)
            {
                show = false;
                pictureBox3.Visible = false;
            }
        }
    }
}
