using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueLikeGame.LevelSystems;
using static RogueLikeGame.Variables;

namespace RogueLikeGame
{   

    class Player : IMapObject, IDestroy, IStats
    {
        public string name { get; set; } = "Игрок";
        public Point position { get; set; } = new Point();
        public int numberCurrentRoom { get; set; }
        public string viewSymbol { get; set; }
        public Action<IMapObject> OnTapAction { get; set; }
        public bool barrier { get; set; }
        public ConsoleColor symbolColor { get; set; }

        public int currentHealtPoint { get; set; }
        public int maxHealthPoint { get; set; }
        private const int defaultHealthPoint = 100;
        public bool lifeStatus { get; set; }
        public ITrophy deathTrophy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int armor { get; set; }
        public float dodgeChance { get; set; }
        public BaseWeapon weapon { get; set; }
        public LevelSystem level { get; set; }

        public Inventory inventory { get; set; } = new Inventory();

        public int freeStats { get; set; }
        public int strength { get; set; }
        public int agility { get; set; }
        private int _mstamina;
        public int stamina
        {
            get
            {
                return _mstamina;
            }

            set
            {
                currentHealtPoint += (value - _mstamina) * 10;
                _mstamina = value;
                SetMaxHealtPoint();
            }
        }

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
            lifeStatus = true;

            inventory.items.Add(new Sword(1,1));

            UserInterface.player = this;
            level = new LevelSystem(this);

        }

        public void SetDamage(int damage, IMapObject attackingObject)
        {
            if (random.Next(0, 101) > dodgeChance * 100)
            {
                if (damage - armor > 0)
                {
                    currentHealtPoint -= damage - armor;
                    EventLog.doEvent("Игрок получил " + damage + " урона от:" + attackingObject.name, ConsoleColor.DarkRed);

                    ObjectDeath();
                }
                else
                    EventLog.doEvent("Атака от:" + attackingObject.name + " по игроку не пробила броню", ConsoleColor.DarkGreen);
            }
            else
                EventLog.doEvent("Уворот, игрок избежал урона от: " + attackingObject.name, ConsoleColor.DarkGreen);
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
                lifeStatus = false;

                OnTapAction -= OnTap;

                DungeonRoom.currentDungeonRoom.RemoveFillObject(this);

                EventLog.doEvent("Ебать ты далбоеб, земля тебе пухом братишка", ConsoleColor.DarkRed);

                Game.Initialization();
            }
        }

        public void DoAttack(IDestroy mapObject)
        {
            int damage = GetDamage();
            mapObject.SetDamage(damage, this);

            if (mapObject.lifeStatus == false)
            {
                level.AddExperience(mapObject.deathTrophy.experiance);

            }


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
