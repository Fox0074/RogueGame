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
        static List<string> gameArea = new List<string>();
        static List<string> uiArea = new List<string>();
        static List<string> logArea = new List<string>();
        static int areaWidth = (Console.WindowWidth - 2) / 2; //50% игрового экрана
        static int areaHeight = 7 * (Console.WindowHeight - 2) / 10; //70% игрового экрана
      
        public static void ViewGame()
        {
            areaWidth = (Console.WindowWidth - 2) / 2;
            areaHeight = 7 * (Console.WindowHeight - 2) / 10;

            gameArea.Clear();
            uiArea.Clear();
            logArea.Clear();

            AddLineToBuffer(ref logArea, EventLog.GetLastLog());
            AddLineToBuffer(ref uiArea, "\tHealth: " + player.healtPoint.ToString());
            AddLineToBuffer(ref gameArea, rooms[player.numberCurrentRoom].GetRoom());

            DrawScreen();

            Console.SetCursorPosition(0, 0);
        }

        private static void DrawScreen()
        {
            Console.Clear();

            for (int i = 0; i < areaHeight; i++)
            {
                Console.SetCursorPosition(areaWidth, i);
                Console.Write('|');
            }

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, areaHeight);
                Console.Write('-');
            }

            int currentTab = 0;

            for (int i = 0; i < gameArea.Count; i++)
            {
                Console.SetCursorPosition(currentTab, i);
                Console.WriteLine(gameArea[i]);
            }

            currentTab = (areaWidth + 1);
            for (int i = 0; i < uiArea.Count; i++)
            {
                Console.SetCursorPosition(currentTab, i);
                Console.WriteLine(uiArea[i]);
            }
            for (int i = 0; i < logArea.Count; i++)
            {
                Console.SetCursorPosition(0, areaHeight + 1 + i);
                Console.WriteLine(logArea[i]);
            }
        }
        private static void AddLineToBuffer(ref List<string> areaBuffer, string line)
        {
            areaBuffer.Add(line);

            if (areaBuffer.Count == areaHeight)
            {
                areaBuffer.RemoveAt(areaWidth - 1);
            }
        }
        private static void AddLineToBuffer(ref List<string> areaBuffer, List<string> lines)
        {
            foreach (string line in lines)
            {
                areaBuffer.Add(line);

                while (areaBuffer.Count >= areaHeight)
                {
                    areaBuffer.RemoveAt(areaBuffer.Count-1);
                }
            }
        }

    }
}
