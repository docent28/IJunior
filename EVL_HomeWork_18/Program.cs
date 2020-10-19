using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_18
{
    class Program
    {
        static void Main(string[] args)
        {
            bool endInput = true;
            string enteredData;
            double[] numbers = new double[0];
            double sumNumbers = 0;
            double anotherNumber;

            Console.WriteLine("ИНСТРУКЦИЯ");
            Console.WriteLine("Вы можете вводить числа. Если число дробное, то разделитель целой и дробной частей - запятая");
            Console.WriteLine("sum - подсчет и вывод суммы всех введенных чисел");
            Console.WriteLine("exit - выход из программы");
            Console.WriteLine();

            while (endInput)
            {
                Console.WriteLine("Введите или число или одно из ключевых слов");
                enteredData = Console.ReadLine();

                switch (enteredData)
                {
                    case "sum":
                        for (int i = 0; i < numbers.Length; i++)
                        {
                            sumNumbers += numbers[i];
                        }
                        Console.WriteLine("Сумма всех введенных чисел равна: " + sumNumbers);
                        sumNumbers = 0;
                        Console.WriteLine();
                        break;
                    case "exit":
                        endInput = false;
                        Console.WriteLine();
                        break;
                    default:
                        if (double.TryParse(enteredData, out anotherNumber))
                        {
                            double[] temp = new double[numbers.Length + 1];
                            for (int i = 0; i < numbers.Length; i++)
                            {
                                temp[i] = numbers[i];
                            }
                            temp[numbers.Length] = anotherNumber;
                            numbers = temp;
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели непонятную строку");
                        }
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}