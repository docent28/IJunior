using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_05
{
    class Program
    {
        static void Main(string[] args)
        {
            int numGrandmothers;
            int hour;
            int minute;
            int receptivePeriod = 10;

            Console.Write("Сколько бабушек стоит в очереди? - ");
            numGrandmothers = Convert.ToInt32(Console.ReadLine());

            hour = numGrandmothers * receptivePeriod / 60;
            minute = numGrandmothers * receptivePeriod % 60;

            Console.WriteLine($"Вы должны стоять в очереди {hour} часов и {minute} минут");
        }
    }
}
