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

        public static int WorldWidth = 1200;
        public static int WorldHeight = 600;


        Player.Player Player;


        protected List<Control> gameObjects = new List<Control>();

        public Dungeon(Player.Player player)
        {


            Init(player);

            this.BackColor = Color.DarkGray;

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

        public void Init(Player.Player player)
        {
            Player = new Player.Player(WorldWidth,WorldHeight, Controls,gameObjects, player.Sprite.Name, 100);
            //Controls.Add(Player.Sprite);
            //gameObjects.Add(Player.Sprite);

            PictureBox Topchik = new PictureBox();

            Topchik.Location = new Point(0, 0);
            Topchik.Size = new Size(20, 20);
            //Topchik.Image = Properties.Resources.Топчик;
            Topchik.SizeMode = PictureBoxSizeMode.StretchImage;
            Topchik.Name = "Топчик";
            Topchik.BringToFront();
            Topchik.Tag = new KeyValuePair<int, int>(Topchik.Location.X, Topchik.Location.Y);
            Controls.Add(Topchik);
            gameObjects.Add(Topchik);
        }
    }
}