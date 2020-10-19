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
                        addDossier(ref fullName, ref position);
                        break;
                    case "2":
                        outputDossier(fullName, position);
                        break;
                    case "3":
                        deletingDossier(ref fullName, ref position);
                        break;
                    case "4":
                        searchSurname(ref fullName, ref position);
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
        static void addDossier(ref string[] fullName, ref string[] position)
        {
            string strEntered;
            string[] tempArray = new string[fullName.Length + 1];
            for (int i = 0; i < fullName.Length; i++)
            {
                tempArray[i] = fullName[i];
            }

            Console.WriteLine("Добавление досье:");
            Console.WriteLine();
            Console.Write("Введите фамилию: ");
            strEntered = Console.ReadLine();
            tempArray[tempArray.Length - 1] += strEntered + " ";
            Console.Write("Введите имя: ");
            strEntered = Console.ReadLine();
            tempArray[tempArray.Length - 1] += strEntered + " ";
            Console.Write("Введите отчество: ");
            strEntered = Console.ReadLine();
            tempArray[tempArray.Length - 1] += strEntered;
            fullName = tempArray;

            Console.Write("Введите должность: ");
            strEntered = Console.ReadLine();
            tempArray = new string[position.Length + 1];
            for (int i = 0; i < position.Length; i++)
            {
                tempArray[i] = position[i];
            }
            tempArray[tempArray.Length - 1] = strEntered;
            position = tempArray;

            Console.WriteLine();
            Console.WriteLine("Данные занесены успешно!!!");
            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
        }

        static void outputDossier(string[] fullName, string[] position)
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

        static void deletingDossier(ref string[] fullname, ref string[] position)
        {
            string strEntered;
            int dossierNumber;
            int orderOffset = 0;

            if (fullname.Length != 0)
            {
                string[] tempArrayFullName = new string[fullname.Length - 1];
                string[] tempArrayPosition = new string[position.Length - 1];
                Console.Write("Введите номер досье для удаления: ");
                strEntered = Console.ReadLine();
                if (int.TryParse(strEntered, out dossierNumber))
                {
                    if (dossierNumber <= fullname.Length && dossierNumber >= 1)
                    {
                        for (int i = 0; i < fullname.Length; i++)
                        {
                            if (i + 1 != dossierNumber)
                            {
                                tempArrayFullName[i + orderOffset] = fullname[i];
                                tempArrayPosition[i + orderOffset] = position[i];
                            }
                            else
                            {
                                orderOffset = -1;
                                continue;
                            }
                        }
                        fullname = tempArrayFullName;
                        position = tempArrayPosition;

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

        static void searchSurname(ref string[] fullName, ref string[] position)
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
    }
}