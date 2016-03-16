using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom;

namespace Fancy_Dungeons_Of_Doom
{
    class GameButton : System.Windows.Forms.Button,Room
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool Block { get; set; }
        public Monster MonsterInRoom { get; set; }
        public Item ItemInRoom { get; set; }

    }
}
