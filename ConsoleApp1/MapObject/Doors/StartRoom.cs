using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Global;

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
            player.numberCurrentRoom--;

            player.position = rooms[player.numberCurrentRoom].exitDoorCoordinate.CheckDoor(rooms[player.numberCurrentRoom].currentCells);
        }
    }
}
