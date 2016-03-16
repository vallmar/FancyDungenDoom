using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fancy_Dungeons_Of_Doom
{
    interface IImage
    {
       Image PlayerImage { get; set; }
       Image OpponentImage { get; set; }
    }
}
