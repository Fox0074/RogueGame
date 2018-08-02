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
            Point nextPosition = new Point();

            switch (move)
            {
                case direction.up:
                    if (!DungeonRoom.currentCells
                        [player.position.y - 1, player.position.x].barrier)
                    {
                        player.position.y--;

                        //EventLog.doEvent("Игрок движение вверх", ConsoleColor.DarkGreen);

                        DungeonRoom.currentCells[player.position.y, player.position.x].OnTapAction.Invoke();
                    }
                    else
                        DungeonRoom.currentCells[player.position.y - 1, player.position.x].OnTapAction.Invoke();
                    break;

                case direction.down:
                    if (!DungeonRoom.currentCells
                        [player.position.y + 1, player.position.x].barrier)
                    {
                        player.position.y++;

                        //EventLog.doEvent("Игрок движение вниз", ConsoleColor.DarkGreen);

                        DungeonRoom.currentCells[player.position.y, player.position.x].OnTapAction.Invoke();
                    }
                    else
                        DungeonRoom.currentCells[player.position.y + 1, player.position.x].OnTapAction.Invoke();
                    break;

                case direction.right:
                    if (!DungeonRoom.currentCells
                        [player.position.y, player.position.x + 1].barrier)
                    {
                        player.position.x++;

                        //EventLog.doEvent("Игрок движение вправо", ConsoleColor.DarkGreen);

                        DungeonRoom.currentCells[player.position.y, player.position.x].OnTapAction.Invoke();
                    }
                    else
                        DungeonRoom.currentCells[player.position.y, player.position.x + 1].OnTapAction.Invoke();
                    break;

                case direction.left:
                    if (!DungeonRoom.currentCells
                        [player.position.y, player.position.x - 1].barrier)
                    {
                        player.position.x--;

                        //EventLog.doEvent("Игрок движение влево", ConsoleColor.DarkGreen);

                        DungeonRoom.currentCells[player.position.y, player.position.x].OnTapAction.Invoke();
                    }
                    else
                        DungeonRoom.currentCells[player.position.y, player.position.x - 1].OnTapAction.Invoke();
                    break;
            }
        }

    }
}
