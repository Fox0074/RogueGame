using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class TestEnemy : Enemy
    {
        public TestEnemy(Point position) : base(position)
        {
            name = "Тестовый противник";
        }
    }
}
