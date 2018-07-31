using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            switch (move)
            {
                case direction.up:
                    if (!Program.rooms[Program.player.numberCurrentRoom].currentCells
                        [Program.player.position.y - 1, Program.player.position.x].barrier)
                    {
                        Program.player.position.y--;
                    }
                    Program.rooms[Program.player.numberCurrentRoom].currentCells[Program.player.position.y - 1, Program.player.position.x].OnTapAction.Invoke();
                    break;

                case direction.down:
                    if (!Program.rooms[Program.player.numberCurrentRoom].currentCells
                        [Program.player.position.y + 1, Program.player.position.x].barrier)
                    {
                        Program.player.position.y++;
                    }
                    Program.rooms[Program.player.numberCurrentRoom].currentCells[Program.player.position.y + 1, Program.player.position.x].OnTapAction.Invoke();
                    break;

                case direction.right:
                    if (!Program.rooms[Program.player.numberCurrentRoom].currentCells
                        [Program.player.position.y, Program.player.position.x + 1].barrier)
                    {
                        Program.player.position.x++;
                    }
                    Program.rooms[Program.player.numberCurrentRoom].currentCells[Program.player.position.y, Program.player.position.x + 1].OnTapAction.Invoke();
                    break;

                case direction.left:
                    if (!Program.rooms[Program.player.numberCurrentRoom].currentCells
                        [Program.player.position.y, Program.player.position.x - 1].barrier)
                    {
                        Program.player.position.x--;
                    }
                    Program.rooms[Program.player.numberCurrentRoom].currentCells[Program.player.position.y, Program.player.position.x - 1].OnTapAction.Invoke();
                    break;
            }
            Program.rooms[Program.player.numberCurrentRoom].currentCells[Program.player.position.y, Program.player.position.x] = Program.player;
        }
    }
}
