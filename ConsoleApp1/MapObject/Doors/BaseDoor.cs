using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    abstract class BaseDoor
    {
        public Point position { get; set; } = new Point();

        /// <summary>
        /// Проверка на какой из стен находиться дверь
        /// </summary>
        /// <param name="coordinate">Возвращает координаты игрока после выхода из двери</param>
        /// <returns></returns>
        public Point CheckDoor(IMapObject [,] roomCells)
        {
            var playerCoorrdinate = new Point(position);  

            if (position.x == 0)
                playerCoorrdinate.x++;
            else
                if (position.x == roomCells.GetLength(1) - 1)
                playerCoorrdinate.x--;
            else
                    if (position.y == 0)
                playerCoorrdinate.y++;
            else
                playerCoorrdinate.y--;

            return playerCoorrdinate;
        }
    }
}
