using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Variables;
namespace ConsoleApp1
{
    class Game
    {
        static public Action Step = delegate { };
        static public FillMap filling = new FillMap();

        static public void Initialization()
        {
             var randomSizeRoom = new Random();

            player = new Player();
            rooms.Add(new DungeonRoom(
                randomSizeRoom.Next(6, 21),
                randomSizeRoom.Next(6, 21)
                ));

            DungeonRoom.currentCells = rooms[0].GetCells();

            filling.AddObject(player);

            player.numberCurrentRoom = 0;       
            player.position = new Point(
                (DungeonRoom.currentCells.GetLength(0) - 1)/2,
                (DungeonRoom.currentCells.GetLength(1) - 1)/2);


            Console.CursorVisible = false;            
        }        

        static void Main()
        {
            
            Initialization();

            while (true)
            {
                ClearMap();
                filling.Fill();
                ViewOnConsole.ViewGame();               
                KeybordCommand.DistributeCommand(Console.ReadKey().Key);
                //GameReaction();
                Step.Invoke();
            }
        }

        private static void ClearMap()
        {
            rooms[player.numberCurrentRoom].CopyCells();
        }
    }
}
