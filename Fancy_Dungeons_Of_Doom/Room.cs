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
