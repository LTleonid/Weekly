using System.ComponentModel;
using System.Runtime.CompilerServices;
using WinFormsApp3.Items;


namespace WinFormsApp3.Player
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


        List<Control> GameObject; // По ссылке работает
        public Inventory inventory;
        public PictureBox Sprite;

        public Player(int viewportWidth, int viewportHeight, Control.ControlCollection controls, List<Control> gameObjects, string name, int health)
        {
            inventory = new Inventory();
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
            GameObject = gameObjects;
            GameObject.Add(Sprite);

            HarvestEvent += CollectTree; 
        }

        public Item CurrentItem { get; set; } 

        public void UseCurrentItem()
        {
            if (CurrentItem != null)
            {
                CurrentItem.Consume();
                if (CurrentItem.Quantity <= 0)
                {
                    inventory.RemoveItemFromInventory(CurrentItem);
                }
            }

        }

        public Rectangle GetAttackZone(PictureBox playerSprite)
        {
            int range = 30;

            return new Rectangle(
                playerSprite.Right,
                playerSprite.Top,
                range,
                playerSprite.Height
            );
        }

        
        public void CollectTree(List<Control> gameObjects)
        {

            Rectangle attackZone = GetAttackZone(Sprite);

            var tree = gameObjects.OfType<PictureBox>()
                                  .FirstOrDefault(obj => obj.Name == "Tree" && attackZone.IntersectsWith(obj.Bounds));

            if (tree != null)
            {
                gameObjects.Remove(tree);
                tree.Dispose();


                inventory.AddItemToInventory(new Wood());
            }
        }
        public delegate void HarvestHandler(List<Control> Objects);
        public event HarvestHandler? HarvestEvent;
        public void Harvest()
        {
            HarvestEvent?.Invoke(GameObject);

        }
    }
}