using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3
{
    
    public class PixelPictureBox : PictureBox
    {
        private System.Drawing.Drawing2D.InterpolationMode interpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

        public System.Drawing.Drawing2D.InterpolationMode InterpolationMode
        {
            get => interpolationMode;
            set
            {
                interpolationMode = value;
                this.Invalidate(); //перерисовываем
            }
        }
       
        
       
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = interpolationMode;
            //pe.Graphics.DrawImage(this.Image, new System.Drawing.Rectangle(0, 0, this.Width, this.Height));
            base.OnPaint(pe);
        }
    }

}
