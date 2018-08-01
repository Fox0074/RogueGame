using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Global;

namespace ConsoleApp1
{
    public static class ViewOnConsole
    {
        public static void ViewGame()
        {
            rooms[player.numberCurrentRoom].ViewRoom();

            EventLog.ViewLog();
        }
       
    }
}
