using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3.Mobs
{
    internal class Mob
    {
        public Mob(int health, string name, int damage)
        {
            this.health = health;
            this.Name = name;
            this.damage = damage;
            Random rnd = new Random();
            Sprite = new PictureBox
            {
                Size = new Size(60, 60),
                BackColor = Color.Red, // Цвет для моба
                Name = name,
                Tag = new KeyValuePair<int, int>(rnd.Next(Game.WorldWidth), Game.WorldHeight), // Начальная позиция+
                Image = icon
            };
            

        }
        //Установка с координатами
        public Mob(int health, string name, int damage, int x, int y)
        {
            this.health = health;
            this.Name = name;
            this.damage = damage;
            Sprite = new PictureBox
            {
                Size = new Size(60, 60),
                BackColor = Color.Red, // Цвет для моба
                Name = name,
                Tag = new KeyValuePair<int, int>(x, y), 
                Image = icon
            };



        }
        public Image icon;
        public int health { get; set; }
        public string Name { get; set; }
        public int damage { get; set; }
        public PictureBox Sprite { get; set; }
        
    }
}
