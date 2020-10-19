using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_06
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string age;
            string color;
            string zodiac;
            bool particleYesNo;
            string passionProgramming;
            string denialNot;

            Console.Write("Сообщите, как вас зовут: ");
            name = Console.ReadLine();
            Console.Write("Сколько вам лет? ");
            age = Console.ReadLine();
            Console.Write("Вы увлекаетесь программированием? (да/нет) - ");
            passionProgramming = Console.ReadLine();
            Console.Write("Ваш любимый цвет: ");
            color = Console.ReadLine();
            Console.Write("Ваш знак Зодиака: ");
            zodiac = Console.ReadLine();

            particleYesNo = passionProgramming != "да";
            passionProgramming = "Вы увлекаетесь программированием.";
            denialNot = " не".Substring(0, 3 * Convert.ToInt32(particleYesNo));

            Console.WriteLine("");
            Console.WriteLine($"Добрый день, {name}!");
            Console.WriteLine($"Вы сказали, что вам {age} лет. По знаку Зодиака вы - {zodiac}.");
            Console.WriteLine($"Ваш любимый цвет {color}.");
            Console.WriteLine(passionProgramming.Insert(2, denialNot));
        }
    }
}
