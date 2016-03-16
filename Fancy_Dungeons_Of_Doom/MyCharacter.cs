using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonsOfDoom;
using System.Drawing;

namespace Fancy_Dungeons_Of_Doom
{
    public class MyCharacter:Character,IImage
    {
        public Image PlayerImage { get; set; }
        public Image OpponentImage { get; set; }

        public MyCharacter(string name, int health, int attackstrenght) : base(name, health, attackstrenght)
        {
            
        }
    }
}
