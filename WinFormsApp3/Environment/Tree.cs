using System.Drawing;

namespace WinFormsApp3.Environment
{
    public class Tree : EnvironmentObject
    {
        public Tree(Point location)
            : base("Tree", new Size(200 + rnd.Next(-20, 20), 200 + rnd.Next(-20, 20)), location, true)
        {
            Sprite.BackgroundImage = null ;
            Sprite.Image = Properties.Resources.Tree;
            base.HarvestSound = new System.Media.SoundPlayer(Properties.Resources.wood_Sounds);
        }
    }
}