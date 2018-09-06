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
            damage = 1 * 1 * random.Next(3, 7);         
            attackDistance = 1;
            hitChance = 0.8f;
            criticalChance = 0.3f;
            criticalModifly = 2.0f;

            //TODO: Придумать формулу генерации демага и свойств оружия
            name = "Меч";
            symbol = "S";
            description.Add(name);
            description.Add("Урон: " + damage);
            description.Add("Точность: " + hitChance);
            description.Add("Шанс крита: " + criticalChance);
            description.Add("Модификатор крита: " + criticalModifly);
        }
    }
}
