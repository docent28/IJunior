using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_07
{
    class Program
    {
        static void Main(string[] args)
        {
            string userMessage;
            int numberRepetitions;

            Console.WriteLine("Введите ваше сообщение");
            userMessage = Console.ReadLine();
            Console.Write("Сколько раз необходимо повторить вывод сообщения? ");
            numberRepetitions = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            for(int i = 0; i < numberRepetitions; i++)
            {
                Console.WriteLine(userMessage);
            }
        }
    }
}
