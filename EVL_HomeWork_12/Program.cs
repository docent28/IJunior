using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_12
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameUser;
            char outlineSymbol;

            Console.Write("Введите имя - ");
            nameUser = Console.ReadLine();
            Console.Write("Введите символ - ");
            outlineSymbol = (char)Console.Read();
            Console.WriteLine();

            for(int i = 0; i < nameUser.Length + 2; i++)
            {
                Console.Write(outlineSymbol);             
            }
            Console.WriteLine();
            Console.WriteLine(outlineSymbol+nameUser+outlineSymbol);
            for (int i = 0; i < nameUser.Length + 2; i++)
            {
                Console.Write(outlineSymbol);
            }
            Console.WriteLine("\n");
        }
    }
}
