using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_30
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            string menuItem = "";
            int numberPlayer;
            RepoPlayers repoPlayers = new RepoPlayers();

            while (!exit)
            {
                Console.WriteLine("1 - добавление нового игрока");
                Console.WriteLine("2 - забанить игрока по номеру");
                Console.WriteLine("3 - разбанить игрока по номеру");
                Console.WriteLine("4 - удалить игрока по номеру");
                Console.WriteLine("5 - вывести список игроков");
                Console.WriteLine("6 - выход из программы");
                Console.Write("\nВыберите нужный пункт - ");

                menuItem = Console.ReadLine();

                switch (menuItem)
                {
                    case "1":
                        repoPlayers.AddPlayer();
                        break;
                    case "2":
                        Console.Write("Введите номер игрока для выдачи бана - ");
                        numberPlayer = Convert.ToInt32(Console.ReadLine());
                        repoPlayers.BanPlayer(numberPlayer);
                        break;
                    case "3":
                        Console.Write("Введите номер игрока для удаления бана - ");
                        numberPlayer = Convert.ToInt32(Console.ReadLine());
                        repoPlayers.NoBanPlayer(numberPlayer);
                        break;
                    case "4":
                        Console.Write("Введите номер игрока для удаления - ");
                        numberPlayer = Convert.ToInt32(Console.ReadLine());
                        repoPlayers.DelPlayer(numberPlayer);
                        break;
                    case "5":
                        if (!repoPlayers.CheckQuantity())
                        {
                            foreach (var p in repoPlayers.Players)
                            {
                                p.ShowInfo();
                            }
                            Console.WriteLine("\nНажмите любую клавишу...");
                            Console.ReadKey();
                        }
                        break;
                    case "6":
                        exit = true;
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

    class Player
    {
        public int Number { get; }
        public bool Ban { get; set; }
        private string _nicName;
        private int _level;

        public Player(int number, string nicName, int level)
        {
            Number = number;
            _nicName = nicName;
            _level = level;
            Ban = false;
        }
        public void ShowInfo()
        {
            Console.WriteLine("Игрок № - " + Number + "\tЕго ник - " + _nicName + "\tУровень - " + _level + "\tБан - " + Ban);
        }
    }

    class RepoPlayers
    {
        public List<Player> Players { get; }

        public RepoPlayers()
        {
            Players = new List<Player>();
        }

        public void AddPlayer()
        {
            int numberPlayer;
            string nicNamePlayer;
            int levelPlayer;
            bool isFindPlayer;

            Console.Write("Введите номер нового игрока - ");
            numberPlayer = Convert.ToInt32(Console.ReadLine());

            isFindPlayer = Players.Exists(findPlayer => findPlayer.Number == numberPlayer);
            if (isFindPlayer)
            {
                Console.WriteLine($"\nИгрок с №{numberPlayer} уже ест в списке\nНажмите любую клавишу...");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите ник нового игрока - ");
            nicNamePlayer = Console.ReadLine();
            Console.Write("Введите уровень нового игрока - ");
            levelPlayer = Convert.ToInt32(Console.ReadLine());
            Player player = new Player(numberPlayer, nicNamePlayer, levelPlayer);
            Players.Add(player);
            Console.WriteLine("\nНовый игрок добавлен\nНажмите любую клавишу...");
            Console.ReadKey();
        }

        public void DelPlayer(int id)
        {
            if (CheckQuantity()) return;

            bool isFindPlayer;

            isFindPlayer = Players.Exists(findPlayer => findPlayer.Number == id);
            if (isFindPlayer)
            {
                Player player = Players.Find(findPlayer => findPlayer.Number == id);
                Players.Remove(player);
                Console.WriteLine($"\nИгрок с №{id} успешно удален");
            }
            else
            {
                Console.WriteLine($"\nИгрок с №{id} отсутствует");
            }
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        public void BanPlayer(int id)
        {
            if (CheckQuantity()) return;

            bool isFindPlayer;

            isFindPlayer = Players.Exists(findPlayer => findPlayer.Number == id);
            if (isFindPlayer)
            {
                Player player = Players.Find(findPlayer => findPlayer.Number == id);
                if (player.Ban)
                {
                    Console.WriteLine($"\nИгрок №{id} уже имеет бан");
                }
                else
                {
                    player.Ban = true;
                    Console.WriteLine($"\nИгрок №{id} забанен");
                }
            }
            else
            {
                Console.WriteLine($"\nИгрок с №{id} отсутствует");
            }
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        public void NoBanPlayer(int id)
        {
            if (CheckQuantity()) return;

            bool isFindPlayer;

            isFindPlayer = Players.Exists(findPlayer => findPlayer.Number == id);
            if (isFindPlayer)
            {
                Player player = Players.Find(findPlayer => findPlayer.Number == id);
                if (player.Ban)
                {
                    player.Ban = false;
                    Console.WriteLine($"\nИгрок №{player.Number} разбанен");
                }
                else
                {
                    Console.WriteLine($"\nИгрок №{player.Number} не забанен");
                }
            }
            else
            {
                Console.WriteLine($"\nИгрок с №{id} отсутствует");
            }
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        public bool CheckQuantity()
        {
            if (Players.Count == 0)
            {
                Console.WriteLine("\nСписок пуст\nНажмите любую клавишу...");
                Console.ReadKey();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
