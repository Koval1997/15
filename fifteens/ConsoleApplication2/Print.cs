using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifteens
{
    class Print
    {
        public static void PrintInfo(Value[,] array, int Side)
        {
            Console.WriteLine("Поле после хода");
            for (int i = 0; i < Side; i++)
            {
                for (int j = 0; j < Side; j++)
                {
                    Console.Write("{0}\t", array[i, j].Number);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
