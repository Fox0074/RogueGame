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

        static public void Initialization()
        {
             var randomSizeRoom = new Random();

            rooms.Add(new DungeonRoom(
                randomSizeRoom.Next(6, 21),
                randomSizeRoom.Next(6, 21)
                ));

            player.numberCurrentRoom = 0;

            player.numberCurrentRoom = 0;
            player.position = new Point(
                (DungeonRoom.currentCells.GetLength(0) - 1)/2,
                (DungeonRoom.currentCells.GetLength(1) - 1)/2);

            DungeonRoom.currentCells[player.position.y, player.position.x] = player;

            Console.CursorVisible = false;
        }
        

        static void Main()
        {
            Initialization();

            while (true)
            {
                ViewOnConsole.ViewGame();
                Step.Invoke();
                KeybordCommand.DistributeCommand(Console.ReadKey().Key);             
            }
        }
    }
}
