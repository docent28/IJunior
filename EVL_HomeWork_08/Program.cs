using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_08
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordStop = "exit";
            string userMessage = "";
            int attempt = 0;

            while (userMessage != wordStop)
            {
                attempt++;
                Console.WriteLine("Попытка № - " + attempt);
                Console.WriteLine("Введите сообщение:");
                userMessage = Console.ReadLine();
            }
        }
    }
}
