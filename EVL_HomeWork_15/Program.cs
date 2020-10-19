using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_15
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] numbers = new int[7, 10];
            Random rand = new Random();
            int lineNumber = 2;
            int columnNumber = 1;
            int lineAmount = 0;
            double columnMultiplication = 1;


            Console.WriteLine("Исходная матрица");
            Console.WriteLine();
            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    numbers[i, j] = rand.Next(10, 100);
                    Console.Write(numbers[i, j] + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < numbers.GetLength(1); i++)
            {
                lineAmount += numbers[lineNumber - 1, i];
            }

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                columnMultiplication *= numbers[i, columnNumber - 1];
            }

            Console.WriteLine();
            Console.WriteLine($"Сумма элементов строки номер {lineNumber} равна - {lineAmount}");
            Console.WriteLine($"Произведение элементов столбца номер {columnNumber} равна - {columnMultiplication}");
            Console.WriteLine();
        }
    }
}