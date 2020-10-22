using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.MemoryMappedFiles;

namespace EVL_HomeWork_22
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPlaying = true;
            bool repeatedVisit = false;
            int performerX, performerY;
            int performerDX = 0, performerDY = 0;
            int totalMoves = 0;
            string correctRoute="";
            Console.CursorVisible = false;
            char[,] map = ReadMap("level01", out performerX, out performerY);

            SetConsole(100, 40);

            DrawMap(map);

            while (isPlaying)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    Console.SetCursorPosition(5, 32);
                    Console.WriteLine("Игра закончена");
                    Console.WriteLine();
                    isPlaying = false;
                }
                else if (key.Key == ConsoleKey.F1)
                {
                    correctRoute = "AAASSSDWWDSSSAASSDWDDWWWWDSSSDWWWD" +
                        "SSSSAASAASAASDDDWDSSAAAASSSSDWWWDSSSDWWWDSSSD" +
                        "WWWWWWWDSSSSSSSDWDSDWWAAWDWAWDDSSDSSSDDDWAAWD" +
                        "DWAAWAWDDSDWWAAAAAAWWWWWWDSSSSSDWWWWWDSSSSSDD" +
                        "WAWDWAWWDSDWDSSASDSASDSSSSSSSSAAA";
                    PassCorrectly(correctRoute);
                }
                else
                {
                    ChangeMotion(key, ref performerDX, ref performerDY);

                    repeatedVisit = MovePerformer(map, ref performerX, ref performerY, performerDX, performerDY, ref totalMoves);
                    if (repeatedVisit)
                    {
                        break;
                    }
                }
            }
            Console.SetCursorPosition(35, 17);
            Console.WriteLine();
            Console.SetCursorPosition(35, 19);
        }

        static void PassCorrectly(string correctRoute)
        {
            ConsoleKey key;
            key = ConsoleKey.UpArrow;
            if (key== ConsoleKey.UpArrow)
            {
                Console.WriteLine("1111111124321412342134");
            }
        }

        static void ChangeMotion(ConsoleKeyInfo key, ref int DX, ref int DY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    DX = -2;
                    DY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    DX = 2;
                    DY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    DX = 0;
                    DY = -2;
                    break;
                case ConsoleKey.RightArrow:
                    DX = 0;
                    DY = 2;
                    break;
                default:
                    break;
            }
        }

        static bool MovePerformer(char[,] map, ref int X, ref int Y, int DX, int DY, ref int totalMoves)
        {
            bool trafficPermit = false;

            trafficPermit = map[X + DX / 2, Y + DY / 2] != '║' &&
                map[X + DX / 2, Y + DY / 2] != '═' &&
                map[X + DX / 2, Y + DY / 2] != '╠' &&
                map[X + DX / 2, Y + DY / 2] != '╣' &&
                map[X + DX / 2, Y + DY / 2] != '╦' &&
                map[X + DX / 2, Y + DY / 2] != '╩' &&
                map[X + DX / 2, Y + DY / 2] != '╬' &&
                (X + DX / 2) < map.GetLength(0) - 1 && (X + DX / 2) > 0 &&
                (Y + DY / 2) < map.GetLength(1) - 1 && (Y + DY / 2) > 0;

            if (trafficPermit)
            {
                if (map[X + DX, Y + DY] != '¤')
                {
                    Console.SetCursorPosition(Y, X);
                    Console.Write('¤');
                    map[X, Y] = '¤';
                    X += DX;
                    Y += DY;
                    Console.SetCursorPosition(Y, X);
                    Console.Write('■');

                    totalMoves++;
                    Console.SetCursorPosition(10, 32);
                    Console.WriteLine($"Осталось ходов - {202 - totalMoves} из 202");
                    return false;
                }
                else
                {
                    Console.SetCursorPosition(35, 15);
                    Console.Write("Вы уже проходили в данном месте");
                    Console.SetCursorPosition(35, 16);
                    Console.Write("Увы, вы проиграли и игра закончена");
                    return true;
                }
            }
            return false;
        }

        static void SetConsole(int length, int height)
        {
            Console.SetWindowSize(length, height);
            Console.SetCursorPosition(35, 0);
            Console.WriteLine("ПРОГУЛКА ПО МУЗЕЮ");
            Console.SetCursorPosition(35, 1);
            Console.WriteLine();
            Console.SetCursorPosition(35, 2);
            Console.WriteLine("В музее 195 комнат. Составьте маршрут для посетителей:");
            Console.SetCursorPosition(35, 3);
            Console.WriteLine("надо побывать в каждой комнате, но так, чтобы не заходить");
            Console.SetCursorPosition(35, 4);
            Console.WriteLine("дважды ни в одну из них. И еще одно условие: в маршрут");
            Console.SetCursorPosition(35, 5);
            Console.WriteLine("надо включить ту часть его, которая нанесена пунктиром.");
            Console.SetCursorPosition(35, 6);
            Console.WriteLine("Пройденный участок отмечается символом ¤");
            Console.SetCursorPosition(35, 7);
            Console.WriteLine();
            Console.SetCursorPosition(35, 8);
            Console.WriteLine("Маршрут можно пройти за 202 шага");
            Console.SetCursorPosition(35, 9);
            Console.WriteLine();
            Console.SetCursorPosition(35, 10);
            Console.WriteLine("Стрелки - сделать шаг в указанном стрелкой направлении");
            Console.SetCursorPosition(35, 11);
            Console.WriteLine("F1 - подсказка по прохождению");
            Console.SetCursorPosition(35, 12);
            Console.WriteLine("ESC - выход из игры");
            Console.SetCursorPosition(0, 0);
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static char[,] ReadMap(string mapName, out int performerX, out int performerY)
        {
            performerX = 0;
            performerY = 0;

            string[] newFile = File.ReadAllLines($"maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == '■')
                    {
                        performerX = i;
                        performerY = j;
                    }
                }
            }
            return map;
        }
    }
}
