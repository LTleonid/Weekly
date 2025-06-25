using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp3.Items;

namespace WinFormsApp3.Generator
{
    internal class EnvironmentPlant
    {
        string Name;
        PictureBox Sprite;
        bool IsHarvestable;
        
        delegate Item HarvestHandler();
        event HarvestHandler? HarvestEvent;
        public EnvironmentPlant(string name, PictureBox sprite, bool isHarvestable)
        {
            Name = name;
            Sprite = sprite;
            IsHarvestable = isHarvestable;
            
        }
        public void onHarvest()
        {
            if (IsHarvestable)
            {
                
                HarvestEvent?.Invoke();
            }
            else
            {
                throw new InvalidOperationException("Это растение нельзя собрать.");
            }
        }
    }
}
