using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Security.Policy;
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
        private int WWidth;
        private int WHight;

        public Camera Camera { get; set; }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        
        internal List<Control> GameObject; // По ссылке работает
        public Inventory inventory;
        public PictureBox Sprite;
        
        public Player(int wWidth, int wHight, Control.ControlCollection controls, List<Control> gameObjects, string name, int health)
        {
            WWidth = wWidth;
            WHight = wHight;
            Camera = new Camera(this, wWidth, wHight);

            inventory = new Inventory();
            Health = health;
            Name = name;
            Sprite = new PictureBox();
            
            Sprite.Location = new Point(Camera.ViewportWidth / 2, Camera.ViewportHeight / 2);
            Sprite.Name = "player";
            Sprite.Size = new Size(40, 40);
            Sprite.TabIndex = 1;
            Sprite.BackColor = Color.Blue; // Цвет для игрока
            Sprite.Tag = new KeyValuePair<int, int>(Sprite.Location.X, Sprite.Location.Y);
            Sprite.SendToBack();
            controls.Add(Sprite);
            GameObject = gameObjects;
            GameObject.Add(Sprite);

            InteractEvent += CollectTree;
            InteractEvent += OpenDoor;
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

        public void OpenDoor(Rectangle ZZZone) 
        {
            var door = GameObject.OfType<PictureBox>()
                     .FirstOrDefault(obj => obj.Name == "Door" && ZZZone.IntersectsWith(obj.Bounds)); // Поиск в зоне действия

            // Нужно запомнить коорды камеры

            if (door != null) 
            {
                Dungeons.Dungeon dungeon = new Dungeons.Dungeon();
                Form.ActiveForm.Hide();
                dungeon.ShowDialog(); // тверь
            }
        }


        public void CollectTree(Rectangle Zone)
        {

            
            var tree = GameObject.OfType<PictureBox>()
                                 .FirstOrDefault(obj => obj.Name == "Tree" && Zone.IntersectsWith(obj.Bounds)); // Поиск в зоне действия

            if (tree != null)
            {
                GameObject.Remove(tree);
                tree.Dispose();


                inventory.AddItemToInventory(new Wood());
            }
        }

        // Harvesting event
        public delegate void InteractHandler(Rectangle Zone);
        public event InteractHandler? InteractEvent;
        public void Interact()
        {
            Rectangle Zone = GetAttackZone(Sprite);

            InteractEvent?.Invoke(Zone);

        }
    }
}