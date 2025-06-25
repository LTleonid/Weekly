using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3.Items
{
    internal class Wood : Item
    {
        public Wood()
        {
            Name = "Wood";
            Stack = 1;
            Icon = null; // Замените на реальное изображение дерева
            Consumable = false; // Дерево не является расходным материалом
            Quantity = 1; // Количество в стеке
        }
        public override void Consume()
        {
            return;
        }
    }
}
