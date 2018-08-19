using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Skeleton : BaseEnemy
    {
        public Skeleton(Point position)
                   : base(position)
        {
            name = "Скелет";
            healtPoint = random.Next(10, 16);
            armor = random.Next(0, 0);
            //weapon = new Sword(1, 1);
            viewSymbol = "S";
            symbolColor = ConsoleColor.Magenta;
            dodgeChance = 0.1f;
        }
    }
}
