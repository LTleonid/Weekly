using System.Drawing;

namespace WinFormsApp3.Environment
{
    public class Tree : EnvironmentObject
    {
        public Tree(Point location)
            : base("Tree", new Size(200, 200), location, true)
        {
            Sprite.BackgroundImage = null ;
            Sprite.Image = Properties.Resources.Tree;
            
        }
    }
}