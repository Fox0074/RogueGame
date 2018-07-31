using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class StartDoor : BaseDoor, IMapObject
    {
        public string viewSymbol { get; set; }
        public bool barrier { get; set; }
        public Action OnTapAction { get; set; }
        public ConsoleColor symbolColor { get; set; }

        public StartDoor()
        {
            viewSymbol = "@";
            symbolColor = ConsoleColor.Yellow;
            barrier = true;
            OnTapAction += OnTap;
        }

        public void OnTap()
        {           
            Program.player.numberCurrentRoom--;

            Program.player.position = Program.rooms[Program.player.numberCurrentRoom].exitDoorCoordinate.CheckDoor(Program.rooms[Program.player.numberCurrentRoom].currentCells);
        }
    }
}
