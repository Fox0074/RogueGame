using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RogueLikeGame.Variables;

namespace RogueLikeGame
{

    //TODO: переделать IStats в класс????
    class Player : IMapObject, IDestroy, IStats
    {      
        public Point position { get; set; } = new Point();
        public int numberCurrentRoom { get; set; }
        public string viewSymbol { get; set; }
        public Action<IMapObject> OnTapAction { get; set; }
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
                SetMaxHealtPoint();
            }
        }

        public int currentHealtPoint { get; set; }
        public int maxHealthPoint { get; set; }
        private const int defaultHealthPoint = 100;

        public int level { get; set; }
        public int currentExperience { get; set; }
        public int maxExperience { get; set; }

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

        private int GetDamage()
        {
            //TODO: Продумать зависимость урона, крита, попадания от характеристик
            if (random.Next(0, 101) <= (weapon.hitChance + agility) * 100)
            {
                var damageInflicted = weapon.damage + strength;

                damageInflicted = (random.Next(0, 101) <= (weapon.criticalChance + agility) * 100) ? damageInflicted : (int)(damageInflicted * (weapon.criticalModifly + agility / 10));

                return damageInflicted;
            }

            return 0;

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

        public void DoAttack(IDestroy mapObject)
        {
            int damage = GetDamage();
            mapObject.SetDamage(damage);
        }

        private void SetMaxHealtPoint()
        {
            maxHealthPoint = defaultHealthPoint + stamina * 10;
        }

        public void OnTap(IMapObject obj)
        {

        }
    }
}
