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
        public static Player player = new Player();
        public static List<DungeonRoom> rooms = new List<DungeonRoom>();

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
        }
        

        static void Main()
        {
            Initialization();

            while (true)
            {
                rooms[player.numberCurrentRoom].ViewRoom();

                KeybordCommand.DistributeCommand(Console.ReadKey().Key);
            }
        }
    }
}
