using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3.Mobs
{
    public class Zombie : Mob
    {
        public Zombie(Player.Player player) : base(100, "Zombie", 10, 0, 0, player)
        {
            Sprite.BackColor = Color.Green;
        }

        public Zombie(int x, int y, Player.Player player) : base(100, "Zombie", 10, x, y, player)
        {
            Sprite.BackColor = Color.Green;
        }
    }
}
