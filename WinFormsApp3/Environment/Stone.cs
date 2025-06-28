using System.Drawing;

namespace WinFormsApp3.Environment
{
    public class Stone : EnvironmentObject
    {

        public Stone(Point location)
            : base("Stone", new Size(50 + rnd.Next(1, 5), 50 + +rnd.Next(1, 5)), location, true)
        {
            Sprite.Image = Properties.Resources.Rock;
        }
    }
}