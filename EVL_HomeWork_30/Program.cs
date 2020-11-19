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
                        repoPlayers.BanUnBan(numberPlayer, true);
                        break;
                    case "3":
                        Console.Write("Введите номер игрока для удаления бана - ");
                        numberPlayer = Convert.ToInt32(Console.ReadLine());
                        repoPlayers.BanUnBan(numberPlayer, false);
                        break;
                    case "4":
                        Console.Write("Введите номер игрока для удаления - ");
                        numberPlayer = Convert.ToInt32(Console.ReadLine());
                        repoPlayers.DeletePlayer(numberPlayer);
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
        private bool _ban;
        private string _nicName;
        private int _level;
        private Player i;   // не используется
                            // игроки в лист не заносятся

        public bool IsBan()
        {
            return _ban;
        }
        public void Ban()
        {
            _ban = true;
        }

        public void UnBan()
        {
            _ban = false;
        }

        public Player(int number, string nicName, int level)
        {
            Number = number;
            _nicName = nicName;
            _level = level;
            _ban = false;
        }

        public Player(Player i)
        {
            Number = i.Number;
            _nicName = i._nicName;
            _level = i._level;
            _ban = i.IsBan();
        }

        public void ShowInfo()
        {
            Console.WriteLine("Игрок № - " + Number + "\tЕго ник - " + _nicName + "\tУровень - " + _level + "\tБан - " + _ban);
        }
    }

    class RepoPlayers
    {
        private List<Player> _players;
        public List<Player> Players
        {
            get
            {
                List<Player> tmp = new List<Player>(_players.Count());
                _players.ForEach((i) =>
                {
                    tmp.Add(new Player(i));
                });
                return tmp;
            }
            private set
            {
                _players = value;
            }
        }

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

        public void DeletePlayer(int id)
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

        public void BanUnBan(int id, bool flag)
        {
            if (CheckQuantity()) return;

            bool isFindPlayer;

            isFindPlayer = Players.Exists(findPlayer => findPlayer.Number == id);
            if (isFindPlayer)
            {
                Player player = Players.Find(findPlayer => findPlayer.Number == id);
                if (player.IsBan() && flag)
                {
                    Console.WriteLine($"\nИгрок №{id} уже имеет бан");
                }
                else if (!player.IsBan() && !flag)
                {
                    Console.WriteLine($"\nИгрок №{player.Number} не забанен");
                }
                else
                {
                    if (flag)
                    {
                        player.Ban();
                        Console.WriteLine($"\nИгрок №{id} забанен");
                    }
                    else
                    {
                        player.UnBan();
                        Console.WriteLine($"\nИгрок №{player.Number} разбанен");
                    }
                }
            }
            else
            {
                Console.WriteLine($"\nИгрок с №{id} отсутствует");
            }
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }

        //public void BanPlayer(int id)
        //{
        //    if (CheckQuantity()) return;

        //    bool isFindPlayer;

        //    isFindPlayer = Players.Exists(findPlayer => findPlayer.Number == id);
        //    if (isFindPlayer)
        //    {
        //        Player player = Players.Find(findPlayer => findPlayer.Number == id);
        //        if (player.IsBan())
        //        {
        //            Console.WriteLine($"\nИгрок №{id} уже имеет бан");
        //        }
        //        else
        //        {
        //            player.Ban();
        //            Console.WriteLine($"\nИгрок №{id} забанен");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine($"\nИгрок с №{id} отсутствует");
        //    }
        //    Console.WriteLine("Нажмите любую клавишу...");
        //    Console.ReadKey();
        //}

        //public void UnBanPlayer(int id)
        //{
        //    if (CheckQuantity()) return;

        //    bool isFindPlayer;

        //    isFindPlayer = Players.Exists(findPlayer => findPlayer.Number == id);
        //    if (isFindPlayer)
        //    {
        //        Player player = Players.Find(findPlayer => findPlayer.Number == id);
        //        if (player.IsBan())
        //        {
        //            player.UnBan();
        //            Console.WriteLine($"\nИгрок №{player.Number} разбанен");
        //        }
        //        else
        //        {
        //            Console.WriteLine($"\nИгрок №{player.Number} не забанен");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine($"\nИгрок с №{id} отсутствует");
        //    }
        //    Console.WriteLine("Нажмите любую клавишу...");
        //    Console.ReadKey();
        //}

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
