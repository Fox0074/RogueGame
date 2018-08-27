using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeGame
{
    class Skeleton : BaseEnemy
    {
        private List<Type> weaponTypes = new List<Type> {
            typeof(Sword), typeof(Dagger) };

        public Skeleton(Point position)
                   : base(position)
        {
            name = "Скелет";
            currentHealtPoint = random.Next(10, 16);
            armor = random.Next(0, 0);
            viewSymbol = "S";
            symbolColor = ConsoleColor.DarkGray;
            dodgeChance = 0.1f;

            var weaponType = weaponTypes[(random.Next(0, weaponTypes.Count))];
            ConstructorInfo ci = weaponType.GetConstructor(new Type[] { typeof(int), typeof(int) });
            object obj = ci.Invoke(new object[] { 1,1 });
            weapon = obj as BaseWeapon;

            deathTrophy.experiance = 50;
            deathTrophy.inventoryObjects.Add(weapon);
        }

    }
}
