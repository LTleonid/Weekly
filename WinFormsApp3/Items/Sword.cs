using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp3.Mobs;

namespace WinFormsApp3.Items
{
    internal class Sword : Item
    {
        int damage;
        int durability;
        delegate int AttackHandler(Player.Player player);
        event AttackHandler? AttackEvent;

        public Sword()
        {
            Name = "Sword";
            damage = 10;
            durability = 40;
            Stack = 1;
            Icon = null;
            Consumable = true;
            Quantity = 1;
            AttackEvent += Attack;
        }

        public Player.Player Owner { get; set; } = null!;
        public List<Mob> AllMobs { get; set; } = new(); 

        public override void Consume()
        {
            durability--;
            if (durability <= 0)
            {
                Quantity = 0;
                return;
            }

            AttackEvent?.Invoke(Owner);
            base.Consume();
        }

        public int Attack(Player.Player player)
        {
            Mob? mob = FindMobInFront(player);
            if (mob != null)
            {
                mob.health -= damage;

                // Простейшее отталкивание
                int dx = mob.Sprite.Left - player.Sprite.Left;
                int dy = mob.Sprite.Top - player.Sprite.Top;

                
                mob.Sprite.Left += Math.Sign(dx) * 20;
                mob.Sprite.Top += Math.Sign(dy) * 20;

                Console.WriteLine($"Моб {mob.name} получил {damage} урона. Осталось HP: {mob.health}");
                return damage;
            }

            Console.WriteLine("Нет моба перед игроком.");
            return 0;
        }

        private Mob? FindMobInFront(Player.Player player)
        {
            Rectangle attackZone = player.GetAttackZone(player.Sprite);

            foreach (var mob in AllMobs)
            {
                if (attackZone.IntersectsWith(mob.Sprite.Bounds))
                {
                    return mob;
                }
            }

            return null;
        }

        
    }
}
