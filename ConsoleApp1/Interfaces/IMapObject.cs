using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IMapObject
    {
        Point position { get; set; }
        string viewSymbol { get; set; }
        ConsoleColor symbolColor { get; set; }
        bool barrier { get; set; }
        Action OnTapAction { get; set; }        
    }
}
