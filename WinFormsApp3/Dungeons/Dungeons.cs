using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3.Dungeons
{
    public class Dungeons
    {


        public Dungeons() 
        { 
            
        }


    }
    public class Dungeon : Form
    {
        
        public static int WorldWidth = 3000;
        public static int WorldHeight = 3000;


        Player.Player Player;


        protected List<Control> gameObjects = new List<Control>();
        public Dungeon()
        {
            dungeon = new Dungeon();
            Mdown = false;
            Mup = false;
            Mleft = false;
            Mright = false;
            this.BackColor = Color.Green;

            this.ClientSize = new Size(ViewportWidth, ViewportHeight);

            Init();
            this.KeyPreview = true;
            int fps = 100;
            System.Windows.Forms.Timer movementTimer = new System.Windows.Forms.Timer();
            movementTimer.Interval = (1000 / fps);
            movementTimer.Tick += MovementTimer_Tick;
            movementTimer.Start();


            System.Windows.Forms.Timer cameraTimer = new System.Windows.Forms.Timer();
            cameraTimer.Interval = (1000 / fps);
            cameraTimer.Tick += CameraTimer_Tick;
            cameraTimer.Start();
            this.ClientSize = new Size(600, 600);
            this.Size = new Size(1200, 600);
            this.MaximumSize = new Size(600, 600);
            this.MinimumSize = new Size(600, 600);
            this.Text = "В пещере...";
            this.BackColor = Color.DarkGray;
        }
        private void CameraTimer_Tick(object sender, EventArgs e)
        {
            var playerWorldPos = (KeyValuePair<int, int>)Player.Sprite.Tag;
            int targetX = playerWorldPos.Value - ((ViewportWidth - Player.Sprite.Size.Width) / 2);
            int targetY = playerWorldPos.Key - ((ViewportHeight - Player.Sprite.Size.Height) / 2);

            CameraX += (int)((targetX - CameraX) * 0.1);
            CameraY += (int)((targetY - CameraY) * 0.1);

            CameraX = Math.Max(CameraX, Math.Min(CameraX, WorldWidth - ViewportWidth));
            CameraY = Math.Max(CameraY, Math.Min(CameraY, WorldHeight - ViewportHeight));
            Player.Sprite.Location = new Point(playerWorldPos.Value - CameraX, playerWorldPos.Key - CameraY);
            UpdateObjectsPosition();
        }
        private void UpdateObjectsPosition()
        {
            string text = "";
            foreach (var obj in gameObjects)
            {
                KeyValuePair<int, int>? coords = (KeyValuePair<int, int>)obj.Tag;


            Init(player);

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

            Player = new Player.Player(ViewportWidth, ViewportHeight, Controls, gameObjects, "player", 100);
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

            form.Show();

        }
    }
}