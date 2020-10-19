using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_17
{
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 30;
            int[] integerArray = new int[arraySize];
            Random rand = new Random();

            for (int i = 0; i < arraySize; i++)
            {
                integerArray[i] = rand.Next(100, 1000);
            }

            Console.WriteLine("Исходный массив");
            Console.WriteLine();

            foreach (int i in integerArray)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine("\n");

            Console.WriteLine("Локальные максимумы");

            switch (integerArray.Length)
            {
                case 0:
                case 1:
                    Console.WriteLine("Длины массива недостаточно для определения локальных максимумов");
                    break;
                default:
                    if (integerArray[0] >= integerArray[1])
                    {
                        Console.Write(integerArray[0] + " ");
                    }
                    for (int i = 1; i < integerArray.Length - 1; i++)
                    {
                        if (integerArray[i] >= integerArray[i - 1] && integerArray[i] >= integerArray[i + 1])
                        {
                            Console.Write(integerArray[i] + " ");
                        }
                    }
                    if (integerArray[integerArray.Length - 1] >= integerArray[integerArray.Length - 2])
                    {
                        Console.WriteLine(integerArray[integerArray.Length - 1]);
                    }
                    break;
            }
            Console.WriteLine("\n");
        }
    }
}