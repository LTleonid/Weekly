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
        public bool Sounds = true;
        private bool show;
        
        public Settings(bool sounds)
        {
            Sounds = sounds;
            if (sounds) show = true;
            else show = false;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (Sounds) show = true;
            Menu menu = new Menu(Sounds);
            menu.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (show == false )
            {
                Sounds = true;
                show = true;
                pictureBox3.Visible = true;
            }
            else if (show == true )
            {
                show = false;
                Sounds = false;
                pictureBox3.Visible = false;
            }
        }
    }
}
