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
                            Console.WriteLine($"\nИгрок с №{numberPlayer} уже есть в списке\nНажмите любую клавишу...");
                            break;
                        }

                        Console.Write("Введите ник нового игрока - ");
                        var nicNamePlayer = Console.ReadLine();
                        Console.Write("Введите уровень нового игрока - ");
                        var levelPlayer = Convert.ToInt32(Console.ReadLine());
                        Player player = new Player(numberPlayer, nicNamePlayer, levelPlayer);
                        repoPlayers.AddPlayer(player);
                        Console.WriteLine("\nИгрок добавлен\nНажмите любую клавишу...");
                        break;
                    case "2":
                        Console.Write("Введите номер игрока для выдачи бана - ");
                        numberPlayer = Convert.ToInt32(Console.ReadLine());
                        if (repoPlayers.IsExist(numberPlayer))
                        {
                            repoPlayers.Ban(numberPlayer);
                            Console.WriteLine("\nИгрок забанен!\nНажмите любую клавишу...");
                        }
                        else
                        {
                            Console.Write("\nНе нашли нужного игрока\nНажмите любую клавишу...");
                        }
                        break;
                    case "3":
                        Console.Write("Введите номер игрока для удаления бана - ");
                        numberPlayer = Convert.ToInt32(Console.ReadLine());
                        if (repoPlayers.IsExist(numberPlayer))
                        {
                            repoPlayers.UnBan(numberPlayer);
                            Console.WriteLine("\nИгрок разбанен!\nНажмите любую клавишу...");
                        }
                        else
                        {
                            Console.Write("\nНе нашли нужного игрока\nНажмите любую клавишу...");
                        }
                        break;
                    case "4":
                        Console.Write("Введите номер игрока для удаления - ");
                        numberPlayer = Convert.ToInt32(Console.ReadLine());
                        if (repoPlayers.DeletePlayer(numberPlayer))
                        {
                            Console.WriteLine("\nИгрок удален\nНажмите любую клавишу...");
                        }
                        else
                        {
                            Console.WriteLine("\nИгрок не найден\nНажмите любую клавишу...");
                        }
                        break;
                    case "5":
                        var players = repoPlayers.GetPlayers();

                        if (players.Count > 0)
                        {
                            foreach (var p in players)
                            {
                                Console.WriteLine(p.ShowInfo());
                            }
                        }
                        else
                        {
                            Console.WriteLine("Список игроков пуст");
                        }
                        Console.WriteLine("\nНажмите любую клавишу...");
                        break;
                    case "6":
                        exit = true;
                        Console.WriteLine("\nНажмите любую клавишу...");
                        break;
                    default:
                        Console.WriteLine("\nОшибка ввода\nНажмите любую клавишу...");
                        break;
                }

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

        public bool IsBan()
        {
            return _isBanned;
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

        public Player(Player i)
        {
            Number = i.Number;
            _nicName = i._nicName;
            _level = i._level;
            _isBanned = i.IsBan();
        }

        public string ShowInfo()
        {
            return "Игрок № - " + Number + "\tЕго ник - " + _nicName + "\tУровень - " + _level + "\tБан - " + _isBanned;
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

        public List<Player> GetPlayers()
        {
            List<Player> tmp = new List<Player>(_players.Count());
            _players.ForEach((i) =>
            {
                tmp.Add(new Player(i));
            });
            return tmp;
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
            setBan(playerId, true);
        }

        public void UnBan(int playerId)
        {
            setBan(playerId, false);
        }

        private void setBan(int playerId, bool stateBan)
        {
            if (isExist(playerId))
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
            else
            {
                Console.WriteLine("\nИгрок не найден\nНажмите любую клавишу...");
            }
        }
    }
}
