using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Variables;

namespace ConsoleApp1
{
    abstract class BaseEnemy : IMapObject, IDestroy
    {
        public string name { get; set; }
        public int healtPoint { get; set; }
        public BaseWeapon weapon { get; set; }
        public string viewSymbol { get; set; }
        public bool barrier { get; set; }
        public Action OnTapAction { get; set; }
        public ConsoleColor symbolColor { get; set; }
        public Point position { get; set; }
        public int armor { get; set; }
        public float dodgeChance { get; set; }

        private Random random = new Random();

        public BaseEnemy(Point position, int healtPoint,
                    int armor, BaseWeapon weapon)
        { 
            this.position = position;
            this.healtPoint = healtPoint;
            this.armor = armor;
            this.weapon = weapon;

            barrier = true;

            Game.Step += CheckPlayer;
            OnTapAction += onTap;
        }

        public virtual void SetDamage(int damage)
        {         
            if (random.Next(0, 101) > dodgeChance * 100)
            {
                if (damage - armor > 0)
                {
                    healtPoint -= damage - armor;

                    EventLog.doEvent(name + " получил " + damage + " урона", ConsoleColor.DarkGreen);
                }
                else
                    EventLog.doEvent(("Атака по " + name + " не пробила броню"), ConsoleColor.DarkRed);
            }
            else
                EventLog.doEvent(("Уворот, " + name + " избежал урона"), ConsoleColor.DarkRed);
        }

        protected virtual void CheckPlayer()
        {
            if (Math.Abs((position - player.position).x) <= weapon.attackDistance && Math.Abs((position - player.position).y) <= weapon.attackDistance)
            {
                int damage = weapon.GetDamage();
                if (damage > 0)
                {
                    player.SetDamage(damage);
                }
                else
                {
                    EventLog.doEvent(name + " промахнулся по игроку", ConsoleColor.DarkGreen);
                }
            }
        }

        public void onTap()
        {          
            int damage = player.weapon.GetDamage();
            if (damage > 0)
            {
                SetDamage(damage);
            }
            else
            {
                EventLog.doEvent("Игрок" + " промахнулся по " + name, ConsoleColor.DarkRed);
            }
        }
    }
}
