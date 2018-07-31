using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static Player player = new Player();
        public static List<DungeonRoom> rooms = new List<DungeonRoom>();

        static void Main()
        {
            player.numberCurrentRoom = 0;

            var randomSizeRoom = new Random();

            rooms.Add(new DungeonRoom(
                randomSizeRoom.Next(6, 21),
                randomSizeRoom.Next(6, 21),
                1, 1
                ));

            player.numberCurrentRoom = 0;

            while (true)
            {
                rooms[player.numberCurrentRoom].ViewRoom();

                KeybordCommand.DistributeCommand(Console.ReadKey().Key);
            }
        }
    }
}
