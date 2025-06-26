using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp3.Dungeons
{
    public class Dungeons
    {
        Dungeon dungeon;
        public Dungeons() 
        { 
            dungeon = new Dungeon();
        }
        public void Init() 
        {
            dungeon.Show();
        }

    }
    public class Dungeon : Form
    {

    }
}
