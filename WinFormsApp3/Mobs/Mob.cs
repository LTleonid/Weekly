using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3.Mobs
{
    public class Mob
    {
        protected Player.Player Player;
        protected System.Windows.Forms.Timer tick = new System.Windows.Forms.Timer();
        public Mob(Player.Player player)
        {
            Player = player;
            tick.Enabled = true;
            tick.Interval = 1000; // Интервал в миллисекундах
            Random rnd = new Random();
            Sprite = new PictureBox
            {
                Size = new Size(60, 60),
                BackColor = Color.Red, // Цвет для моба
                Name = Name,
                Tag = new KeyValuePair<int, int>(rnd.Next(Game.WorldWidth), Game.WorldHeight), // Начальная позиция+
                Image = icon
            };

            rangeView = 10000; // Задаем область видимости
            ViewArea = new Rectangle(
               Sprite.Right, // Левый верхний угол по X
               Sprite.Left, // Левый верхний угол по Y
               rangeView, // Ширина области видимости
               rangeView  // Высота области видимости
               );
            attackRange = 30; // Радиус атаки
            AttackArea = new Rectangle(
               Sprite.Right, // Левый верхний угол по X
               Sprite.Left, // Левый верхний угол по Y
               attackRange, // Ширина области видимости
               attackRange  // Высота области видимости
               );
            tick.Tick += tick_Tick;
            
            
        }
        //Установка с координатами
        public Mob(int health, string name, int damage, int x, int y, Player.Player player)
        {
             
            tick.Interval = 100;       
            tick.Enabled = true;
            tick.Tick += tick_Tick;
            Player = player;

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

            rangeView = 10000;
            ViewArea = new Rectangle(
               Sprite.Right, // Левый верхний угол по X
               Sprite.Left, // Левый верхний угол по Y
               rangeView, // Ширина области видимости
               rangeView  // Высота области видимости
               );

            attackRange = 30; // Радиус атаки
            AttackArea = new Rectangle(
               Sprite.Right, // Левый верхний угол по X
               Sprite.Left, // Левый верхний угол по Y
               attackRange, // Ширина области видимости
               attackRange  // Высота области видимости
               );
                   // <--- И эту
        }

        protected int rangeView;
        protected Rectangle ViewArea;

        protected Rectangle AttackArea;
        protected int attackRange; // Радиус атаки

        public Image icon;
        public int health { get; set; }
        public string Name { get; set; }
        public int damage { get; set; }
        public PictureBox Sprite { get; set; }


        //Метод для перемещения к игроку

        protected void MoveToPlayer()
        {
            var mobPosition = new Point(((KeyValuePair<int, int>)Sprite.Tag).Value, ((KeyValuePair<int, int>)Sprite.Tag).Key);
            var playerPosition = new Point(((KeyValuePair<int, int>)Player.Sprite.Tag).Value, ((KeyValuePair<int, int>)Player.Sprite.Tag).Key);

            if (Math.Abs(mobPosition.X - playerPosition.X) > attackRange || Math.Abs(mobPosition.Y - playerPosition.Y) > attackRange)
            {
                if (mobPosition.X < playerPosition.X)
                    mobPosition.X++;
                else if (mobPosition.X > playerPosition.X)
                    mobPosition.X--;

                if (mobPosition.Y < playerPosition.Y)
                    mobPosition.Y++;
                else if (mobPosition.Y > playerPosition.Y)
                    mobPosition.Y--;

                Sprite.Tag = new KeyValuePair<int, int>(mobPosition.X, mobPosition.Y);
                Sprite.Location = new Point(mobPosition.X, mobPosition.Y); // <--- добавьте эту строку

                // Обновляем области видимости и атаки
                ViewArea = new Rectangle(Sprite.Left, Sprite.Top, rangeView, rangeView);
                AttackArea = new Rectangle(Sprite.Left, Sprite.Top, attackRange, attackRange);
            }
        }
        public void tick_Tick(object sender, EventArgs e)
        {
            
            checkPlayInRange();
            
        }
        protected void checkPlayInRange()
        {
            if (ViewArea.IntersectsWith(Player.Sprite.Bounds))
            {
                MoveToPlayer();
                if (AttackArea.IntersectsWith(Player.Sprite.Bounds))
                {

                    Player.Health -= damage; // Уменьшаем здоровье игрока

                    //int dx = ((KeyValuePair<int, int>)Player.Sprite.Tag).Value - Sprite.Left ;
                    //int dy = ((KeyValuePair<int, int>)Player.Sprite.Tag).Key - Sprite.Top ;

                    Player.Sprite.Tag = new KeyValuePair<int, int>(((KeyValuePair<int, int>)Player.Sprite.Tag).Value , ((KeyValuePair<int, int>)Player.Sprite.Tag).Key );
                   //// Player.Sprite.Left += Math.Sign(dx) * 20;
                   // Player.Sprite.Top += Math.Sign(dy) * 20;
                    
                }

            }
        }

    }
}
