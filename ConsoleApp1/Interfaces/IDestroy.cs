using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface IDestroy
    {
        int healtPoint { get; set; }
        int armor { get; set; }
        float dodgeChance { get; set; }

        void SetDamage(int damage);

        void ObjectDeath ();
    }
}
