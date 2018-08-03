using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BaseWeapon
    {
        public string weaponName { get; set; }
        public int damage { get; set; }
        public int attackDistance { get; set; }
        public float hitChance { get; set; }
        public float criticalChance { get; set; }
        public float criticalModifly { get; set; }

        private Random random = new Random();

        public BaseWeapon()
        {
            weaponName = "Кулаки";
            damage = 3;
            attackDistance = 1;
            hitChance = 0.9f;
            criticalChance = 0.1f;
            criticalModifly = 1.5f;
        }

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
