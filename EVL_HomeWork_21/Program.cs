using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_21
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Вы ввели целое число со значением: {ReadAnInteger()}");
            Console.WriteLine();

        }
        static int ReadAnInteger()
        {
            string lineEntered = "";
            bool exit = false;
            int value = 0;

            while (!exit)
            {
                Console.Write("Введите ЦЕЛОЕ число: ");
                lineEntered = Console.ReadLine();
                if (int.TryParse(lineEntered, out value))
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ОШИБКА ввода");
                    Console.WriteLine();
                }
            }
            return value;
        }
    }
}
