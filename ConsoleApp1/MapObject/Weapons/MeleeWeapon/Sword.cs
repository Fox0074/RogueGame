using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RogueLikeGame.Variables;

namespace RogueLikeGame
{
    class Sword : BaseWeapon
    {
        public Sword(int playerLevel, int dungeonLevel)
        {
            //TODO: Придумать формулу генерации демага и свойств оружия
            weaponName = "Меч";
            damage = 1 * 1 * random.Next(3, 7);
            attackDistance = 1;
            hitChance = 0.8f;
            criticalChance = 0.3f;
            criticalModifly = 2.0f;
        }
    }
}
