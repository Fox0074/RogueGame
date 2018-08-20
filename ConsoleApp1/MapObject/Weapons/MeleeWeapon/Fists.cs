using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Fists : BaseWeapon
    {
        public Fists()
        {
            weaponName = "Кулаки";
            damage = 3;
            attackDistance = 1;
            hitChance = 0.8f;
            criticalChance = 0.1f;
            criticalModifly = 1.2f;
        }
    }
}
