using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeGame
{
    public abstract class BasePotion : IInventoryObject
    {
        public string name { get; set; }
        public string symbol { get; set; } = "P";
        public List<string> description { get; set; } = new List<string>();

        public abstract void Drink(object obj);

        public void Use()
        {
            Drink(Variables.player);
            Variables.player.inventory.RemoveItem(this);
        }
    }
}
