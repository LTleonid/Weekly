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

        public Dungeon(Player.Player player)
        {


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

        public void Init(Player.Player player)
        {

            Player = player;
            Player.Camera.CameraX = 0; Player.Camera.CameraY = 0;
            



        }
    }
}