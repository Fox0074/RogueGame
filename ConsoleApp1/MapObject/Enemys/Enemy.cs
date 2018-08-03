using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class Enemy : IMapObject, IDestroy
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

        public Enemy(Point position)
        {
            this.position = position;
            weapon = new BaseWeapon();
            Game.Step += CeckPlayer;
            symbolColor = ConsoleColor.Gray;
            viewSymbol = "E";
            barrier = true;
            armor = 0;
            dodgeChance = 0.1f;

        }

        public virtual void SetDamage(int damage)
        {
            Random random = new Random();
            if (random.Next(0, 101) < dodgeChance * 100)
            {
                if (damage - armor > 0)
                {
                    healtPoint -= damage - armor;
                }
            }
        }

        protected virtual void CeckPlayer()
        {
            if (Math.Abs((position - Variables.player.position).x) <= weapon.attackDistance && Math.Abs((position - Variables.player.position).y) <= weapon.attackDistance)
            {
                int damage = weapon.GetDamage();
                if (damage > 0)
                {
                    Variables.player.SetDamage(damage);
                }
                else
                {
                    EventLog.doEvent(name + " промахнулся по игроку", ConsoleColor.Green);
                }
            }
        }
    }
}
