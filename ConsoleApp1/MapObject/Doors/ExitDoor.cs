using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ExitDoor : BaseDoor,IMapObject
    {
        public string viewSymbol { get; set; }
        public bool barrier { get; set; }
        public Action OnTapAction { get; set; }
        public ConsoleColor symbolColor { get; set; }

        public ExitDoor()
        {
            viewSymbol = "@";
            symbolColor = ConsoleColor.DarkRed;
            barrier = true;
            OnTapAction += OnTap;
        }

        public void OnTap()
        {
            var randomSizeRoom = new Random();

            Program.player.numberCurrentRoom++;           

            if (Program.player.numberCurrentRoom > Program.rooms.Count - 1)
            {

                Program.rooms.Add(new DungeonRoom(
                    randomSizeRoom.Next(6, 21),
                    randomSizeRoom.Next(6, 21)));
            }
            Program.player.position = Program.rooms[Program.player.numberCurrentRoom].startDoorCoordinate.CheckDoor(Program.rooms[Program.player.numberCurrentRoom].currentCells);
        }
    }
}
