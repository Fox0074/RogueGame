using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RogueLikeGame.Variables;

namespace RogueLikeGame
{
    class DrawGameScreen
    {
        private static int areaWidth;
        private static int areaHeight;

        public static void ViewGame()
        {
            DungeonRoom.currentDungeonRoom.CopyCells();

            DungeonRoom.currentDungeonRoom.FillMap();

            areaWidth = (Console.WindowWidth - 2) / 2;
            areaHeight = 7 * (Console.WindowHeight - 2) / 10;

            Console.Clear();

            DrawLines();

            DrawDungeon();

            DrawUI();

            DrawActionLog();

            Console.SetCursorPosition(0, 0);
        }

        private static void DrawLines()
        {
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
        }

        private static void DrawDungeon()
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < DungeonRoom.currentDungeonRoom.currentCells.GetLength(0); i++)
            {
                for (int j = 0; j < DungeonRoom.currentDungeonRoom.currentCells.GetLength(1); j++)
                {
                    Console.ForegroundColor = DungeonRoom.currentDungeonRoom.currentCells[i, j].symbolColor;
                    Console.Write(DungeonRoom.currentDungeonRoom.currentCells[i, j].viewSymbol + " ");
                }
                Console.WriteLine();
            }
        }

        private static void DrawUI()
        {
            Console.SetCursorPosition(areaWidth + 1, 0);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Здоровье: " + UserInterface.player.currentHealtPoint + "/" + UserInterface.player.maxHealthPoint);

            Console.SetCursorPosition(areaWidth + 1, 2);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Уровень: " + UserInterface.player.level.level);

            Console.SetCursorPosition(areaWidth + 1, 3);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Опыт: " + UserInterface.player.level.currentExperience + "/" + UserInterface.player.level.maxExperience);

            Console.SetCursorPosition(areaWidth + 1, 5);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Текущая комната: " + (UserInterface.player.numberCurrentRoom + 1) +
                " из " + rooms.Count());
        } 

        private static void DrawActionLog()
        {
            List<LogObject> logArea = EventLog.GetLastLog();
            Console.SetCursorPosition(0, areaHeight + 1);
            foreach (LogObject message in logArea)
            {
                Console.ForegroundColor = message.color;
                Console.WriteLine(message.message);
            }
        }

    }
}
