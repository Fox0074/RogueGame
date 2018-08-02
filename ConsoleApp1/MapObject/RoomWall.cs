using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class RoomWall : IMapObject
    {
        public string viewSymbol { get; set; }
        public bool barrier { get; set; }
        public Action OnTapAction { get; set; }
        public ConsoleColor symbolColor { get; set; }
        public Point position { get; set; }

        public RoomWall(Point position)
        {
            viewSymbol = "#";
            symbolColor = ConsoleColor.DarkGreen;
            barrier = true;
            OnTapAction += OnTap;
        }

        public void OnTap()
        {
            this.position = position;
        }
    }
}
