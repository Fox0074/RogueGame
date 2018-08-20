using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeGame
{
    public class Trap : BaseTrap, IMapObject
    {
        public string viewSymbol { get; set; }
        public ConsoleColor symbolColor { get; set; }
        public bool barrier { get; set; }
        public Action<IMapObject> OnTapAction { get; set; }

        private bool isActivate = true;

        public Trap(Point position)
        {
            symbolColor = ConsoleColor.Blue;
            viewSymbol = "^";
            barrier = false;
            OnTapAction += OnTap;
            this.position = position;
        }

        //TODO: убрать костыль, заменить player на IDestroyable
        public override void OnTap(IMapObject obj)
        {
            var mapObject = obj as IDestroy;
            if (isActivate && mapObject != null)
            {
                mapObject.SetDamage(10);
                isActivate = false;
                symbolColor = ConsoleColor.White;

                EventLog.doEvent("Игрок: наступил на ловушку", ConsoleColor.DarkRed);
            }
        }
    }
}
