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


        Image Avatar;

        List<Item> inventory;
        

        public Button person;

        public Player(int viewportWidth, int viewportHeight, Control.ControlCollection controls, List<Control> gameObjects, string name, int health)
        {
            inventory = new List<Item>();
            Health = health;
            Name = name;

            person = new Button();
            person.Location = new Point(viewportWidth / 2, viewportHeight / 2);
            person.Name = "player"; 
            person.Size = new Size(40, 40);
            person.TabIndex = 1;
            person.UseVisualStyleBackColor = true;
            person.Tag = new KeyValuePair<int, int>(person.Location.X, person.Location.Y);
            //person.DataBindings.Add("Text", this, nameof(Name), true, DataSourceUpdateMode.OnPropertyChanged); //TODO

            controls.Add(person);         
            gameObjects.Add(person);
        }

        //Использование предмета в руке

        Item CurrentItem;
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
    }
}