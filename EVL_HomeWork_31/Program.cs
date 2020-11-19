using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_31
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            string menuItem = "";
            RepoGoodsBuyer repoGoodsBuyer = new RepoGoodsBuyer();
            RepoGoodsSeller repoGoodsSeller = new RepoGoodsSeller();

            while (!exit)
            {
                Console.WriteLine("1 - завезти товар в магазин");
                Console.WriteLine("2 - продать товар покупателю");
                Console.WriteLine("3 - показать товар в магазине");
                Console.WriteLine("4 - показать товар у покупателя");

                menuItem = Console.ReadLine();

                switch (menuItem)
                {
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("\nОшибка ввода\nНажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                }

                Console.Clear();
            }
        }
    }

    class Item      // Товар
    {
        private string _name;
        private int _quantity;
        private double _price;

    }

    class Seller    // Продавец
    {

    }

    class Buyer     // Покупатель
    {

    }
}
