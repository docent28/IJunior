using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_13
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "SimplePassword";
            string secretMessage = "Это очень секретное сообщение. По прочтении забыть";
            string passwordEntered = "";
            int numberAttempts = 3;
            int attempt = 0;

            Console.WriteLine("Вам дается 3-и попытки");

            while (attempt < numberAttempts && passwordEntered != password)
            {
                Console.WriteLine("Попытка № - " + (attempt + 1));
                Console.Write("Введите пароль для доступа к сообщению - ");
                passwordEntered = Console.ReadLine();

                if (passwordEntered == password)
                {
                    Console.WriteLine("Содержимое секретного сообщения -");
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(secretMessage);
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else
                {
                    attempt++;
                    Console.WriteLine("Введен неправильный пароль");
                    Console.WriteLine("Количество оставшихся попыток - " + (numberAttempts - attempt));
                    Console.WriteLine();
                }
            }
        }
    }
}
