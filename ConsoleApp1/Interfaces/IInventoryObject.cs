using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeGame
{
    public interface IInventoryObject
    {
        string name { get; set; }
        string symbol { get; set; }
    }
}
