using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_24
{
    class Program
    {
        static void Main(string[] args)
        {
            string searchWord;
            bool exit = false;
            Dictionary<string, string> wordsExplanations = new Dictionary<string, string>();

            FillDictionary(wordsExplanations);

            while (!exit)
            {
                Console.WriteLine("Вы можете узнать значения следующих слов -");

                foreach (var item in wordsExplanations.Keys)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();
                Console.WriteLine("Введите слово, значение которого вы хотите узнать,");
                Console.Write("или EXIT для выхода из программы: ");

                searchWord = Console.ReadLine();

                if (searchWord == "EXIT")
                {
                    Console.WriteLine();
                    Console.WriteLine("Программа закончила свою работу");
                    exit = true;
                    continue;
                }

                if (wordsExplanations.ContainsKey(searchWord))
                {
                    Console.WriteLine();
                    Console.WriteLine(wordsExplanations[searchWord]);
                    ClearConsole();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Извините, такого слова нет в моем словаре");
                    ClearConsole();
                }
            }
        }

        static void ClearConsole()
        {
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для продолжения работы программы...");
            Console.ReadKey();
            Console.Clear();
        }

        static void FillDictionary(Dictionary<string, string> concepts)
        {
            string words;
            string explanations;

            words = "Аватар";
            explanations = "Картинка, которую пользователь выбирает себе в качестве «лица»." +
                " В основном используется на форумах и в блогах в интернете";
            concepts.Add(words, explanations);

            words = "Гуглить";
            explanations = "Искать какую-либо информацию в интернете с помощью поисковика Google";
            concepts.Add(words, explanations);

            words = "Корень";
            explanations = "Первая директория в дереве (корневая директория)";
            concepts.Add(words, explanations);

            words = "Бан";
            explanations = "Используется в веб-форумах или чатах. Запрет для пользователя" +
                " отправлять сообщения. «Забанить, наложить бан» ввести запрет для пользователя" +
                " что либо делать (писать новые сообщения или просматривать их)";
            concepts.Add(words, explanations);

            words = "Дебажить";
            explanations = "Искать ошибки в программе, отлаживать программу";
            concepts.Add(words, explanations);

            words = "Чайник";
            explanations = "Малоопытный пользователь, человек, который не умеет целесообразно" +
                " пользоваться персональным компьютером в нужном для него объёме";
            concepts.Add(words, explanations);
        }
    }
}
