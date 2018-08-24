using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeGame
{
    class Dwarf : BaseEnemy
    {
        private List<Type> weaponTypes = new List<Type> {
            typeof(Hammer), typeof(Axe) };

        public Dwarf(Point position)
                    : base(position)
        {
            name = "Гном";
            currentHealtPoint = random.Next(20, 31);
            armor = random.Next(0, 2);
            //weapon = new Hammer(1, 1);
            viewSymbol = "D";
            symbolColor = ConsoleColor.DarkYellow;
            dodgeChance = 0.1f;

            var weaponType = weaponTypes[(random.Next(0, weaponTypes.Count))];
            System.Reflection.ConstructorInfo ci = weaponType.GetConstructor(new Type[] { typeof(int), typeof(int) });
            object obj = ci.Invoke(new object[] { 1, 1 });
            weapon = obj as BaseWeapon;
        }
        
    }
}
