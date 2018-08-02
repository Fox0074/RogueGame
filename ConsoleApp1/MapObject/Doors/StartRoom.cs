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

            DungeonRoom.currentDungeonRoom.RemoveFillObject(player);
            DungeonRoom.currentDungeonRoom = rooms[player.numberCurrentRoom];
            DungeonRoom.currentDungeonRoom.AddToFill(player);

            player.position = DungeonRoom.currentDungeonRoom.exitDoor.CheckDoor(DungeonRoom.currentDungeonRoom.currentCells);

            EventLog.doEvent("Игрок: вернулся в " + (player.numberCurrentRoom + 1) + " комнату", ConsoleColor.DarkGreen);
        }
    }
}
