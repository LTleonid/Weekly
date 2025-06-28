using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3.Environment
{
    public abstract class EnvironmentObject
    {
        public string Name { get; protected set; }
        public PictureBox Sprite { get; protected set; }
        public bool IsHarvestable { get; protected set; }

        public static System.Media.SoundPlayer HarvestSound { get; set; } = new System.Media.SoundPlayer();
        protected EnvironmentObject(string name, Size size, Point location, bool isHarvestable)
        {
        
            Name = name;
            IsHarvestable = isHarvestable;
            Sprite = new PixelPictureBox
            {
                Name = name,
                BackColor = Color.Transparent,
                Size = size,
                Location = location,
                Tag = new KeyValuePair<int, int>(location.X, location.Y),
                
            };
            Sprite.SizeMode = PictureBoxSizeMode.StretchImage;
            
            
        }
    }
}