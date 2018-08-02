using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class EmptyFloor : IMapObject
    {
        public string viewSymbol { get; set; }
        public Action OnTapAction { get; set; }
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

        public void OnTap()
        {

        }
    }
}
