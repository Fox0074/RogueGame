using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DungeonRoom
    {
        private string[,] cells { get; set; }
		public string[,] currentCells { get; set;}
        //private int playerXCoordinate { get; set; }
        //private int playerYCoordinate { get; set; }

        public DungeonRoom(int height, int width, 
            int playerXCoordinate, int playerYCoordinate)
        {
            currentCells = new string[height, width];
            cells = new string[height, width];

            for (int i = 0; i < height; i++)
            {
                cells[i, 0] = "#";

                cells[i, width - 1] = "#";
            }

            for (int i = 0; i < width; i++)
            {
                cells[0, i] = "#"; 

                cells[height - 1, i] = "#";        
            }
           
            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {
                    cells[i, j] = "@";
                }
            }

            CopyCells();

            Program.player.XCoordinate = playerXCoordinate;
            Program.player.YCoordinate = playerYCoordinate;

            currentCells[playerXCoordinate, playerYCoordinate] = "P";

            //this.playerXCoordinate = playerXCoordinate;
            //this.playerYCoordinate = playerYCoordinate;
        }

        public void ViewRoom()
        {
            
            for (int i = 0; i < currentCells.GetLength(0); i++)
            {
                for (int j = 0; j < currentCells.GetLength(1); j++)
                {
                    Console.Write(currentCells[i, j] + " ");
                }
                Console.WriteLine();              
            }

            CopyCells();
        }

        private void CopyCells()
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    currentCells[i, j] = cells[i, j];
                }
            }
        }


		/*
        public void PlayerLocation(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (playerYCoordinate - 1 > 0)
                    {
                        cells[playerYCoordinate, playerXCoordinate] = "@";
                        playerYCoordinate--;
                        cells[playerYCoordinate, playerXCoordinate] = "P";
                    }
                    break;

                case ConsoleKey.DownArrow:
                    if (playerYCoordinate + 1 < cells.GetLength(0) - 1)
                    {
                        cells[playerYCoordinate, playerXCoordinate] = "@";
                        playerYCoordinate++;
                        cells[playerYCoordinate, playerXCoordinate] = "P";
                    }
                    break;

                case ConsoleKey.RightArrow:
                    if (playerXCoordinate + 1 < cells.GetLength(1) - 1)
                    {
                        cells[playerYCoordinate, playerXCoordinate] = "@";
                        playerXCoordinate++;
                        cells[playerYCoordinate, playerXCoordinate] = "P";
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (playerXCoordinate - 1 > 0)
                    {
                        cells[playerYCoordinate, playerXCoordinate] = "@";
                        playerXCoordinate--;
                        cells[playerYCoordinate, playerXCoordinate] = "P";
                    }
                    break;
            }			
        }
		*/
    }
}
