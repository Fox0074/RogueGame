using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeGame
{
    public class Inventory
    {
        public const int column = 5;

        private int _mInsertPosition = 0;
        public int insertPosition { get { return _mInsertPosition; } set { _mInsertPosition = SetInsertPosition(value); } }
        public List<IInventoryObject> items { get; set; } = new List<IInventoryObject>();

        //TODO: Переписать для движение вниз и верх
        private int SetInsertPosition(int value)
        {
            if (value <= 0)
            {
                value = 0;
            }

            if (value >= items.Count-1)
            {
                value = items.Count - 1;
            }
            return value;
        }

        public void AddItems(List<IInventoryObject> addingItems)
        {
            items.AddRange(addingItems);
        }

        public void MoveInventory(direction direction)
        {
            switch (direction)
            {
                case direction.up:
                    insertPosition -= column;
                    break;
                case direction.down:
                    insertPosition += column;
                    break;
                case direction.right:
                    insertPosition++;
                    break;
                case direction.left:
                    insertPosition--;
                    break;
            }
        }
    }
}
