using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class NormalDifficult : IDifficultsGenerator
    {
        private Random random = new Random();       
        private enum enemy { Elf, Skeleton };


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


                //var enemy = new Dwarf(checkingPosition, 90, 0, new BaseWeapon());
                var enemy = new Dwarf(checkingPosition);

                room.roomNextSteep += enemy.CheckPlayer;
                room.AddToFill(enemy);


                //Здесь я смог создать обьект класса, но вызвать его методы я пока не смог
                Type TestType = Type.GetType("ConsoleApp1.Dwarf");
                ConstructorInfo ci = TestType.GetConstructor(new Type[] { typeof(Point) });
                object Obj = ci.Invoke(new object[] { new Point(1, 1) });
                Console.WriteLine("AAAAAAAAAAAAAAAAAAAA" + Obj.GetType());


                //TODO: Здесь вроде как создание обьекта динамического класса     
                //object[] ctorArgs = { 10, 10, 100, 100 };
                //Assembly assembly = Assembly.LoadWithPartialName("System.Drawing");
                //Object rect = Activator.CreateInstance(assembly.FullName
                //    , "System.Drawing.Rectangle"
                //    , false// ignoreCase, учитывать регистр!
                //    , 0, null// по умолчанию
                //    , ctorArgs         // вот они - параметры!
                //    , null, null, null// всё остальное тоже по умолчанию
                //    )

            }
        }
    }
}
