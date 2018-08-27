﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RogueLikeGame.Variables;

namespace RogueLikeGame
{
    class DrawInventoryScreen
    {
        private static int playerImageWidth;
        private static int playerImageHeight;

        private static int playerStatInfoWidth;
        private static int playerStatInfoHeight;

        private static int inventoryWidth;
        private static int inventorHeight;

        private static int areaWidth;
        private static int areaHeight;

        public static void ViewInventory()
        {

            areaWidth = (Console.WindowWidth - 2);
            areaHeight = (Console.WindowHeight);

            playerImageWidth = areaWidth / 5 * 2;
            playerImageHeight = areaHeight / 5 * 3;

            inventoryWidth = areaWidth / 10 * 7;
            inventorHeight = playerImageHeight;

            playerStatInfoWidth = inventoryWidth;
            playerStatInfoHeight = areaHeight;

            Console.Clear();

            DrawLines();

            DrawInventory();
        }

        private static void DrawLines()
        {
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < playerImageHeight; i ++)
            {
                Console.SetCursorPosition(playerImageWidth, i);
                Console.Write('|');
            }

            for (int i = 0; i < playerStatInfoWidth; i++)
            {
                Console.SetCursorPosition(i, playerImageHeight);
                Console.Write('-');
            }

            for (int i = 0; i < playerStatInfoHeight; i++)
            {
                Console.SetCursorPosition(playerStatInfoWidth, i);
                Console.Write('|');
            }

        }

        private static void DrawInventory()
        {
            int x = 0;

            Console.SetCursorPosition(playerImageWidth + 2, 1);

            //TODO: Табуляция с выводом
            for (var i = 0; i < player.inventory.items.Count(); i++)
            {
                if (x == Inventory.column)
                {
                    Console.SetCursorPosition(playerImageWidth + 2, Console.CursorTop + 1);
                    x = 0;
                }
                if (i == player.inventory.insertPosition)
                {
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write("[" + player.inventory.items[i].symbol + "]");

                    //Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop);
                }
                else
                {
                    Console.Write(player.inventory.items[i].symbol + " ");
                }

                x++;
            }
        }
    }
}
