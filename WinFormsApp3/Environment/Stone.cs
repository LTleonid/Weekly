using System.Drawing;

namespace WinFormsApp3.Environment
{
    public class Stone : EnvironmentObject
    {
        public Stone(Point location)
            : base("Stone", Color.Gray, new Size(50, 50), location, true)
        {
            Sprite.Image = Properties.Resources.Rock;
        }
    }
}