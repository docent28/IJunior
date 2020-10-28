using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_25
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalAmount = 0;
            int totalBayers;
            Random sum = new Random();
            Queue<int> purchaseAmount = new Queue<int>();

            for (int i = 0; i < sum.Next(5, 11); i++)
            {
                purchaseAmount.Enqueue(sum.Next(100, 1000));
            }

            totalBayers = purchaseAmount.Count();

            for (int i = 0; i < totalBayers; i++)
            {
                Console.WriteLine($"На счете имеется {totalAmount} рублей.");
                Console.WriteLine();
                Console.WriteLine($"Количество обслуженных покупателей: {i}");
                Console.WriteLine($"Количество покупателей в очереди: {purchaseAmount.Count()}");
                Console.WriteLine($"У следующего покупателя покупок на сумму {purchaseAmount.Peek()} рублей");

                totalAmount += purchaseAmount.Dequeue();
                Console.WriteLine();
                Console.WriteLine("Нажмите любую клавишу, чтобы обслужить следующего покупателя...");
                Console.ReadKey();
                Console.Clear();
            }
            Console.WriteLine();
            Console.WriteLine($"Итого обслужено покупателей в количестве {totalBayers} человек");
            Console.WriteLine($"На нашем счете {totalAmount} рублей");
            Console.WriteLine();
        }
    }
}
