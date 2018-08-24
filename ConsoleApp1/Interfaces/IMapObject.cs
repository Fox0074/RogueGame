﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeGame
{
    public interface IMapObject
    {
        Point position { get; set; }
        string viewSymbol { get; set; }
        ConsoleColor symbolColor { get; set; }
        bool barrier { get; set; }
        Action<IMapObject> OnTapAction { get; set; }

    }
}
