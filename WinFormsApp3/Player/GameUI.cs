using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3.Player
{
    public class GameUI: Form
    {
        public GameUI() 
        {
            this.BackColor = Color.Black;
            this.MaximumSize = new Size(600, 300);
            this.MinimumSize = new Size(600, 300);
            this.Text = "Интерфэйс";
            

        }

    }
    public class InventoryUI : Form {

        private Inventory inv;
        private int choice;
        private PointF p;
        Dictionary<int, Image> inventoryImages;
        Dictionary<int, Image> itemsImages;

        public InventoryUI()
        {

            inv = new Inventory();
            
            itemsImages = new Dictionary<int, Image>
            {
                {0, Properties.Resources.Wood_item }

            };

            inventoryImages = new Dictionary<int, Image>
            {

                { 0, Properties.Resources.Null },
                { 1, Properties.Resources.One },
                { 2, Properties.Resources.Two },
                { 3, Properties.Resources.Three },
                { 4, Properties.Resources.Four },
                { 5, Properties.Resources.Five },
                { 6, Properties.Resources.Six },
                { 7, Properties.Resources.Seven },
                { 8, Properties.Resources.Eight },
                { 9, Properties.Resources.Nine },
                { 10, Properties.Resources.Ten   },
                { 11, Properties.Resources.Eleven },
                { 12, Properties.Resources.Twelve },
                { 13, Properties.Resources.Thirteen },
                { 14, Properties.Resources.Fourteen },
                { 15, Properties.Resources.Fifteen },
                { 16, Properties.Resources.Sixteen },

            };
            this.BackColor = Color.Black;
            this.MaximumSize = new Size(66 * 9 - 3, 100);
            this.MinimumSize = new Size(66 * 9 - 3, 100);
            this.Text = "Инвентарь";
            PixelPictureBox[] inventorySlots = new PixelPictureBox[9];
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                inventorySlots[i] = new PixelPictureBox
                {
                    Size = new Size(64, 64),

                    BackColor = Color.Transparent,
                    BorderStyle = BorderStyle.FixedSingle,
                    Name = "InventorySlot" + i,
                    Image = inventoryImages[i + 1]


                };
                inventorySlots[i].Location = new Point(i * inventorySlots[i].Size.Width, 0);
                inventorySlots[i].SizeMode = PictureBoxSizeMode.StretchImage;
                //Controls.Add(inventorySlots[i]);
            }
        }
        public void UpdateInventory(PaintEventArgs e)
        {
            for (int i = 0; i < inv.Length(); i++)
            {
                if (inv.GetItems()[i].Name == "Wood")
                {
                    float temp = i * 64;
                    p = new PointF(temp, 0F);
                    base.OnPaint(e);
                    e.Graphics.DrawImage(Properties.Resources.Wood_item, p);
                }
            }
            
        }
        //9 Ячеек
    }
}