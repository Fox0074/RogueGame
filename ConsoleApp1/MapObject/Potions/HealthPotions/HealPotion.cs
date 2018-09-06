using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeGame
{
    public class HealPotion : BasePotion
    {
        public int addingHealthPoints = 30;

        public HealPotion()
        {
            name = "Лечебное зелье";
            description.Add(name);
            description.Add( "Восстанавливает " + addingHealthPoints + " очков здоровья.");
        }

        public override void Drink(object obj)
        {
            IDestroy destroyObject = obj as IDestroy;

            if (destroyObject != null)
            {
                //TODO: переделать
                //destroyObject.currentHealtPoint += addingHealthPoints;
                Variables.player.currentHealtPoint += (Variables.player.maxHealthPoint - Variables.player.currentHealtPoint > addingHealthPoints) ?
                    addingHealthPoints : Variables.player.maxHealthPoint - Variables.player.currentHealtPoint;

            }
            else
            {
                EventLog.doEvent("Нельзя выпить", ConsoleColor.White);
            }
        }
    }
}
