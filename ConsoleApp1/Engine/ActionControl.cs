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

                    //EventLog.doEvent("Игрок движение вверх", ConsoleColor.DarkGreen);
                    break;
                case direction.down:
                        nextPosition.y++;

                    //EventLog.doEvent("Игрок движение вниз", ConsoleColor.DarkGreen);
                    break;
                case direction.right:
                        nextPosition.x++;

                    //EventLog.doEvent("Игрок движение вправо", ConsoleColor.DarkGreen);
                    break;
                case direction.left:
                        nextPosition.x--;

                    //EventLog.doEvent("Игрок движение влево", ConsoleColor.DarkGreen);
                    break;
            }

            if (!DungeonRoom.currentDungeonRoom.currentCells[nextPosition.y, nextPosition.x].barrier)
            {
                player.position = new Point(nextPosition);

                //EventLog.doEvent("Игрок движение вверх", ConsoleColor.DarkGreen);
            }

            DungeonRoom.currentDungeonRoom.currentCells[nextPosition.y, nextPosition.x].OnTapAction.Invoke();


        }

    }
}
