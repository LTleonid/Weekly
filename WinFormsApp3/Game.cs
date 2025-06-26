using System.Runtime.Remoting;

namespace WinFormsApp3
{
    public partial class Game : Form
    {
        
        public static int WorldWidth = 3000;
        public static int WorldHeight = 3000;
        

        public static Player.Player Player;
       

        protected List<Control> gameObjects = new List<Control>();

        public Game()
        {
            
            InitializeComponent();
            Init();

            this.BackColor = Color.Gray;
            
            this.ClientSize = new Size(Player.Camera.ViewportWidth, Player.Camera.ViewportHeight);

            this.KeyPreview = true;
            
        }

        

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D) Player.Camera.Mright = true;
            else if (e.KeyCode == Keys.W) Player.Camera.Mup = true;
            else if (e.KeyCode == Keys.S) Player.Camera.Mdown = true;
            else if (e.KeyCode == Keys.A) Player.Camera.Mleft = true;
            else if (e.KeyCode == Keys.E)   
            {

                Player.Interact();
            }

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D) Player.Camera.Mright = false;
            else if (e.KeyCode == Keys.W) Player.Camera.Mup = false;
            else if (e.KeyCode == Keys.S) Player.Camera.Mdown = false;
            else if (e.KeyCode == Keys.A) Player.Camera.Mleft = false;
            
            base.OnKeyUp(e);
        }

        public void Init()
        {

            Player = new Player.Player(WorldWidth, WorldHeight, Controls, gameObjects, "player", 100);
            //Player.inventory.AddItemToInventory(Items.Sword());
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                PictureBox obj = new PictureBox();

                obj.Location = new Point(rnd.Next(WorldWidth), rnd.Next(WorldHeight));
                obj.Size = new Size(80, 80);
                obj.Image = Properties.Resources.Tree;
                obj.SizeMode = PictureBoxSizeMode.StretchImage;
                obj.Name = "Tree";
                obj.BringToFront();
                obj.Tag = new KeyValuePair<int, int>(obj.Location.X, obj.Location.Y);
                Controls.Add(obj);
                gameObjects.Add(obj);
            }

            for (int i = 0; i < 5; i++)
            {
                PictureBox obj = new PictureBox();

                obj.Location = new Point(rnd.Next(WorldWidth), rnd.Next(WorldHeight));
                obj.Size = new Size(40, 80);
                obj.Image = Properties.Resources.Door;
                obj.SizeMode = PictureBoxSizeMode.StretchImage;
                obj.Name = "Door";
                obj.BringToFront();
                obj.Tag = new KeyValuePair<int, int>(obj.Location.X, obj.Location.Y);
                Controls.Add(obj);
                gameObjects.Add(obj);
            }

            //Mobs.Mob zombie = new Mobs.Mob(100,"zombie", 10, 100,100, Player);
            //gameObjects.Add(zombie.Sprite);
            //Controls.Add(zombie.Sprite);
            Form2 form2 = new();
            foreach(Control control in gameObjects)
            {
                form2.label.Text += control.Name + " | " + control.Tag.ToString() + "\n";
            }
            form2.Show();
        }
    }

    public class Form2 : Form
    {
        public Label label;
        public Form2()
        {
            this.ClientSize = new Size(400, 600);
            label = new Label();
            label.Location = new Point(10, 0);
            label.Text = "";
            label.Width = 400;
            label.Height = 600;
            Controls.Add(label);

        }
    }



}