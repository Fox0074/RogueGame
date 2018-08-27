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
        public bool lifeStatus { get; set; }
        public ITrophy deathTrophy { get; set; } = new ITrophy();

        protected Random random = new Random();

        public BaseEnemy(Point position)
        { 
            this.position = position;

            barrier = true;

            lifeStatus = true;            

            OnTapAction += OnTap;
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

        public virtual void SetDamage(int damage, IMapObject attackingObject)
        {         
            if (random.Next(0, 101) > dodgeChance * 100)
            {
                if (damage - armor > 0)
                {
                    currentHealtPoint -= damage - armor;

                    EventLog.doEvent(name + " получил " + damage + " урона от: " + attackingObject.name , ConsoleColor.DarkGreen);

                    ObjectDeath();
                }
                else
                    EventLog.doEvent(("Атака от: " + attackingObject.name + "по " + name + " не пробила броню"), ConsoleColor.DarkRed);
            }
            else
                EventLog.doEvent(("Уворот, " + name + " избежал урона от: " + attackingObject.name), ConsoleColor.DarkRed);
        }

        public virtual void CheckPlayer()
        {
            if (Math.Abs((position - player.position).x) <= weapon.attackDistance && Math.Abs((position - player.position).y) <= weapon.attackDistance)
            {
                int damage = GetDamage();
                if (damage > 0)
                {
                    player.SetDamage(damage, this);
                }
                else
                {
                    EventLog.doEvent(name + " промахнулся по игроку", ConsoleColor.DarkGreen);
                }
            }
        }


        public void OnTap(IMapObject obj)
        {
        }

        public void ObjectDeath()
        {
            if (currentHealtPoint <= 0)
            {
                lifeStatus = false;

                OnTapAction -= OnTap;

                DungeonRoom.currentDungeonRoom.RemoveFillObject(this);

                //TODO: переделать
                DungeonRoom.currentDungeonRoom.roomNextSteep -= CheckPlayer;

                EventLog.doEvent("Враг сдох", ConsoleColor.DarkYellow);              
            }
        }


    }
}
