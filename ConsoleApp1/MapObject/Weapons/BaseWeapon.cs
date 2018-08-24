using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RogueLikeGame.Variables;

namespace RogueLikeGame
{
    abstract class BaseWeapon : IInventoryObject
    {
        public string name { get; set; }
        public string symbol { get; set; }
        public int damage { get; set; }
        public int attackDistance { get; set; }
        public float hitChance { get; set; }
        public float criticalChance { get; set; }
        public float criticalModifly { get; set; }
    }
}
