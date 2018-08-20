using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeGame
{
    public interface IStats
    {
        int strength { get; set; }
        int agility { get; set; }
        int stamina { get; set; }
    }
}
