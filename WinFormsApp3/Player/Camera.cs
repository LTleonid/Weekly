using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3.Player
{   
    public class Camera
    {
        public bool Mdown;
        public bool Mup;
        public bool Mleft;
        public bool Mright;

        public int WorldWidth;
        public int WorldHeight;

        public int ViewportWidth = 600;
        public int ViewportHeight = 600;

        public int CameraX = 0;
        public int CameraY = 0;
        int fps;
        Player Player;

        public Camera(Player player, int WWidth, int WHeight)
        {
            WorldHeight = WHeight;
            WorldWidth = WWidth;
            Init();
            Player = player;
            Mdown = false;
            Mup = false;
            Mleft = false;
            Mright = false;
        }
        private void Init()
        {
            fps = 100;
            System.Windows.Forms.Timer movementTimer = new System.Windows.Forms.Timer();
            movementTimer.Interval = (1000 / fps);
            movementTimer.Tick += MovementTimer_Tick;
            movementTimer.Start();


            System.Windows.Forms.Timer cameraTimer = new System.Windows.Forms.Timer();
            cameraTimer.Interval = (1000 / fps);
            cameraTimer.Tick += CameraTimer_Tick;
            cameraTimer.Start();
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

        public void UpdateObjectsPosition()
        {
            
            foreach (var obj in Player.GameObject)
            {
                KeyValuePair<int, int>? coords = (KeyValuePair<int, int>)obj.Tag;

                int screenX = coords.Value.Value - CameraX;
                int screenY = coords.Value.Key - CameraY;


                if (screenX + obj.Width > 0 && screenX < ViewportWidth &&
                    screenY + obj.Height > 0 && screenY < ViewportHeight)
                {
                    if (obj.Name != "player")
                    {
                        obj.Location = new Point(screenX, screenY);

                        obj.Visible = true;
                    }

                }
                else
                {
                    // obj.Location = new Point(obj.Location.X - CameraX, obj.Location.Y - CameraY);
                    obj.Visible = false;
                }
               
            }
            

        }


        private void MovementTimer_Tick(object sender, EventArgs e)
        {

            int deltaX = 0, deltaY = 0;

            if (Mright) deltaX += 3;
            if (Mleft) deltaX -= 3;
            if (Mup) deltaY -= 3;
            if (Mdown) deltaY += 3;

            if (deltaX != 0 || deltaY != 0)
            {

                var worldPos = (KeyValuePair<int, int>)Player.Sprite.Tag;
                int newX = worldPos.Value + deltaX;
                int newY = worldPos.Key + deltaY;

                newX = Math.Max(0, Math.Min(newX, WorldWidth - Player.Sprite.Width));
                newY = Math.Max(0, Math.Min(newY, WorldHeight - Player.Sprite.Height));


                Player.Sprite.Tag = new KeyValuePair<int, int>(newY, newX);
                Player.Sprite.Location = new Point(newX - CameraX, newY - CameraY);
            }

        }

    }
}
