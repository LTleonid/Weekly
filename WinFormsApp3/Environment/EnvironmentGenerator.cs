using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3.Environment
{
    public class EnvironmentGenerator
    {
        private readonly Random random = new();

        public List<EnvironmentObject> Generate(int count, int width, int height, Control.ControlCollection controls, List<Control> gameObjects)
        {
            var objects = new List<EnvironmentObject>();
            for (int i = 0; i < count; i++)
            {
                int type = random.Next(4);
                Point location = new Point(random.Next(0, width - 80), random.Next(0, height - 80));
                EnvironmentObject obj = type switch
                {
                    0 => new Tree(location),
                    1 => new Grass(location),
                    2 => new Flower(location),
                    3 => new Stone(location),
                    _ => new Tree(location)
                };
                controls.Add(obj.Sprite);
                gameObjects.Add(obj.Sprite);
                objects.Add(obj);
            }
            return objects;
        }
    }
}