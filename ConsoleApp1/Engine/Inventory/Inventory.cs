using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeGame
{
    public class Inventory
    {
        public List<IInventoryObject> items { get; set; } = new List<IInventoryObject>();
    }
}
