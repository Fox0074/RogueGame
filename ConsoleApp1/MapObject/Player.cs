using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Player : IMapObject, IDestroy
    {
        public int healtPoint { get; set; }
        public Point position { get; set; } = new Point();
        public int numberCurrentRoom { get; set; }

        public string viewSymbol { get; set; }
        public Action OnTapAction { get; set; }
        public bool barrier { get; set; }
        public ConsoleColor symbolColor { get; set; }
        public int armor { get; set; }
        public float dodgeChance { get; set; }
        public BaseWeapon weapon { get; set; }


        private Random random = new Random();

        public Player()
        {
            healtPoint = 100;
            armor = 0;
            dodgeChance = 0.1f;
            weapon = new BaseWeapon();
            viewSymbol = "P";
            symbolColor = ConsoleColor.Blue;
            barrier = true;
            OnTapAction += OnTap;

            UserInterface.player = this;
        }

        public void OnTap()
        {

        }

        public void SetDamage(int damage)
        {
            if (random.Next(0, 101) > dodgeChance * 100)
            {
                if (damage - armor > 0)
                {
                    healtPoint -= damage - armor;
                    EventLog.doEvent("Игрок получил " + damage + " урона", ConsoleColor.DarkRed);

                    ObjectDeath();
                }
                else
                    EventLog.doEvent("Атака по игроку не пробила броню", ConsoleColor.DarkGreen);
            }
            else
                EventLog.doEvent("Уворот, игрок избежал урона", ConsoleColor.DarkGreen);
        }

        public void ObjectDeath()
        {
            if (healtPoint <= 0)
            {
                DungeonRoom.currentDungeonRoom.RemoveFillObject(this);

                EventLog.doEvent("Ты сдох", ConsoleColor.DarkRed);

                Game.Initialization();
            }
        }
    }
}
