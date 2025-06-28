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
        bool sounds = true;
        Settings MyForm2;
        
        public Menu(bool sounds)
        {
            MyForm2 = new Settings(sounds);
            InitializeComponent();
            label1.Text = "Играть";
            label2.Text = "Настройки";
            this.sounds = sounds;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            WinFormsApp3.Game game = new WinFormsApp3.Game(sounds);
            game.ShowDialog();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyForm2.ShowDialog();
            Close();
        }
    }
}
