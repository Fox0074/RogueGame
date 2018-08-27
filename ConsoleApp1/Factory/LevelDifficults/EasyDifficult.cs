using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static RogueLikeGame.Variables;

namespace RogueLikeGame
{
    class EasyDifficult : IDifficultsGenerator
    {       
        private List<Type> enemyTypes = new List<Type> {
            typeof(Dwarf), typeof(Skeleton) };


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

                var enemyType = enemyTypes[(random.Next(0, enemyTypes.Count))];

                ConstructorInfo ci = enemyType.GetConstructor(new Type[] { typeof(Point) });
                object enemy = ci.Invoke(new object[] { checkingPosition });

                room.roomNextSteep += (enemy as BaseEnemy).CheckPlayer;
                room.AddToFill(enemy as BaseEnemy);


                //Создание обьекта динамического класса
                //var randomClassEnemy = ((enemy)random.Next(0, 2));
                //Type enemy = (enemy)random.Next(0,2).ToString().;
                //Type TestType = Type.GetType("ConsoleApp1.Dwarf");
                //TestType.get
                //ConstructorInfo ci = TestType.GetConstructor(new Type[] { typeof(Point) });
                //object Obj = ci.Invoke(new object[] { new Point(1, 1) });
                //Console.WriteLine("AAAAAAAAAAAAAAAAAAAA" + Obj.GetType());
                //(Obj as BaseEnemy).CheckPlayer();
            }
        }
    }
}
