using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3.Items
{
    internal class Sword : Item
    {
        int damage;
        int durability;
        public Sword()
        {
            Name = "Sword";
            this.damage = 10;
            this.durability = 40;
            Stack = 1;
            Icon = null;
            Consumable = true; 
            Quantity = 1; 
        }
        
        public override void Consume()
        {
            if (durability <= 1) return; // Если прочность меньше или равна 0, не используем
            durability--; // Уменьшаем прочность
            if (durability == 0)
            {
                // Логика для уничтожения меча, если прочность достигла 0
                Quantity = 0; // Удаляем меч из инвентаря
            }
        }
    }
}
