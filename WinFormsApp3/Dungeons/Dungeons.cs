﻿using System;
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
        PaintEventArgs e1;
        public static int WorldWidth = 1200;
        public static int WorldHeight = 600;


        Player.Player Player;

        Tools tools;

        protected List<Control> gameObjects = new List<Control>();

        public Dungeon(Player.Player player)
        {

            tools = new Tools(Controls, gameObjects);

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

                Player.Interact(e1);
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
            tools.AddPicture(0, 0, 600, 900, "Background", Properties.Resources.Grass);
        }
    }
}