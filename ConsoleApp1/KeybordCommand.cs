using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class KeybordCommand
    {
        public enum direction { down, left, up, right }

        static public void DistributeCommand(ConsoleKey key)
        {
                    
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    MoveCommand(direction.up);
                    break;
                case ConsoleKey.DownArrow:
                    MoveCommand(direction.down);
                    break;
                case ConsoleKey.RightArrow:
                    MoveCommand(direction.right);
                    break;
                case ConsoleKey.LeftArrow:
                    MoveCommand(direction.left);
                    break;

                case ConsoleKey.I:
                    break;

            }
        }

		static public void MoveCommand(direction move)
		{
			switch (move)
            {
                case direction.up:
                    if (Program.player.YCoordinate - 1 > 0)
                    {
                        Program.player.YCoordinate--;
                    }
                    break;

                case direction.down:
                    if (Program.player.YCoordinate + 1 < Program.player.room.currentCells.GetLength(0) - 1)
                    {
                        Program.player.YCoordinate++;
                    }
                    break;

                case direction.right:
                    if (Program.player.XCoordinate + 1 < Program.player.room.currentCells.GetLength(1) - 1)
                    {
                        Program.player.XCoordinate++;
                    }
                    break;

                case direction.left:
                    if (Program.player.XCoordinate - 1 > 0)
                    {
                        Program.player.XCoordinate--;
                    }
                    break;
            }
            Program.player.room.currentCells[Program.player.YCoordinate, Program.player.XCoordinate] = "P";
        }		
    }
}
