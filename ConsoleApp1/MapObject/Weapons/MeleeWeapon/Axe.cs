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
            damage = 1 * 1 * random.Next(3, 6);
            attackDistance = 1;
            hitChance = 0.6f;
            criticalChance = 0.3f;
            criticalModifly = 1.5f;

            //TODO: Придумать формулу генерации демага и свойств оружия
            name = "Топор";
            symbol = "A";
            description.Add(name);
            description.Add("Урон: " + damage);
            description.Add("Точность: " + hitChance);
            description.Add("Шанс крита: " + criticalChance);
            description.Add("Модификатор крита: " + criticalModifly);
        }
    }
}
