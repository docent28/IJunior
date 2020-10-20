using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_23
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberPatternMembers;
            Random rand = new Random();
            int[] arrayNumbers;

            Console.Write("Введите количество элементов в одномерном массиве: ");
            numberPatternMembers = Convert.ToInt32(Console.ReadLine());
            arrayNumbers = new int[numberPatternMembers];

            for (int i = 0; i < numberPatternMembers; i++)
            {
                arrayNumbers[i] = rand.Next(100, 1000);
            }

            Console.WriteLine();
            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                Console.Write(arrayNumbers[i] + " ");
            }

            Shuffle(arrayNumbers);

            Console.WriteLine("\n");
            Console.WriteLine("Перемешанный массив:");
            for (int i = 0; i < arrayNumbers.Length; i++)
            {
                Console.Write(arrayNumbers[i] + " ");
            }
            Console.WriteLine("\n");
        }

        static void Shuffle(int[] arrayNumbers)
        {
            Random rand = new Random();
            for (int i = arrayNumbers.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(0, i + 1);
                int tmp = arrayNumbers[j];
                arrayNumbers[j] = arrayNumbers[i];
                arrayNumbers[i] = tmp;
            }
        }
    }
}
