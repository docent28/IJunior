using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_11
{
    class Program
    {
        static void Main(string[] args)
        {
            int initialValue = 7;
            int finalValue = 98;

            for (int i = initialValue; i <= finalValue; i += 7)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("");
        }
    }
}
