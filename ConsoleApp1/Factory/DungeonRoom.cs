using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Variables;

namespace ConsoleApp1
{
    class DungeonRoom
    {        
        public static DungeonRoom currentDungeonRoom;

        public IMapObject[,] currentCells;
        public ExitDoor exitDoor { get; set; }
        public StartDoor startDoor { get; set; }
        public Action roomNextSteep = delegate { };

        private List<IMapObject> objectsOnMap = new List<IMapObject>();
        private IMapObject[,] cells { get; set; }
        private Random random = new Random();
      
        public DungeonRoom(int height, int width)
        {
            
            cells = new IMapObject[height, width];

            for (int i = 0; i < height; i++)
            {
                cells[i, 0] = new RoomWall(new Point(i, 0));

                cells[i, width - 1] = new RoomWall(new Point(i, width - 1));
            }

            for (int i = 0; i < width; i++)
            {
                cells[0, i] = new RoomWall(new Point(0, i));

                cells[height - 1, i] = new RoomWall(new Point(height - 1, i));
            }
           
            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {
                    cells[i, j] = new EmptyFloor(new Point(i, j));
                }
            }


            exitDoor = new ExitDoor(GenerateExitDoor());
            cells[exitDoor.position.y, exitDoor.position.x] = exitDoor;

            if (player.numberCurrentRoom != 0)
            {
                startDoor = new StartDoor(GenerateStartDoor());
                cells[startDoor.position.y, startDoor.position.x] = startDoor;
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
        /// Обнавление карты после действия
        /// </summary>
        public void CopyCells()
        {
            currentCells = new IMapObject[cells.GetLength(0), cells.GetLength(1)];
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    currentCells[i, j] = cells[i, j];
                }
            }
        }

        public void AddToFill(IMapObject mapObject)
        {
            objectsOnMap.Add(mapObject);
        }

        public void RemoveFillObject(IMapObject mapObject)
        {
            objectsOnMap.Remove(mapObject);
        }

        public void FillMap()
        {
            foreach (IMapObject mapObject in objectsOnMap)
            {
                if (mapObject != null)
                {
                    currentCells[mapObject.position.y, mapObject.position.x] = mapObject;
                }
                else
                {
                    RemoveFillObject(mapObject);
                }
            }
        }

        public void ClearFill()
        {
            objectsOnMap.Clear();
        }

    }
}
