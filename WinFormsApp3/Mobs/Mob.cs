using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3.Mobs
{
    internal class Mob
    {
        public Mob(int health, string name, int damage, PictureBox sprite)
        {
            this.health = health;
            this.name = name;
            this.damage = damage;
            Sprite = sprite;

        }

        public int health { get; set; }
        public string name { get; set; }
        public int damage { get; set; }
        public PictureBox Sprite { get; set; }
        
    }
}
