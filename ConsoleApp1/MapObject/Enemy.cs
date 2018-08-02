using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Enemy : IMapObject
    {
        public int xСoordinate { get; set; }
        public int yСoordinate { get; set; }
        public int healtPoint { get; set; }
        public int damage { get; set; }

        public string viewSymbol { get; set; }
        public bool barrier { get; set; }
        public Action OnTapAction { get; set; }
        public ConsoleColor symbolColor { get; set; }
        public Point position { get; set; }

        public Enemy(Point position)
        {
            this.position = position;
        }
    }
}
