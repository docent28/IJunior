using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_Task_Home_09
{
    class Program
    {
        static void Main(string[] args)
        {
            float ruble = 0.0f;
            float dollar = 0.0f;
            float yuan = 0.0f;
            float dollarExcRuble = 50.0f;
            float yuanExcRuble = 10.0f;
            float dollarExcYuan = 5.0f;
            string sellingCurrency;
            string buyingCurrency;
            string exchange;
            float money = 0.0f;
            string currency;
            bool exit = false;
            string checkString;

            Console.Write("Введите количество имеющихся у вас рублей.\n" +
                "или EXIT для выхода из программы - ");
            checkString = Console.ReadLine();
            if (checkString == "EXIT")
            {
                Environment.Exit(0);
            }
            else
            {
                ruble = Convert.ToSingle(checkString);
            }

            Console.Write("Введите количество имеющихся у вас долларов.\n" +
                "или EXIT для выхода из программы - ");
            checkString = Console.ReadLine();
            if (checkString == "EXIT")
            {
                Environment.Exit(0);
            }
            else
            {
                dollar = Convert.ToSingle(checkString);
            }

            Console.Write("Введите количество имеющихся у вас юаней.\n" +
                "или EXIT для выхода из программы - ");
            checkString = Console.ReadLine();
            if (checkString == "EXIT")
            {
                Environment.Exit(0);
            }
            else
            {
                yuan = Convert.ToSingle(checkString);
            }

            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("Какую валюту вы хотите обменять? (введите цифру от 1 до 3).\n" +
                    "Или EXIT для выхода из программы");
                Console.WriteLine("1 - рубли");
                Console.WriteLine("2 - доллары");
                Console.WriteLine("3 - юани");
                buyingCurrency = Console.ReadLine();
                switch (buyingCurrency)
                {
                    case "1":
                        currency = "рубли";
                        break;
                    case "2":
                        currency = "доллары";
                        break;
                    case "3":
                        currency = "юани";
                        break;
                    case "EXIT":
                        exit = true;
                        continue;
                    default:
                        Console.WriteLine("Неправильный ввод.");
                        continue;
                }

                Console.Write("Введите сумму, которую вы хотите обменять?\n" +
                    "Или EXIT для выхода - ");
                checkString = Console.ReadLine();
                if (checkString == "EXIT")
                {
                    System.Environment.Exit(0);
                }
                else
                {
                    money = Convert.ToSingle(checkString);
                }

                switch (buyingCurrency)
                {
                    case "1":
                        if (money > ruble)
                        {
                            Console.WriteLine("У вас не хватает рублей.");
                            continue;
                        }
                        break;
                    case "2":
                        if (money > dollar)
                        {
                            Console.WriteLine("У вас не хватает долларов.");
                            continue;
                        }
                        break;
                    case "3":
                        if (money > yuan)
                        {
                            Console.WriteLine("У вас не хватает юаней.");
                            continue;
                        }
                        break;
                }

                Console.WriteLine($"На какую валюту вы хотите обменять {currency}? (введите цифру от 1 до 3).\n" +
                    "Или EXIT для выхода из программы");
                Console.WriteLine("1 - рубли");
                Console.WriteLine("2 - доллары");
                Console.WriteLine("3 - юани");
                sellingCurrency = Console.ReadLine();
                if (sellingCurrency == "EXIT")
                {
                    exit = true;
                    continue;
                }

                exchange = buyingCurrency + sellingCurrency;
                switch (exchange)
                {
                    case "11":
                    case "22":
                    case "33":
                        Console.WriteLine("Нет смысла совершать подобный обмен. Вы остались при своих.");
                        break;
                    case "12":
                        if (money / dollarExcRuble > dollar)
                        {
                            Console.WriteLine("Обмен совершить невозможно. У вас не хватает долларов");
                        }
                        else
                        {
                            dollar += money / dollarExcRuble;
                            ruble -= money;
                        }
                        break;
                    case "13":
                        if (money / yuanExcRuble > yuan)
                        {
                            Console.WriteLine("Обмен совершить невозможно. У вас не хватает юаней");
                        }
                        else
                        {
                            yuan += money / yuanExcRuble;
                            ruble -= money;
                        }
                        break;
                    case "21":
                        if (money * dollarExcRuble > ruble)
                        {
                            Console.WriteLine("Обмен совершить невозможно. У вас не хватает рублей");
                        }
                        else
                        {
                            ruble += money * dollarExcRuble;
                            dollar -= money;
                        }
                        break;
                    case "23":
                        if (money * dollarExcYuan > yuan)
                        {
                            Console.WriteLine("Обмен совершить невозможно. У вас не хватает юаней");
                        }
                        else
                        {
                            yuan += money * dollarExcYuan;
                            dollar -= money;
                        }
                        break;
                    case "31":
                        if (money * yuanExcRuble > ruble)
                        {
                            Console.WriteLine("Обмен совершить невозможно. У вас не хватает рублей");
                        }
                        else
                        {
                            ruble += money * yuanExcRuble;
                            yuan -= money;
                        }
                        break;
                    case "32":
                        if (money / dollarExcYuan > dollar)
                        {
                            Console.WriteLine("Обмен совершить невозможно. У вас не хватает долларов");
                        }
                        else
                        {
                            dollar += money / dollarExcYuan;
                            yuan -= money;
                        }
                        break;
                    default:
                        Console.WriteLine("Вы ошиблись при выборе валют. Укажите правильные параметры");
                        continue;
                }
                Console.WriteLine("У вас сейчас  -\t" + ruble + " рублей");
                Console.WriteLine("\t\t" + dollar + " долларов");
                Console.WriteLine("\t\t" + yuan + " юаней");
            }
        }
    }
}