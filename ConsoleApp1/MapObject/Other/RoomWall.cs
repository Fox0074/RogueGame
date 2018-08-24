using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeGame
{
    class RoomWall : IMapObject
    {
        public string viewSymbol { get; set; }
        public bool barrier { get; set; }
        public Action<IMapObject> OnTapAction { get; set; }
        public ConsoleColor symbolColor { get; set; }
        public Point position { get; set; }

        public RoomWall(Point position)
        {
            viewSymbol = "#";
            symbolColor = ConsoleColor.DarkGreen;
            barrier = true;
            OnTapAction += OnTap;
        }

        public void OnTap(IMapObject obj)
        {
            this.position = position;
        }
    }
}
