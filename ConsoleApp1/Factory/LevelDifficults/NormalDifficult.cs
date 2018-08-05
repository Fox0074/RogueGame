using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class NormalDifficult : IDifficultsGenerator
    {
        private Random random = new Random();

        public void CreateObjects(DungeonRoom room)
        {
            var area = (room.currentCells.GetLength(0)-2) * (room.currentCells.GetLength(1)-2);

            for (int i = 0; i<= area; i += 50)
            {
                var checkingPosition = new Point(
                                        random.Next(1, room.currentCells.GetLength(0) - 2),
                                        random.Next(1, room.currentCells.GetLength(1) - 2)
                                        );

                while (room.currentCells[checkingPosition.y, checkingPosition.x].GetType() != typeof(EmptyFloor))
                {
                    checkingPosition = new Point(
                                        random.Next(1, room.currentCells.GetLength(0) - 2),
                                        random.Next(1, room.currentCells.GetLength(1) - 2)
                                        );
                }

                var enemy = new Dwarf(checkingPosition, 90, 0, new BaseWeapon());
                room.roomNextSteep += enemy.CheckPlayer;
                room.AddToFill(enemy);

            }
        }
    }
}
