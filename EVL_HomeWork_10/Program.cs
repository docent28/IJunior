using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            string stringEnter = "";
            string smile = @"
                ░░░░░░░▄▄█▀▀▀▀▀▀▀▀█▄▄░░░░░░░
                ░░░░▄▄▀░░░░░░░░░░░░░░▀▄▄░░░░
                ░░░█▀░░░░░░░░░░░░░░░░░░▀█░░░
                ░▄█░░░░░▄▄▄▄░░░░▄▄▄▄░░░░░█▄░
                ░█░░░░░█▀░▄▄█░░█▄▄░▀█░░░░░█░
                █░░░░░░█░████░░████░█░░░░░░█
                █░░░░░░▀▀▀▀▀░░░░▀▀▀▀▀░░░░░░█
                █░░░░░░░▄░░░░░░░░░░▄░░░░░░░█
                ▀▄░░░░░█▀█░░░░░░░░█▀█░░░░░▄▀
                ░█▄░░░░▀█░▀█▄▄▄▄█▀░█▀░░░░▄█░
                ░░▀▄░░░░░▀█▄▄░░▄▄█▀░░░░░▄▀░░
                ░░░▀█▄░░░░░░▀▀▀▀░░░░░░▄█▀░░░
                ░░░░░░▀▄▄▄░░░░░░░░▄▄▄▀░░░░░░
                ░░░░░░░░░▀▀▀▀▀▀▀▀▀▀░░░░░░░░░";

            while (stringEnter != "Exit") {
                Console.WriteLine("Введите команду, которую необходимо выполнить");
                Console.WriteLine("HELP - вызов помощи");
                Console.WriteLine("");
                stringEnter = Console.ReadLine();
                switch (stringEnter)
                {
                    case "HELP":
                        Console.WriteLine("Команды, которые вы можете использовать:");
                        Console.WriteLine("");
                        Console.WriteLine("HELP\t\t\t- вызов помощи");
                        Console.WriteLine("Random\t\t\t- случайное число от 1 до 10 включительно");
                        Console.WriteLine("ConsoleColorBlue\t- очистить и установить синий цвет консоли");
                        Console.WriteLine("FontColorRed\t\t- установить красный цвет шрифта в консоли");
                        Console.WriteLine("Init\t\t\t- очистить и вернуть цвет консоли и шрифта по умолчанию");
                        Console.WriteLine("Clear\t\t\t- очиститьт консоль");
                        Console.WriteLine("Name\t\t\t- сообщить имя бота");
                        Console.WriteLine("Smile\t\t\t- улыбнуться");
                        Console.WriteLine("Exit\t\t\t- закончить работу программы");
                        break;
                    case "Random":
                        Console.WriteLine(rand.Next(1, 11));
                        break;
                    case "ConsoleColorBlue":
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.Clear();
                        break;
                    case "FontColorRed":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "Init":
                        Console.ResetColor();
                        Console.Clear();
                        break;
                    case "Clear":
                        Console.Clear();
                        break;
                    case "Name":
                        Console.WriteLine("Меня зовут Роботрон.");
                        break;
                    case "Smile":
                        Console.WriteLine(smile);
                        break;
                    case "Exit":
                        stringEnter = "Exit";
                        break;
                    default:
                        Console.WriteLine("Неправильная команда.");
                        break;
                }
            }
        }
    }
}
