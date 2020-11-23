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
            string menuItem;
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
                        Console.Write("Введите номер нового игрока - ");
                        numberPlayer = Convert.ToInt32(Console.ReadLine());
                        if (repoPlayers.IsExist(numberPlayer))
                        {
                            Console.WriteLine($"\nИгрок с №{numberPlayer} уже есть в списке");
                            break;
                        }

                        Console.Write("Введите ник нового игрока - ");
                        var nicNamePlayer = Console.ReadLine();
                        Console.Write("Введите уровень нового игрока - ");
                        var levelPlayer = Convert.ToInt32(Console.ReadLine());
                        Player player = new Player(numberPlayer, nicNamePlayer, levelPlayer);
                        repoPlayers.AddPlayer(player);
                        Console.WriteLine("\nИгрок добавлен");
                        break;
                    case "2":
                        Console.Write("Введите номер игрока для выдачи бана - ");
                        numberPlayer = Convert.ToInt32(Console.ReadLine());
                        if (repoPlayers.IsExist(numberPlayer))
                        {
                            repoPlayers.Ban(numberPlayer);
                            Console.WriteLine("\nИгрок забанен!");
                        }
                        else
                        {
                            Console.WriteLine("\nНе нашли нужного игрока");
                        }
                        break;
                    case "3":
                        Console.Write("Введите номер игрока для удаления бана - ");
                        numberPlayer = Convert.ToInt32(Console.ReadLine());
                        if (repoPlayers.IsExist(numberPlayer))
                        {
                            repoPlayers.UnBan(numberPlayer);
                            Console.WriteLine("\nИгрок разбанен!");
                        }
                        else
                        {
                            Console.WriteLine("\nНе нашли нужного игрока");
                        }
                        break;
                    case "4":
                        Console.Write("Введите номер игрока для удаления - ");
                        numberPlayer = Convert.ToInt32(Console.ReadLine());
                        if (repoPlayers.DeletePlayer(numberPlayer))
                        {
                            Console.WriteLine("\nИгрок удален");
                        }
                        else
                        {
                            Console.WriteLine("\nИгрок не найден");
                        }
                        break;
                    case "5":
                        repoPlayers.ShowInfo();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("\nОшибка ввода");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Player
    {
        public int Number { get; }
        private bool _isBanned;
        private string _nicName;
        private int _level;

        public string NicName
        {
            get
            {
                return _nicName;
            }
        }

        public int Level
        {
            get
            {
                return _level;
            }
        }

        public bool IsBanned
        {
            get
            {
                return _isBanned;
            }
        }

        public void Ban()
        {
            _isBanned = true;
        }

        public void UnBan()
        {
            _isBanned = false;
        }

        public Player(int number, string nicName, int level)
        {
            Number = number;
            _nicName = nicName;
            _level = level;
            _isBanned = false;
        }
    }

    class RepoPlayers
    {
        private List<Player> _players;

        public RepoPlayers()
        {
            _players = new List<Player>();
        }

        public bool IsExist(int playerId)
        {
            return isExist(playerId);
        }

        private bool isExist(int playerId)
        {
            return _players.Exists(findPlayer => findPlayer.Number == playerId);
        }

        public void ShowInfo()
        {
            if (_players.Count == 0)
            {
                Console.WriteLine("\nСписок игроков пуст");
            }
            else
            {
                foreach (var item in _players)
                {
                    Console.WriteLine("Игрок № - " + item.Number + "\tЕго ник - " + item.NicName + "\tУровень - " + item.Level + "\tБан - " + item.IsBanned);
                }
            }
        }

        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public bool DeletePlayer(int id)
        {
            Player player = _players.Find(findPlayer => findPlayer.Number == id);
            return _players.Remove(player);
        }

        public void Ban(int playerId)
        {
            SetBan(playerId, true);
        }

        public void UnBan(int playerId)
        {
            SetBan(playerId, false);
        }

        private void SetBan(int playerId, bool stateBan)
        {
            Player player = _players.Find(findPlayer => findPlayer.Number == playerId);
            if (stateBan)
            {
                player.Ban();
            }
            else
            {
                player.UnBan();
            }
        }
    }
}
