using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Coordinate
    {
        int x;
        int y;
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public Coordinate(int i, int j)
        {
            x = i;
            y = j;
        }
    }
}

