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
            maxValue = DefineBorders(10, 50);

            Console.Write("Введите наполненность бара (в %) (не менее 1 и не более 100): ");
            percent = DefineBorders(1, 100);

            Console.Write("Введите позицию по вертикали (не менее 5 и не более 20): ");
            positionY = DefineBorders(5, 20);

            Console.Write("Введите позицию по горизонтали (не менее 0 и не более 20): ");
            positionX = DefineBorders(0, 20);

            DrawBar(maxValue, percent, positionX, positionY);
            Console.WriteLine();
        }

        static void DrawBar(int maxValue, int percent, int positionX, int positionY)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            string bar = "";
            int restriction;

            Console.CursorVisible = false;
            Console.SetCursorPosition(positionX, positionY);
            Console.Write("[");
            Console.BackgroundColor = ConsoleColor.Red;

            restriction = Convert.ToInt32(Math.Round(Convert.ToDecimal(maxValue) / 100M * percent));
            for (int i = 0; i < restriction; i++)
            {
                bar += " ";
            }

            Console.Write(bar);
            bar = "";
            Console.BackgroundColor = defaultColor;

            for (int i = restriction; i < maxValue; i++)
            {
                bar += "_";
            }

            Console.Write(bar);
            Console.Write("]");
        }

        static int DefineBorders(int minValue, int maxValue)
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