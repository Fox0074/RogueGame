using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeGame
{
    class MapConteiner : IMapObject
    {
        public List<IInventoryObject> items = new List<IInventoryObject>();

        public Point position { get; set; }
        public string viewSymbol { get; set; } = "I";
        public ConsoleColor symbolColor { get; set; } = ConsoleColor.DarkRed;
        public bool barrier { get; set; } = false;
        public Action<IMapObject> OnTapAction { get; set; }
        public string name { get; set; } = "Рюкзак";

        public MapConteiner(List<IInventoryObject> items, Point position)
        {
            this.position = position;

            this.items.AddRange(items);

            OnTapAction += OnTap;
        }

        private void OnTap(IMapObject @object)
        {
            var player = (@object as Player);

            if (player != null)
            {
                player.inventory.AddItems(items);
                items.Clear();
                DungeonRoom.currentDungeonRoom.RemoveFillObject(this);
            }
        }
    }
}
