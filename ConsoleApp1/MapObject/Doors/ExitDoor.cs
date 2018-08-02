﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Variables;

namespace ConsoleApp1
{
    class ExitDoor : BaseDoor,IMapObject
    {
        public string viewSymbol { get; set; }
        public bool barrier { get; set; }
        public Action OnTapAction { get; set; }
        public ConsoleColor symbolColor { get; set; }

        public ExitDoor(Point position)
        {
            viewSymbol = "@";
            symbolColor = ConsoleColor.DarkRed;
            barrier = true;
            OnTapAction += OnTap;
            this.position = position;
        }

        public void OnTap()
        {
            var randomSizeRoom = new Random();

            player.numberCurrentRoom++;           

            if (player.numberCurrentRoom > rooms.Count - 1)
            {

                rooms.Add(new DungeonRoom(
                    randomSizeRoom.Next(6, 21),
                    randomSizeRoom.Next(6, 21)));
            }

            DungeonRoom.currentDungeonRoom.RemoveFillObject(player);
            DungeonRoom.currentDungeonRoom = rooms[player.numberCurrentRoom];
            DungeonRoom.currentDungeonRoom.AddToFill(player);

            player.position = DungeonRoom.currentDungeonRoom.startDoor.CheckDoor(DungeonRoom.currentDungeonRoom.currentCells);

            EventLog.doEvent("Игрок: перешел в " + (player.numberCurrentRoom + 1) + " комнату", ConsoleColor.DarkGreen);
        }
    }
}
