using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Player: IMapObject
    {
        public int healtPoint { get; set; }
        public Point position { get; set; } = new Point();
        public int numberCurrentRoom { get; set; }

        public string viewSymbol { get; set; }
        public Action OnTapAction { get; set; }
        public bool barrier { get; set; }
        public ConsoleColor symbolColor { get; set; }

        public Player()
        {
            healtPoint = 100;

            viewSymbol = "P";
            symbolColor = ConsoleColor.Blue;
            barrier = true;
            OnTapAction += OnTap;
        }

        public void OnTap()
        {
            
        }
    }
}
