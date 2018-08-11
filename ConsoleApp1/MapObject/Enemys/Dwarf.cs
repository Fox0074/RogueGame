using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Dwarf : BaseEnemy
    {
        public Dwarf(Point position)
                    : base(position)
        {
            name = "Гном";
            healtPoint = random.Next(20, 31);
            armor = random.Next(0, 2);
            weapon = new Hammer(1, 1);
            viewSymbol = "D";
            symbolColor = ConsoleColor.Magenta;
            dodgeChance = 0.1f;
        }
        
    }
}
