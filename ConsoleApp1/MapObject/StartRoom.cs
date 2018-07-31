using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class StartRoom : IMapObject
    {
        public string viewSymbol { get; set; }
        public bool barrier { get; set; }
        public Action OnTapAction { get; set; }
        public ConsoleColor symbolColor { get; set; }

        public StartRoom()
        {
            viewSymbol = "@";
            symbolColor = ConsoleColor.Yellow;
            barrier = true;
            OnTapAction += OnTap;
        }

        public void OnTap()
        {
            Program.player.numberCurrentRoom--;
            //Program.player.position = Program.rooms[Program.player.numberCurrentRoom].exitDoorCoordinate;
        }
    }
}
