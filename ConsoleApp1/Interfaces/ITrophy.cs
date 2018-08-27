using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeGame
{
    public class ITrophy
    {
        public int experiance { get; set; }

        public List<IInventoryObject> inventoryObjects { get; set; } = new List<IInventoryObject>();

    }
}
