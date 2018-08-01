using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Global;

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
                    if (!rooms[player.numberCurrentRoom].currentCells
                        [player.position.y - 1, player.position.x].barrier)
                    {
                        nextPosition = player.position;
                        nextPosition.y = player.position.y-1;

                        EventLog.doEvent("Игрок", "Движение вверх");

                        rooms[player.numberCurrentRoom].currentCells[player.position.y, player.position.x].OnTapAction.Invoke();
                    }
                    else
                        rooms[player.numberCurrentRoom].currentCells[player.position.y - 1, player.position.x].OnTapAction.Invoke();
                    break;

                case direction.down:
                    if (!rooms[player.numberCurrentRoom].currentCells
                        [player.position.y + 1, player.position.x].barrier)
                    {
                        player.position.y++;

                        EventLog.doEvent("Игрок", "Движение вниз");

                        rooms[player.numberCurrentRoom].currentCells[player.position.y, player.position.x].OnTapAction.Invoke();
                    }
                    else
                        rooms[player.numberCurrentRoom].currentCells[player.position.y + 1, player.position.x].OnTapAction.Invoke();
                    break;

                case direction.right:
                    if (!rooms[player.numberCurrentRoom].currentCells
                        [player.position.y, player.position.x + 1].barrier)
                    {
                        player.position.x++;

                        EventLog.doEvent("Игрок", "Движение вправо");

                        rooms[player.numberCurrentRoom].currentCells[player.position.y, player.position.x].OnTapAction.Invoke();
                    }
                    else
                        rooms[player.numberCurrentRoom].currentCells[player.position.y, player.position.x + 1].OnTapAction.Invoke();
                    break;

                case direction.left:
                    if (!rooms[player.numberCurrentRoom].currentCells
                        [player.position.y, player.position.x - 1].barrier)
                    {
                        player.position.x--;

                        EventLog.doEvent("Игрок", "Движение влево");

                        rooms[player.numberCurrentRoom].currentCells[player.position.y, player.position.x].OnTapAction.Invoke();
                    }
                    else
                        rooms[player.numberCurrentRoom].currentCells[player.position.y, player.position.x - 1].OnTapAction.Invoke();
                    break;
            }
            rooms[player.numberCurrentRoom].currentCells[player.position.y, player.position.x] = player;
        }

    }
}
