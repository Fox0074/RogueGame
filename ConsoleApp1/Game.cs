﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Variables;
namespace ConsoleApp1
{
    class Game
    {
        static public Action Step = delegate { };

        static public void Initialization()
        {
            Variables.rooms.Clear();

             var randomSizeRoom = new Random();

            player = new Player();
            rooms.Add(new DungeonRoom(
                randomSizeRoom.Next(6, 21),
                randomSizeRoom.Next(6, 21)
                ));

            DungeonRoom.currentDungeonRoom = rooms[0];

            DungeonRoom.currentDungeonRoom.AddToFill(new Trap(new Point(2,4)));

            DungeonRoom.currentDungeonRoom.AddToFill(player);

            player.numberCurrentRoom = rooms.IndexOf(DungeonRoom.currentDungeonRoom);       
            player.position = new Point(
                (DungeonRoom.currentDungeonRoom.currentCells.GetLength(0) - 1)/2,
                (DungeonRoom.currentDungeonRoom.currentCells.GetLength(1) - 1)/2);


            Console.CursorVisible = false;            
        }        

        static void Main()
        {
            
            Initialization();

            while (true)
            {
                ClearMap();
                FillMap();
                ViewOnConsole.View("game");
                KeybordCommand.DistributeCommand(Console.ReadKey().Key);
                //GameReaction();
                Step.Invoke();

                //TODO: переделать
                DungeonRoom.currentDungeonRoom.roomNextSteep.Invoke();

            }
        }

        private static void ClearMap()
        {
            DungeonRoom.currentDungeonRoom.CopyCells();
        }

        private static void FillMap()
        {
            DungeonRoom.currentDungeonRoom.FillMap();
        }
    }
}
