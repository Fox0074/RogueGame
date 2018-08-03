using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Dwarf : BaseEnemy
    {
        public Dwarf(Point position, int healtPoint, int armor, BaseWeapon weapon) 
                    : base(position, healtPoint, armor, weapon)
        {
            name = "Гном";
            viewSymbol = "D";
            symbolColor = ConsoleColor.Magenta;
            dodgeChance = 0.1f;
        }
    }
}
