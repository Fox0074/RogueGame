using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeGame
{
    static class KeybordCommand
    {
        static public void DistrubuteCommand(GameState gameState)
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
                    ActionControl.ShowInventory();
                    break;

            }
        }
        static private void InventoryCommand(ConsoleKey key)
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
                    ActionControl.ShowInventory();
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
