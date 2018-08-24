using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeGame
{
    class EmptyFloor : IMapObject
    {
        public string name { get; set; } = "Пол";
        public string viewSymbol { get; set; }
        public Action<IMapObject> OnTapAction { get; set; }
        public bool barrier { get; set; }
        public ConsoleColor symbolColor { get; set; }
        public Point position { get ; set; }


        public EmptyFloor(Point position)
        {
            viewSymbol = "@";
            symbolColor = ConsoleColor.White;
            barrier = false;
            OnTapAction += OnTap;
            this.position = position;
        }

        public void OnTap(IMapObject obj)
        {

        }
    }
}
