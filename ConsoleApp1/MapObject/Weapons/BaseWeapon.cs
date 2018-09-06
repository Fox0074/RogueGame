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
        public List<string> description { get; set; } = new List<string>();

        public int damage { get; set; }
        public int attackDistance { get; set; }
        public float hitChance { get; set; }
        public float criticalChance { get; set; }
        public float criticalModifly { get; set; }

        public void Use()
        {
            player.inventory.AddItems(new List<IInventoryObject> { player.weapon });
            player.weapon = this;
            player.inventory.RemoveItem(this);
        }
    }
}
