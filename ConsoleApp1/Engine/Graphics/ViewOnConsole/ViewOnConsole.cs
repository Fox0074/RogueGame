using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RogueLikeGame.Variables;

namespace RogueLikeGame
{
    public static class ViewOnConsole
    {
        
        public static void View(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.game:
                    DrawGameScreen.ViewGame();
                    break;
                case GameState.inventory:
                    DrawInventoryScreen.ViewInventory();
                    break;               
            }
        }        
    }
}
