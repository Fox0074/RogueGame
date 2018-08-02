using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Variables;

namespace ConsoleApp1
{
    class StartDoor : BaseDoor, IMapObject
    {
        public string viewSymbol { get; set; }
        public bool barrier { get; set; }
        public Action OnTapAction { get; set; }
        public ConsoleColor symbolColor { get; set; }

        public StartDoor(Point position)
        {
            viewSymbol = "@";
            symbolColor = ConsoleColor.Yellow;
            barrier = true;
            OnTapAction += OnTap;
            this.position = position;
        }

        public void OnTap()
        {           
            player.numberCurrentRoom--;

            player.position = rooms[player.numberCurrentRoom].exitDoor.CheckDoor(DungeonRoom.currentCells);
        }
    }
}
