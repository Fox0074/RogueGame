using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Variables;

namespace ConsoleApp1
{
    class ActionControl
    {
        /// <summary>
        /// Обработка движения игрока (Скорее всего надо переделать на общее передвежение)
        /// </summary>
        /// <param name="move">Направление движения</param>
        static public void MoveCommand(direction move)
        {
            Point nextPosition = new Point(player.position);

            switch (move)
            {
                case direction.up:
                   nextPosition.y--;             
                    break;
                case direction.down:
                    nextPosition.y++;
                    break;
                case direction.right:
                        nextPosition.x++;
                    break;
                case direction.left:
                        nextPosition.x--;
                    break;
            }

            if (!DungeonRoom.currentDungeonRoom.currentCells[nextPosition.y, nextPosition.x].barrier)
            {
                player.position = new Point(nextPosition);
            }
            try
            {
                DungeonRoom.currentDungeonRoom.currentCells[nextPosition.y, nextPosition.x].OnTapAction.Invoke();
            }
            catch (Exception ex)
            {
                //Debug.log(ex.message());
            }


        }

    }
}
