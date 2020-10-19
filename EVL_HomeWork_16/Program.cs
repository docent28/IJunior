using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_16
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[10, 10];
            Random rand = new Random();
            int maxElement = Int32.MinValue;
            string coordinates = string.Empty;
            string[] cell;

            Console.SetCursorPosition(0, 2);
            Console.WriteLine("Исходная матрица");
            Console.WriteLine();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rand.Next(100, 1000);
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > maxElement)
                    {
                        maxElement = matrix[i, j];
                        coordinates = i + " " + j + " ";
                    }
                    else if (matrix[i, j] == maxElement)
                    {
                        coordinates += i + " " + j + " ";
                    }
                }
            }

            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Максимальный элемент матрицы равен " + maxElement);

            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Измененная матрица");
            Console.WriteLine();

            cell = coordinates.Split(new char[] { ' ' });
            for (int i = 0; i < cell.Length / 2; i = i + 2)
            {
                matrix[Convert.ToInt32(cell[i]), Convert.ToInt32(cell[i + 1])] = 0;
            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{Convert.ToString(matrix[i, j]),3:N0}" + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.SetCursorPosition(0, 28);
        }
    }
}