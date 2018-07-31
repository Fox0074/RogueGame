using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ExitDoor : IMapObject
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

            Program.rooms.Add(new DungeonRoom(
                randomSizeRoom.Next(6, 21),
                randomSizeRoom.Next(6, 21),
                1, 1
                ));
            
        }
    }
}
