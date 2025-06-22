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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            label1.Text = "Играть";
            label2.Text = "Настройки";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            WinFormsApp3.Game game = new WinFormsApp3.Game();
            game.ShowDialog();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Settings MyForm2 = new Settings();
            MyForm2.ShowDialog();
            Close();
        }
    }
}
