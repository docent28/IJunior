using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_27
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fullName = new List<string>();
            List<string> position = new List<string>();
            bool exit = false;
            string menuItem = "";

            while (!exit)
            {
                Console.WriteLine("Отдел кадров");
                Console.WriteLine("1 - добавить досье");
                Console.WriteLine("2 - вывести все досье");
                Console.WriteLine("3 - удалить досье");
                Console.WriteLine("4 - выход из программы");
                Console.WriteLine();
                Console.Write("Выберите пункт меню: ");

                menuItem = Console.ReadLine();

                switch (menuItem)
                {
                    case "1":
                        AddDossier(ref fullName, ref position);
                        break;
                    case "2":
                        SnowDossier(fullName, position);
                        break;
                    case "3":
                        DeleteDossier(fullName, position);
                        break;
                    case "4":
                        exit = true;
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Вы ввели неправильное значение");
                        Console.WriteLine();
                        Console.WriteLine("Нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        static void AddDossier(ref List<string> fullName, ref List<string> position)
        {
            string strEntered;
            int dossierNumber = 0;

            Console.WriteLine("Добавление досье:");
            Console.WriteLine();
            Console.Write("Введите фамилию: ");
            strEntered = Console.ReadLine();
            fullName.Add(strEntered + " ");
            dossierNumber = fullName.Count;

            Console.Write("Введите имя: ");
            strEntered = Console.ReadLine();
            fullName[dossierNumber - 1] += strEntered + " ";
            Console.Write("Введите отчество: ");
            strEntered = Console.ReadLine();
            fullName[dossierNumber - 1] += strEntered;

            Console.Write("Введите должность: ");
            strEntered = Console.ReadLine();
            position.Add(strEntered);

            Console.WriteLine();
            Console.WriteLine("Данные занесены успешно!!!");
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
        }

        static void SnowDossier(List<string> fullName, List<string> position)
        {
            if (fullName.Count != 0)
            {
                Console.WriteLine("Вывод всех досье");
                for (int i = 0; i < fullName.Count; i++)
                {
                    Console.WriteLine((i + 1) + $"\t{fullName[i]}\t - {position[i]}");
                }
            }
            else
            {
                Console.WriteLine("Отсутствуют какие-либо досье");
            }
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
        }

        static void DeleteDossier(List<string> fullName, List<string> position)
        {
            string strEntered;
            int dossierNumber;

            if (fullName.Count != 0)
            {
                Console.Write("Введите номер досье для удаления: ");
                strEntered = Console.ReadLine();
                if (int.TryParse(strEntered, out dossierNumber))
                {
                    if (dossierNumber <= fullName.Count && dossierNumber >= 1)
                    {
                        fullName.RemoveAt(dossierNumber - 1);
                        position.RemoveAt(dossierNumber - 1);

                        Console.WriteLine("Досье удалено успешно!!!");
                    }
                    else
                    {
                        Console.WriteLine("Досье с таким номером не существует");
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели неправильное значение");
                }
            }
            else
            {
                Console.WriteLine("Отсутствуют какие-либо досье");
            }
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}