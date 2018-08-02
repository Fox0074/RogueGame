using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class UserInterface
    {
        public static Player player;
        //public static int roomsCount = new int();

        static UserInterface()
        {
            player = Variables.player;
            //roomsCount = Variables.rooms.Count();
        }
    }
}
