using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class LevelGenerator
    {
        public IDifficultsGenerator difficultGenerator = new NormalDifficult();

        public void CreateFillRoom(DungeonRoom room)
        {
            difficultGenerator.CreateObjects(room);
        }
    }
}
