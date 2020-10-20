using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_19
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] position = new string[0];
            string[] fullName = new string[0];
            bool exit = false;
            string menuItem = "";

            while (!exit)
            {
                Console.WriteLine("Отдел кадров");
                Console.WriteLine("1 - добавить досье");
                Console.WriteLine("2 - вывести все досье");
                Console.WriteLine("3 - удалить досье");
                Console.WriteLine("4 - поиск по фамилии");
                Console.WriteLine("5 - выход из программы");
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
                        DeleteDossier(ref fullName, ref position);
                        break;
                    case "4":
                        SearchLastName(fullName, position);
                        break;
                    case "5":
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

        static void AddDossier(ref string[] fullName, ref string[] position)
        {
            string strEntered;

            IncreaseArraySize(ref fullName, 1);

            Console.WriteLine("Добавление досье:");
            Console.WriteLine();
            Console.Write("Введите фамилию: ");
            strEntered = Console.ReadLine();
            fullName[fullName.Length - 1] += strEntered + " ";
            Console.Write("Введите имя: ");
            strEntered = Console.ReadLine();
            fullName[fullName.Length - 1] += strEntered + " ";
            Console.Write("Введите отчество: ");
            strEntered = Console.ReadLine();
            fullName[fullName.Length - 1] += strEntered;

            IncreaseArraySize(ref position, 1);

            Console.Write("Введите должность: ");
            strEntered = Console.ReadLine();
            position[position.Length - 1] = strEntered;

            Console.WriteLine();
            Console.WriteLine("Данные занесены успешно!!!");
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
        }

        static void SnowDossier(string[] fullName, string[] position)
        {
            if (fullName.Length != 0)
            {
                Console.WriteLine("Вывод всех досье");
                for (int i = 0; i < fullName.Length; i++)
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

        static void DeleteDossier(ref string[] fullname, ref string[] position)
        {
            string strEntered;
            int dossierNumber;

            if (fullname.Length != 0)
            {
                Console.Write("Введите номер досье для удаления: ");
                strEntered = Console.ReadLine();
                if (int.TryParse(strEntered, out dossierNumber))
                {
                    if (dossierNumber <= fullname.Length && dossierNumber >= 1)
                    {
                        DeleteArrayItem(ref fullname, dossierNumber);
                        DeleteArrayItem(ref position, dossierNumber);

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

        static void SearchLastName(string[] fullName, string[] position)
        {
            string strEntered;
            int numberMatches = 0;
            if (fullName.Length != 0)
            {
                Console.Write("Введите фамилию для поиска: ");
                strEntered = Console.ReadLine();
                Console.WriteLine();
                for (int i = 0; i < fullName.Length; i++)
                {
                    if (fullName[i].StartsWith(strEntered + " "))
                    {
                        numberMatches++;
                        Console.WriteLine((numberMatches) + $"\t{fullName[i]}\t - {position[i]}");
                    }
                }
                if (numberMatches > 0)
                {
                    Console.WriteLine($"Количество сотрудников с фамилией {strEntered} - {numberMatches}");
                }
                else
                {
                    Console.WriteLine($"Сотрудников с фамилией {strEntered} нет");
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

        static void IncreaseArraySize(ref string[] expandableArray, int sizeIncrease)
        {
            string[] tempArray = new string[expandableArray.Length + sizeIncrease];
            for (int i = 0; i < expandableArray.Length; i++)
            {
                tempArray[i] = expandableArray[i];
            }
            expandableArray = tempArray;
        }

        static void DeleteArrayItem(ref string[] compressibleArray, int itemDelete)
        {
            string[] tempArray = new string[compressibleArray.Length - 1];
            int orderOffset = 0;

            for (int i = 0; i < compressibleArray.Length; i++)
            {
                if (i + 1 != itemDelete)
                {
                    tempArray[i + orderOffset] = compressibleArray[i];
                }
                else
                {
                    orderOffset = -1;
                    continue;
                }
            }
            compressibleArray = tempArray;
        }
    }
}