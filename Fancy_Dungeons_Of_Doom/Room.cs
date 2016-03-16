using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom;

namespace Fancy_Dungeons_Of_Doom
{
    interface Room
    {
        Monster MonsterInRoom { get; set; }
        Item ItemInRoom { get; set; }
        bool Block { get; set; }
        //GH
    }
}
