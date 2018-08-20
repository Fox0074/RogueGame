using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Variables;

namespace ConsoleApp1
{
    public static class ViewOnConsole
    {

        static int areaWidth;
        static int areaHeight;
        
        public static void ViewGame()
        {
            areaWidth = (Console.WindowWidth - 2) / 2;
            areaHeight = 7 * (Console.WindowHeight - 2) / 10;

            DrawScreen();

            Console.SetCursorPosition(0, 0);
        }

        private static void DrawScreen()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < areaHeight; i++)
            {
                Console.SetCursorPosition(areaWidth, i);
                Console.Write('|');
            }

            Console.SetCursorPosition(0, areaHeight);

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write('-');
            }

            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < DungeonRoom.currentDungeonRoom.currentCells.GetLength(0); i++)
            {
                for (int j = 0; j < DungeonRoom.currentDungeonRoom.currentCells.GetLength(1); j++)
                {
                    Console.ForegroundColor = DungeonRoom.currentDungeonRoom.currentCells[i, j].symbolColor;                    
                    Console.Write(DungeonRoom.currentDungeonRoom.currentCells[i,j].viewSymbol + " ");
                }
                Console.WriteLine();
            }

            DrawUI();

            List<LogObject> logArea = EventLog.GetLastLog();
            Console.SetCursorPosition(0, areaHeight + 1);
            foreach (LogObject message in logArea)
            {
                Console.ForegroundColor = message.color;
                Console.WriteLine(message.message);
            }
        }

        /// <summary>
        /// Вывод пользовательского интерфейса
        /// </summary>
        private static void DrawUI( )
        {
            Console.SetCursorPosition(areaWidth + 1, 0);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Здоровье: " + UserInterface.player.healtPoint);

            Console.SetCursorPosition(areaWidth + 1, 2);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Текущая комната: " + (UserInterface.player.numberCurrentRoom+1) + 
                " из " + rooms.Count());
        }

        static public void ViewInventory()
        {
            Console.Clear();
            Console.WriteLine("Kek");
        }
    }
}
