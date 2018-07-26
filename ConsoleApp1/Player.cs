using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Player
    {
        public int healtPoint { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public DungeonRoom room;

        public Player()
        {
            healtPoint = 100;
        }

    }
}
