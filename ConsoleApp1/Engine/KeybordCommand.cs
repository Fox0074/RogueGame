using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RogueLikeGame.Variables;

namespace RogueLikeGame
{
    static class KeybordCommand
    {
        static public void DistrubuteCommand()
        {
            var key = Console.ReadKey().Key;

            switch (gameState)
            {
                case GameState.game:
                    GameCommand(key);
                    break;

                case GameState.inventory:
                    InventoryCommand(key);
                    break;
            }

        }

        static private void GameCommand(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    ActionControl.MoveCommand(direction.up);
                    break;
                case ConsoleKey.DownArrow:
                    ActionControl.MoveCommand(direction.down);
                    break;
                case ConsoleKey.RightArrow:
                    ActionControl.MoveCommand(direction.right);
                    break;
                case ConsoleKey.LeftArrow:
                    ActionControl.MoveCommand(direction.left);
                    break;

                case ConsoleKey.I:
                    gameState = GameState.inventory;
                    ViewOnConsole.View(gameState);
                    break;

            }
        }
        static private void InventoryCommand(ConsoleKey key)
        {

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    player.inventory.MoveInventory(direction.up);
                    break;
                case ConsoleKey.DownArrow:
                    player.inventory.MoveInventory(direction.down);
                    break;
                case ConsoleKey.RightArrow:
                    player.inventory.MoveInventory(direction.right);
                    break;
                case ConsoleKey.LeftArrow:
                    player.inventory.MoveInventory(direction.left);
                    break;
                case ConsoleKey.Enter:
                    player.inventory.items[player.inventory.insertPosition].Use();
                    break;
                case ConsoleKey.I:
                    gameState = GameState.game;
                    ViewOnConsole.View(gameState);
                    break;

            }
        }

    }

    #region Действия
    public enum direction
    {
        down,
        left,
        up,
        right
    }
    #endregion

}
