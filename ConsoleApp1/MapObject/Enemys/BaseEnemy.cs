using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RogueLikeGame.Variables;

namespace RogueLikeGame
{
    abstract class BaseEnemy : IMapObject, IDestroy
    {
        public string name { get; set; }
        public int currentHealtPoint { get; set; } = 1;
        public BaseWeapon weapon { get; set; }
        public string viewSymbol { get; set; }
        public bool barrier { get; set; }
        public Action<IMapObject> OnTapAction { get; set; }
        public ConsoleColor symbolColor { get; set; }
        public Point position { get; set; }
        public int armor { get; set; } = 0;
        public float dodgeChance { get; set; } = 0;

        protected Random random = new Random();

        public BaseEnemy(Point position)
        { 
            this.position = position;

            barrier = true;

            OnTapAction += onTap;
        }

        private int GetDamage()
        {
            //TODO: Продумать зависимость урона, крита, попадания от характеристик
            if (random.Next(0, 101) <= (weapon.hitChance) * 100)
            {
                var damageInflicted = weapon.damage;

                damageInflicted = (random.Next(0, 101) <= weapon.criticalChance * 100) ? damageInflicted : (int)(damageInflicted * weapon.criticalModifly );

                return damageInflicted;
            }

            return 0;

        }

        public virtual void SetDamage(int damage)
        {         
            if (random.Next(0, 101) > dodgeChance * 100)
            {
                if (damage - armor > 0)
                {
                    currentHealtPoint -= damage - armor;

                    EventLog.doEvent(name + " получил " + damage + " урона", ConsoleColor.DarkGreen);
                }
                else
                    EventLog.doEvent(("Атака по " + name + " не пробила броню"), ConsoleColor.DarkRed);
            }
            else
                EventLog.doEvent(("Уворот, " + name + " избежал урона"), ConsoleColor.DarkRed);
        }

        public virtual void CheckPlayer()
        {
            if (Math.Abs((position - player.position).x) <= weapon.attackDistance && Math.Abs((position - player.position).y) <= weapon.attackDistance)
            {
                int damage = GetDamage();
                if (damage > 0)
                {
                    player.SetDamage(damage);
                    ObjectDeath();
                }
                else
                {
                    EventLog.doEvent(name + " промахнулся по игроку", ConsoleColor.DarkGreen);
                }
            }
        }


        public void onTap(IMapObject obj)
        {
        }

        public void ObjectDeath()
        {
            if (currentHealtPoint <= 0)
            {
                OnTapAction -= onTap;
                DungeonRoom.currentDungeonRoom.RemoveFillObject(this);

                //TODO: переделать
                DungeonRoom.currentDungeonRoom.roomNextSteep -= CheckPlayer;

                EventLog.doEvent("Враг сдох", ConsoleColor.DarkYellow);
            }
        }
    }
}
