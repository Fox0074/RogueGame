using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Variables;

namespace ConsoleApp1
{
    abstract class BaseWeapon
    {
        public string weaponName { get; set; }
        public int damage { get; set; }
        public int attackDistance { get; set; }
        public float hitChance { get; set; }
        public float criticalChance { get; set; }
        public float criticalModifly { get; set; }

        public virtual int GetDamage()
        {
            int weaponDamage = 0;

            if (random.Next(0,101) <= hitChance*100)
            {
                weaponDamage = (random.Next(0, 101) <= criticalChance * 100) ? damage : (int)(damage * criticalModifly);
            }

            return weaponDamage;
        }
    }
}
