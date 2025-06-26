using System.Drawing;

namespace WinFormsApp3.Environment
{
    public class Tree : EnvironmentObject
    {
        public Tree(Point location)
            : base("Tree", Color.SaddleBrown, new Size(80, 80), location, true)
        {
            // Можно добавить картинку: Sprite.Image = Properties.Resources.Tree;
        }
    }
}