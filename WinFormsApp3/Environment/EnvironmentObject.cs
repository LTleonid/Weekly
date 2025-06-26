using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3.Environment
{
    public abstract class EnvironmentObject
    {
        public string Name { get; protected set; }
        public PictureBox Sprite { get; protected set; }
        public bool IsHarvestable { get; protected set; }

        protected EnvironmentObject(string name, Color color, Size size, Point location, bool isHarvestable)
        {
            Name = name;
            IsHarvestable = isHarvestable;
            Sprite = new PictureBox
            {
                Name = name,
                BackColor = color,
                Size = size,
                Location = location,
                Tag = new KeyValuePair<int, int>(location.X, location.Y)
            };
            Sprite.BackColor = Color.Transparent;
        }
    }
}