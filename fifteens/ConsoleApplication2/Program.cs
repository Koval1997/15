using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteens
{
    class Program
    {
        static void Main(string[] args)
        {
            //Game field = new Game(0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
            //int a = field.Dictionary[1].Y;
            //field.Shift(1);
            //int b = field.Dictionary[1].Y;
            //Console.WriteLine(a);
            //Console.WriteLine(b);

            Game.FromCSV("input.csv");
        }
    }
}
