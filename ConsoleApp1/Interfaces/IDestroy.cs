using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeGame
{
    interface IDestroy
    {
        int currentHealtPoint { get; set; }
        int armor { get; set; }
        float dodgeChance { get; set; }

        void SetDamage(int damage);

        void ObjectDeath ();
    }
}
