using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class BaseTrap
    {
        public Point position { get; set; } = new Point();

        public abstract void OnTap();
    }
}
