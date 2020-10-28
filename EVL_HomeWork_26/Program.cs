using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_26
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endInput = false;
            string enteredData;
            List<double> numbers = new List<double>();
            double sumNumbers;
            double anotherNumber;

            Console.WriteLine("ИНСТРУКЦИЯ");
            Console.WriteLine("Вы можете вводить числа. Если число дробное, то разделитель целой и дробной частей - запятая");
            Console.WriteLine("sum - подсчет и вывод суммы всех введенных чисел");
            Console.WriteLine("exit - выход из программы");
            Console.WriteLine();

            while (!endInput)
            {
                Console.Write("Введите или число или одно из ключевых слов: ");
                enteredData = Console.ReadLine();

                switch (enteredData)
                {
                    case "sum":
                        sumNumbers = numbers.Sum();
                        Console.WriteLine();
                        Console.Write("Сумма всех введенных чисел равна: " + sumNumbers);
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    case "exit":
                        endInput = true;
                        Console.WriteLine();
                        Console.WriteLine("Программа закончила работу");
                        break;
                    default:
                        if (double.TryParse(enteredData, out anotherNumber))
                        {
                            numbers.Add(anotherNumber);
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели непонятную для меня строку");
                        }
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}