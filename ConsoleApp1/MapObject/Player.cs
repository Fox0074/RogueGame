using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Player: IMapObject, IDestroy
    {
        public int healtPoint { get; set; }
        public Point position { get; set; } = new Point();
        public int numberCurrentRoom { get; set; }

        public string viewSymbol { get; set; }
        public Action OnTapAction { get; set; }
        public bool barrier { get; set; }
        public ConsoleColor symbolColor { get; set; }
        public int armor { get; set; } = 0;
        public float dodgeChance { get; set; } = 0.1f;

        private Random random = new Random();

        public Player()
        {
            healtPoint = 100;

            viewSymbol = "P";
            symbolColor = ConsoleColor.Blue;
            barrier = true;
            OnTapAction += OnTap;
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
                }
            }
            else
            {
                EventLog.doEvent("Уворот, игрок избежал урона", ConsoleColor.Green);
            }
        }
    }
}
