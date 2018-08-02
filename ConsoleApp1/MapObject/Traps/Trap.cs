using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Trap : BaseTrap, IMapObject
    {
        public string viewSymbol { get; set; }
        public ConsoleColor symbolColor { get; set; }
        public bool barrier { get; set; }
        public Action OnTapAction { get; set; }

        private bool isActivate = true;

        public Trap(Point position)
        {
            symbolColor = ConsoleColor.Blue;
            viewSymbol = "^";
            barrier = false;
            OnTapAction += Activate;
            this.position = position;
        }

        //TODO: убрать костыль, заменить player на IDestroyable
        public override void Activate()
        {
            if (isActivate)
            {
                Variables.player.healtPoint -= 10;
                isActivate = false;
                symbolColor = ConsoleColor.White;
            }
        }
    }
}
