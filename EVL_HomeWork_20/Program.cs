using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_20
{
    class Program
    {
        static void Main(string[] args)
        {
            int percent;
            int positionX;
            int positionY;
            int maxValue;

            Console.Write("Введите максимальную длину бара (не менее 10 и не более 50): ");
            maxValue = numberRange(10, 50);

            Console.Write("Введите наполненность бара (в %) (не менее 1 и не более 100): ");
            percent = numberRange(1, 100);

            Console.Write("Введите позицию по вертикали (не менее 5 и не более 20): ");
            positionY = numberRange(5, 20);

            Console.Write("Введите позицию по горизонтали (не менее 0 и не более 20): ");
            positionX = numberRange(0, 20);

            drawBar(maxValue, percent, positionX, positionY);
            Console.WriteLine();
        }

        static void drawBar(int maxValue, int percent, int positionX, int positionY)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            string bar = "";

            Console.CursorVisible = false;
            Console.SetCursorPosition(positionX, positionY);
            Console.Write("[");
            Console.BackgroundColor = ConsoleColor.Red;

            for (int i = 0; i < Math.Round(Convert.ToDecimal(maxValue) / 100M * percent); i++)
            {
                bar += " ";
            }

            Console.Write(bar);
            bar = "";
            Console.BackgroundColor = defaultColor;

            for (int i = Convert.ToInt32(Math.Round(Convert.ToDecimal(maxValue) / 100M * percent)); i < maxValue; i++)
            {
                bar += "_";
            }

            Console.Write(bar);
            Console.Write("]");
        }

        static int numberRange(int minValue, int maxValue)
        {
            bool exit = false;
            int value = -1;

            while (!exit)
            {
                value = Convert.ToInt32(Console.ReadLine());
                if (value >= minValue && value <= maxValue)
                {
                    exit = true;
                }
                else
                {
                    Console.Write($"Введите значение из диапазона от {minValue} до {maxValue}: ");
                }
            }

            return value;
        }
    }
}