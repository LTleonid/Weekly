using System.Drawing;

namespace WinFormsApp3.Environment
{
    public class Flower : EnvironmentObject
    {
        public Flower(Point location)
            : base("Flower", new Size(30, 30), location, true)
        {
            // Можно добавить картинку: Sprite.Image = Properties.Resources.Flower;
        }
    }
}