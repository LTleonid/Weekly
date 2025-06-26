using System.Drawing;

namespace WinFormsApp3.Environment
{
    public class Grass : EnvironmentObject
    {
        public Grass(Point location)
            : base("Grass", Color.Green, new Size(40, 40), location, false)
        {
            // ����� �������� ��������: Sprite.Image = Properties.Resources.Grass;
        }
    }
}