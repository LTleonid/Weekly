using System.ComponentModel;
using System.Runtime.CompilerServices;
using WinFormsApp3.Items;


namespace Player
{
    public class Player : INotifyPropertyChanged
    {
        int health;
        protected int Health
        {
            get => health;
            set
            {
                if (value < 0) value = 0;
                if (value != Health)
                {
                    health = value;
                    OnPropertyChanged();
                }
            }
        }

        string name;
        protected string Name
        {
            get => name;
            set { if (value != Name) { name = value; OnPropertyChanged(); } }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }



        public List<Item> inventory;

        public PictureBox Sprite;

        public Player(int viewportWidth, int viewportHeight, Control.ControlCollection controls, List<Control> gameObjects, string name, int health)
        {
            inventory = new List<Item>();
            Health = health;
            Name = name;
            Sprite = new PictureBox();
            Sprite.Location = new Point(viewportWidth / 2, viewportHeight / 2);
            Sprite.Name = "player";
            Sprite.Size = new Size(40, 40);
            Sprite.TabIndex = 1;
            Sprite.BackColor = Color.Blue; // Цвет для игрока
            Sprite.Tag = new KeyValuePair<int, int>(Sprite.Location.X, Sprite.Location.Y);
            Sprite.SendToBack();
            controls.Add(Sprite);
            gameObjects.Add(Sprite);

            HarvestEvent += () => CollectTree(gameObjects); // Fix: Use a lambda expression to match the delegate type
        }

        

        //Использование предмета в руке

        public Item CurrentItem { get; set; } // Текущий предмет игрока

        public void UseCurrentItem()
        {
            if (CurrentItem != null)
            {
                CurrentItem.Consume();
                if (CurrentItem.Quantity <= 0)
                {
                    inventory.Remove(CurrentItem);
                }
            }

        }

        public Rectangle GetAttackZone(PictureBox playerSprite)
        {
            int range = 30;

            // Простейшая реализация — зона перед игроком (вправо)
            return new Rectangle(
                playerSprite.Right,
                playerSprite.Top,
                range,
                playerSprite.Height
            );
        }

        public void AddItemToInventory(Item item)
        {
            if (item != null)
            {
                // Проверяем, есть ли уже такой предмет в инвентаре
                var existingItem = inventory.FirstOrDefault(i => i.Name == item.Name);
                if (existingItem != null)
                {
                    // Если предмет уже есть, увеличиваем количество
                    existingItem.Quantity += item.Quantity;
                }
                else
                {
                    // Иначе добавляем новый предмет в инвентарь
                    inventory.Add(item);
                }
            }
        }
        public void RemoveItemFromInventory(Item item)
        {
            if (item != null)
            {
                // Проверяем, есть ли предмет в инвентаре
                var existingItem = inventory.FirstOrDefault(i => i.Name == item.Name);
                if (existingItem != null)
                {
                    // Уменьшаем количество или удаляем предмет, если количество стало 0
                    existingItem.Quantity -= item.Quantity;
                    if (existingItem.Quantity <= 0)
                    {
                        inventory.Remove(existingItem);
                    }
                }
            }
        }
        public void CollectTree(List<Control> gameObjects)
        {
            // Определяем зону атаки игрока
            Rectangle attackZone = GetAttackZone(Sprite);

            // Ищем дерево в зоне атаки
            var tree = gameObjects.OfType<PictureBox>()
                                  .FirstOrDefault(obj => obj.Name == "Tree" && attackZone.IntersectsWith(obj.Bounds));

            if (tree != null)
            {
                // Удаляем дерево из игрового мира
                gameObjects.Remove(tree);
                tree.Dispose();

                // Добавляем 4 брёвна в инвентарь
                AddItemToInventory(new Item
                {
                    Name = "Log",
                    Quantity = 4,
                    Icon = WinFormsApp3.Properties.Resources.Wood_item
                });
            }
        }
        public delegate void HarvestHandler();
        public event HarvestHandler? HarvestEvent;
        public void Harvest()
        {
            HarvestEvent?.Invoke();

        }
    }
}