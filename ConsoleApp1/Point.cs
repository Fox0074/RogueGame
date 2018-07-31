using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Point
    {
        public int x { get; set; }
        public int y { get; set; }

        public Point(Point point) 
        {
            x = point.x;
            y = point.y;
        }

        public Point()
        {

        }

        public Point(int y, int x)
        {
            this.x = x;
            this.y = y;
        }
    }

}
