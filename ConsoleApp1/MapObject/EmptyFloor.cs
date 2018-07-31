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

        public EmptyFloor()
        {
            viewSymbol = "@";
            symbolColor = ConsoleColor.White;
            barrier = false;
            OnTapAction += OnTap;
        }

        public void OnTap()
        {

        }
    }
}
