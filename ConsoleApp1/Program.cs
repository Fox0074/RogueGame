using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Global;
namespace ConsoleApp1
{
    class Program
    {        
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
                (rooms[0].currentCells.GetLength(0) - 1)/2,
                (rooms[0].currentCells.GetLength(1) - 1)/2);

            rooms[0].currentCells[player.position.y, player.position.x] = player;

            Console.CursorVisible = false;
        }
        

        static void Main()
        {
            Initialization();

            while (true)
            {
                ViewOnConsole.ViewGame();

                KeybordCommand.DistributeCommand(Console.ReadKey().Key);
            }
        }
    }
}
