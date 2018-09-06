using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RogueLikeGame.Variables;

namespace RogueLikeGame
{
    class Dagger : BaseWeapon
    {
        public Dagger(int playerLevel, int dungeonLevel)
        {
            damage = 1 * 1 * random.Next(2, 4);
            attackDistance = 1;
            hitChance = 0.9f;
            criticalChance = 0.5f;
            criticalModifly = 2.5f;

            //TODO: Придумать формулу генерации демага и свойств оружия
            name = "Кинжал";
            symbol = "D";
            description.Add(name);
            description.Add("Урон: " + damage);
            description.Add("Точность: " + hitChance);
            description.Add("Шанс крита: " + criticalChance);
            description.Add("Модификатор крита: " + criticalModifly);
        }
    }
}
