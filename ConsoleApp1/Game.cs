using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static RogueLikeGame.Variables;
namespace RogueLikeGame
{
    public enum GameState { game, inventory };

    class Game
    {
        static public Action Step = delegate { };

        static public void Initialization()
        {
            rooms.Clear();

             var randomSizeRoom = new Random();

            player = new Player();

            rooms.Add(LevelGenerator.CreateFillRoom());

            DungeonRoom.currentDungeonRoom = rooms[0];

            //DungeonRoom.currentDungeonRoom.AddToFill(new Trap(new Point(2,4)));
            DungeonRoom.currentDungeonRoom.AddToFill(player);

            player.numberCurrentRoom = rooms.IndexOf(DungeonRoom.currentDungeonRoom);       
            player.position = new Point(
                (DungeonRoom.currentDungeonRoom.currentCells.GetLength(0) - 1)/2,
                (DungeonRoom.currentDungeonRoom.currentCells.GetLength(1) - 1)/2);           

            Console.CursorVisible = false;
           
            //player.inventory.AddItems(new List<IInventoryObject> {new Sword(1,1), new Sword(1, 1), new Sword(1, 1), new Sword(1, 1), new Sword(1, 1), new Sword(1, 1), new Sword(1, 1), new Sword(1, 1), new Sword(1, 1), new Sword(1, 1), new Sword(1, 1), new HealPotion() });
        }        

        static void Main()
        {
            Initialization();

            while (true)
            {
                ViewOnConsole.View(gameState);               

                KeybordCommand.DistrubuteCommand();
          
                Step.Invoke();
            }
        }      
    }
}
