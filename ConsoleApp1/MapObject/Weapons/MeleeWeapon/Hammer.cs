﻿using System;
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
            damage = 1 * 1 * random.Next(3, 7);
            attackDistance = 1;          
            hitChance = 0.5f;
            criticalChance = 0.2f;
            criticalModifly = 1.5f;

            //TODO: Придумать формулу генерации демага и свойств оружия
            name = "Молот";
            symbol = "H";
            description.Add(name);
            description.Add("Урон: " + damage);
            description.Add("Точность: " + hitChance);
            description.Add("Шанс крита: " + criticalChance);
            description.Add("Модификатор крита: " + criticalModifly);
        }
    }
}
