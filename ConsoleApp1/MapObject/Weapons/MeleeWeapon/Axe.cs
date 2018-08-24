using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RogueLikeGame.Variables;

namespace RogueLikeGame
{
    class Axe : BaseWeapon
    {
        public Axe(int playerLevel, int dungeonLevel)
        {
            //TODO: Придумать формулу генерации демага и свойств оружия
            name = "Топор";
            damage = 1 * 1 * random.Next(3, 6);
            attackDistance = 1;
            hitChance = 0.6f;
            criticalChance = 0.3f;
            criticalModifly = 1.5f;
        }
    }
}
