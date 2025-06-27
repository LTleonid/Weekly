using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3
{
    
        public class Tools
        {
            private Control.ControlCollection Controls;
            private List<Control> GameObjects;

            public Tools(Control.ControlCollection controls, List<Control> gameObjects) { Controls = controls; GameObjects = gameObjects; }

            public PixelPictureBox AddPicture(int Lx, int Ly, int Sx, int Sy, string Name, Image image)
            {
                PixelPictureBox obj = new PixelPictureBox();

                obj.Location = new Point(Lx, Ly);
                obj.Size = new Size(Sx, Sy);
                obj.Image = image;
                obj.SizeMode = PictureBoxSizeMode.StretchImage;
                obj.Name = Name;
                obj.BringToFront();
                obj.Tag = new KeyValuePair<int, int>(obj.Location.X, obj.Location.Y);
                Controls.Add(obj);
                GameObjects.Add(obj);

                return obj;
            }

            public PictureBox AddPicture(int Lx, int Ly, int Sx, int Sy, string Name, Image image, PictureBoxSizeMode sizeMode)
            {
                PictureBox obj = AddPicture(Lx, Ly, Sx, Sy, Name, image);
                obj.SizeMode = sizeMode;
                return obj;
            }

        }
}
