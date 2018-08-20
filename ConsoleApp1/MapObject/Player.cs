using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RogueLikeGame.Variables;

namespace RogueLikeGame
{
    class Player : IMapObject, IDestroy, IStats
    {
        public int currentHealtPoint { get; set; }
        public Point position { get; set; } = new Point();
        public int numberCurrentRoom { get; set; }

        public string viewSymbol { get; set; }
        public Action OnTapAction { get; set; }
        public bool barrier { get; set; }
        public ConsoleColor symbolColor { get; set; }
        public int armor { get; set; }
        public float dodgeChance { get; set; }
        public BaseWeapon weapon { get; set; }
       
        public int strength { get; set; }
        public int agility { get; set; }

        private int _stamina;
        public int stamina
        {
            get
            {
                return _stamina;
            }

            set
            {
                currentHealtPoint += (value - _stamina) * 10;
                _stamina = value;
                setMaxHealtPoint();
            }
        }

        public int maxHealthPoint { get; set; }

        private const int defaultHealthPoint = 100;

        public Player()
        {
            currentHealtPoint = 100;

            strength = 1;
            agility = 1;
            stamina = 1;

            armor = 0;
            dodgeChance = 0.1f;
            weapon = new Fists();
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
                    currentHealtPoint -= damage - armor;
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
            if (currentHealtPoint <= 0)
            {
                DungeonRoom.currentDungeonRoom.RemoveFillObject(this);

                EventLog.doEvent("Ебать ты далбоеб, земля тебе пухом братишка", ConsoleColor.DarkRed);

                Game.Initialization();
            }
        }

        private void setMaxHealtPoint()
        {
            maxHealthPoint = defaultHealthPoint + stamina * 10;
        }

    }
}
