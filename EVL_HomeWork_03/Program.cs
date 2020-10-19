using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_03
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPictures = 52;
            int numRows;
            int numRemainingPictures;
            numRows = numPictures / 3;
            numRemainingPictures = numPictures % 3;
            Console.WriteLine($"Всего получилось {numRows} рядов");
            Console.WriteLine($"Осталось {numRemainingPictures} картинок");
        }
    }
}
