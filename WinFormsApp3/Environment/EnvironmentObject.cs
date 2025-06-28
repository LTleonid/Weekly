using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3.Environment
{
    public abstract class EnvironmentObject
    {
        public static Random rnd = new Random();
        public string Name { get; protected set; }
        public PictureBox Sprite { get; protected set; }
        public bool IsHarvestable { get; protected set; }
        delegate void HarvestDelegate();
        event HarvestDelegate HarvestEvent;
        public System.Media.SoundPlayer HarvestSound { get; set; } = new System.Media.SoundPlayer();
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
            //HarvestEvent += Harvest; 

        }
        public virtual void Harvest()
        {
            if (IsHarvestable)
            {
                HarvestEvent?.Invoke();
                if (Game.sounds) HarvestSound.Play();
                Sprite.Dispose(); 
                
            }
            
        }
    }
}