using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RogueLikeGame.Variables;

namespace RogueLikeGame
{
    class Hammer : BaseWeapon
    {
        public Hammer(int playerLevel, int dungeonLevel)
        {
            //TODO: Придумать формулу генерации демага и свойств оружия
            weaponName = "Молот";
            damage = 1 * 1 * random.Next(3, 7);
            attackDistance = 1;
            hitChance = 0.5f;
            criticalChance = 0.2f;
            criticalModifly = 1.5f;
        }
    }
}
