using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Global;

namespace ConsoleApp1
{
    class DungeonRoom
    {
        private IMapObject[,] cells { get ; set; }
        public IMapObject[,] currentCells { get; set; }

        private Random random = new Random();

        public ExitDoor exitDoorCoordinate { get; set; } = new ExitDoor();
        public StartDoor  startDoorCoordinate { get; set; } = new StartDoor();

        public DungeonRoom(int height, int width)
        {
            currentCells = new IMapObject[height, width];
            cells = new IMapObject[height, width];

            for (int i = 0; i < height; i++)
            {
                cells[i, 0] = new RoomWall();

                cells[i, width - 1] = new RoomWall();
            }

            for (int i = 0; i < width; i++)
            {
                cells[0, i] = new RoomWall();

                cells[height - 1, i] = new RoomWall();
            }
           
            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {
                    cells[i, j] = new EmptyFloor();
                }
            }
            exitDoorCoordinate.position = GenerateExitDoor();
            cells[exitDoorCoordinate.position.y, exitDoorCoordinate.position.x] = new ExitDoor();


            if (player.numberCurrentRoom != 0)
            {
                startDoorCoordinate.position = GenerateStartDoor();
                cells[startDoorCoordinate.position.y, startDoorCoordinate.position.x] = new StartDoor();
            }

            CopyCells();          
        }

        /// <summary>
        /// Генерация двери выхода
        /// </summary>
        private Point GenerateExitDoor()
        {
            var location = new Point();

            if (random.Next(0, 2) == 0)
            {
                if (random.Next(0, 2) == 0)
                {
                    location.y = 0;
                    location.x = random.Next(1, cells.GetLength(1) - 2);

                    return location;
                }
                else
                {
                    location.y = cells.GetLength(0) - 1;
                    location.x = random.Next(1, cells.GetLength(1) - 2);

                    return location;
                }
            }
            else
            {
                if (random.Next(0, 2) == 0)
                {
                    Console.WriteLine("2 = " + random);
                    location.y = random.Next(1, cells.GetLength(0) - 2);
                    location.x = 0;

                    return location;
                }
                else
                {
                    location.y = random.Next(1, cells.GetLength(0) - 2);
                    location.x = cells.GetLength(1) - 1;

                    return location;
                }
            }
        }

        /// <summary>
        /// Генерация двери входа 
        /// </summary>
        private Point GenerateStartDoor()
        {
            var location = new Point();

            if (random.Next(0, 2) == 0)
            {
                if (random.Next(0, 2) == 0)
                {
                    while (true)
                    {
                        location.y = 0;
                        location.x = random.Next(1, cells.GetLength(1) - 2);

                        if (cells[location.y, location.x].GetType() != typeof(ExitDoor))
                            return location;
                    }
                }
                else
                {
                    while (true)
                    {
                        location.y = cells.GetLength(0) - 1;
                        location.x = random.Next(1, cells.GetLength(1) - 2);

                        if (cells[location.y, location.x].GetType() != typeof(ExitDoor))
                            return location;
                    }
                }
            }
            else
            {
                if (random.Next(0, 2) == 0)
                {
                    while (true)
                    {
                        location.y = random.Next(1, cells.GetLength(0) - 2);
                        location.x = 0;

                        if (cells[location.y, location.x].GetType() != typeof(ExitDoor))
                            return location;
                    }
                }
                else
                {
                    while (true)
                    {
                        location.y = random.Next(1, cells.GetLength(0) - 2);
                        location.x = cells.GetLength(1) - 1;

                        if (cells[location.y, location.x].GetType() != typeof(ExitDoor))
                            return location;
                    }
                }
            }
        }

        /// <summary>
        /// Вывод комнаты на консоль
        /// </summary>
        public void ViewRoom()
        {
            Console.Clear();

            for (int i = 0; i < currentCells.GetLength(0); i++)
            {
                for (int j = 0; j < currentCells.GetLength(1); j++)
                {
                    Console.ForegroundColor = currentCells[i, j].symbolColor;
                    Console.Write(currentCells[i, j].viewSymbol + " ");                   
                }
                Console.WriteLine();              
            }
            CopyCells();
        }

        /// <summary>
        /// Обнавление карты после действия
        /// </summary>
        private void CopyCells()
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    currentCells[i, j] = cells[i, j];
                }
            }
        }

    }
}
