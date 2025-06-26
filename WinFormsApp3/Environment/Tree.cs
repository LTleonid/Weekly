using System.Drawing;

namespace WinFormsApp3.Environment
{
    public class Tree : EnvironmentObject
    {
        public Tree(Point location)
            : base("Tree", Color.Transparent, new Size(200, 200), location, true)
        {
            Sprite.Image = Properties.Resources.Tree;
            
        }
    }
}