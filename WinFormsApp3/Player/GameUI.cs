using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3.Player
{
    internal class GameUI: Form
    {
        public GameUI() 
        {
            this.BackColor = Color.Black;
            this.MaximumSize = new Size(600, 300);
            this.MinimumSize = new Size(600, 300);
            this.Text = "Интерфэйс";
            //10 Ячеек
        }

    }

}
