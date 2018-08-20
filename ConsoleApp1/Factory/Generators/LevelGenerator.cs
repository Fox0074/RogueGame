using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RogueLikeGame.Variables;

namespace RogueLikeGame
{
    static class LevelGenerator
    {
        public static IDifficultsGenerator difficultGenerator = new NormalDifficult();

        public static DungeonRoom CreateFillRoom()
        {
            var room = new DungeonRoom(
                random.Next(6, 21),
                random.Next(6, 21)
                );
            difficultGenerator.CreateObjects(room);

            return room;
        }
    }
}
