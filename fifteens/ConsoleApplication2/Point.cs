using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteens
{
    class ValueCoordiante
    {
        public int X;
        public int Y;

        public ValueCoordiante(int x, int y)
        {
            this.X = x;
            this.Y = y;         
        }

        public static double operator -(ValueCoordiante a, ValueCoordiante b)
        {
            return Math.Sqrt(Math.Pow(a.Y - b.Y, 2) + Math.Pow(a.X - b.X, 2));
        }
    }
}
