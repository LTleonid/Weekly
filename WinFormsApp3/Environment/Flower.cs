using System.Drawing;

namespace WinFormsApp3.Environment
{
    public class Flower : EnvironmentObject
    {
        public Flower(Point location)
            : base("Flower", Color.Magenta, new Size(30, 30), location, true)
        {
            // ����� �������� ��������: Sprite.Image = Properties.Resources.Flower;
        }
    }
}