using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeGame
{
    public class Point
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

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.y + p2.y,p1.x+p2.x);
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.y - p2.y, p1.x - p2.x);
        }

    }

}
