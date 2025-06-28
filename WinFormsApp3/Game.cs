using System.Runtime.Remoting;
using System.Windows.Forms.VisualStyles;
using System.Drawing;
using WinFormsApp3.Environment;
using WinFormsApp3.Player;
using System.Runtime.CompilerServices;

namespace WinFormsApp3
{
    public partial class Game : Form
    {
        PaintEventArgs e1;
        public static int WorldWidth = 3000;
        public static int WorldHeight = 3000;
        public static bool sounds { get; set; }

        public static Player.Player Player;
        Player.InventoryUI invUI;

        protected List<Control> gameObjects = new List<Control>();
        public static void set_Sounds(bool flag)
        {
            sounds = flag;
        }
        public Game(bool sounds)
        {
            set_Sounds(sounds);
            InitializeComponent();
            Init();

            this.BackColor = Color.Green;

           
            
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

                Player.Interact(e1);
                invUI.UpdateInventory();
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

            this.DoubleBuffered = true;
            Player = new Player.Player(WorldWidth, WorldHeight, Controls, gameObjects, "player", 100);
            //Player.inventory.AddItemToInventory(Items.Sword());
            invUI = new(Player.inventory);
            EnvironmentGenerator generator = new();
            generator.Generate(200,WorldWidth, WorldHeight, Controls, gameObjects);  

            //Mobs.Mob zombie = new Mobs.Mob(100,"zombie", 10, 100,100, Player);
            //gameObjects.Add(zombie.Sprite);
            //Controls.Add(zombie.Sprite);
            Form2 form2 = new();
            
            form2.Show();
            PixelPictureBox floor = new PixelPictureBox();
            floor.Size = new Size(WorldWidth+600, WorldHeight+600);
            floor.BackColor = Color.Green;
            floor.BackgroundImage = Properties.Resources.Grass;
            floor.Location = new Point(-300, -300);
            floor.Name = "floor";
            floor.Tag = new KeyValuePair<int, int>(floor.Location.X, floor.Location.Y);
            Controls.Add(floor);
            gameObjects.Add(floor);
            invUI.Show();
            
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