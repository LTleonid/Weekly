using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3.Generator
{
    internal class Generator
    {
        static public List<PictureBox> environment;
        public void GenerateEnvironment(int count, int viewportWidth, int viewportHeight, Control.ControlCollection controls, List<Control> gameObjects)
        {
            environment = new List<PictureBox>();
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = new Size(50, 50);
                pictureBox.Location = new Point(random.Next(0, viewportWidth - pictureBox.Width), random.Next(0, viewportHeight - pictureBox.Height));
                pictureBox.BackColor = Color.Brown; // Цвет для имитации земли
                pictureBox.Tag = new KeyValuePair<int, int>(pictureBox.Location.X, pictureBox.Location.Y);
                controls.Add(pictureBox);
                gameObjects.Add(pictureBox);
                environment.Add(pictureBox);
            }
            
        }


    }
}
