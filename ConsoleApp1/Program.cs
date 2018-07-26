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

        static void Main()
        {
            int roomNumber = 1;

            var room = new DungeonRoom(10, 10, 1, 1);

            player.room = room;

            while (true)
            {
                Console.Clear();

                room.ViewRoom();

                //room.RefreshCells();

                KeybordCommand.DistributeCommand(Console.ReadKey().Key);
            }
        }
    }
}
