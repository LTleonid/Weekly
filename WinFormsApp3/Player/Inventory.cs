using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp3.Items;

namespace WinFormsApp3.Player
{
    public class Inventory
    {
        protected List<Item> Items;
        public Inventory()
        {
            Items = [];
        }
        public int Length()
        {
            return Items.Count;
        }
        public List<Item> GetItems()
        {
            return Items;
        }       
        public void AddItemToInventory(Item item)
        {
            if (item != null)
            {
                var existingItem = Items.FirstOrDefault(i => i.Name == item.Name);
                if (existingItem != null)
                {
                    existingItem.Quantity += item.Quantity;
                }
                else
                {
                    Items.Add(item);
                }
            }
            
        }
        public void RemoveItemFromInventory(Item item)
        {
            if (item != null)
            {
                // Проверяем, есть ли предмет в инвентаре
                var existingItem = Items.FirstOrDefault(i => i.Name == item.Name);
                if (existingItem != null)
                {
                    
                    existingItem.Quantity -= item.Quantity;
                    if (existingItem.Quantity <= 0)
                    {
                        Items.Remove(existingItem);
                    }
                }
            }
        }
    }
}
