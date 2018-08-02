using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class FillMap
    {
        private List<IMapObject> objectsOnMap = new List<IMapObject>();

        public void AddObject(IMapObject mapObject)
        {
            objectsOnMap.Add(mapObject);
        }

        public void RemoveObject(IMapObject mapObject)
        {
            objectsOnMap.Remove(mapObject);
        }

        public void Fill()
        {
            foreach (IMapObject mapObject in objectsOnMap)
            {
                DungeonRoom.currentCells[mapObject.position.y, mapObject.position.x] = mapObject;
            }
        }

        public void ClearFill()
        {
            objectsOnMap.Clear();
        }
    }
}
