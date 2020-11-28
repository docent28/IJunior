using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_32
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityTicket;
            string listCarriages;
            bool exit = false;
            string menuItem;
            int colRowInfo = 13;
            int oldRow;
            int rowInfo = 0;

            while (!exit)
            {
                if (rowInfo > colRowInfo)
                {
                    rowInfo = 0;
                }
                Console.SetCursorPosition(0, 15);
                Console.WriteLine("Информация о направлениях, билетах и составе поезда отображается в верхней части экрана");
                Console.WriteLine("Шаг 1 - создать направление");
                oldRow = Console.CursorTop;
                Console.Write("\n\n\n\nНажмите любую клавишу...");
                Console.ReadKey();
                Direction direction = new Direction();
                Console.SetCursorPosition(0, rowInfo);
                Console.WriteLine(direction.CreateRoute());

                Console.SetCursorPosition(0, oldRow);
                Console.WriteLine("Шаг 2 - продать билеты");
                oldRow = Console.CursorTop;
                Console.Write("\n\n\nНажмите любую клавишу...");
                Console.ReadKey();
                CashDesk ticket = new CashDesk();
                quantityTicket = ticket.SellTickets();
                Console.SetCursorPosition(50, rowInfo);
                Console.WriteLine($"Продано {quantityTicket} билетов");

                Console.SetCursorPosition(0, oldRow);
                Console.WriteLine("Шаг 3 - собрать состав");
                oldRow = Console.CursorTop;
                Console.Write("\n\nНажмите любую клавишу...");
                Console.ReadKey();
                FastTrain fastTrain = new FastTrain();
                listCarriages = fastTrain.CreateTrain(quantityTicket);

                Console.SetCursorPosition(10, ++rowInfo);
                Console.Write("Поезд состоит из вагонов следующей вместимости: - ");
                Console.Write(listCarriages);
                Console.SetCursorPosition(85, rowInfo);
                Console.WriteLine("\tОжидает отправки ");

                Console.SetCursorPosition(0, oldRow);
                Console.WriteLine("Шаг 4 - отправить состав");
                Console.Write("\nНажмите любую клавишу...");
                oldRow = Console.CursorTop;
                Console.ReadKey();
                Console.SetCursorPosition(85, rowInfo);
                Console.WriteLine("\tВ пути           ");
                rowInfo = Console.CursorTop;

                Console.SetCursorPosition(0, oldRow);
                Console.Write("Продолжаем отправлять поезда? y/n - ");
                menuItem = Console.ReadLine();

                while (menuItem != "y" && menuItem != "n")
                {
                    Console.SetCursorPosition(0, oldRow);
                    Console.Write(String.Format("{0,37}", " "));
                    Console.SetCursorPosition(0, oldRow);
                    Console.Write(String.Format("{0,100}", " "));
                    Console.SetCursorPosition(0, oldRow);
                    Console.Write("Ошибка ввода. Введите y или n - ");
                    menuItem = Console.ReadLine();
                }
                if (menuItem == "n")
                {
                    exit = true;
                }
                else if (menuItem == "y")
                {
                    Console.SetCursorPosition(0, oldRow);
                    Console.Write(String.Format("{0,37}", " "));

                    Console.SetCursorPosition(0, 16);
                    for (int i = 0; i < 4; i++)
                    {
                        Console.WriteLine(String.Format("{0,37}", " "));
                    }

                    if (rowInfo > 13)
                    {
                        Console.SetCursorPosition(0, 0);
                        for (int i = 0; i < 14; i++)
                        {
                            Console.WriteLine(String.Format("{0,95}", " "));
                        }
                        Console.SetCursorPosition(0, 16);
                    }
                }
            }
        }
    }

    class Direction
    {
        private string _departureStation;
        private string _destinationStation;
        private string[] _cities = { "Саранск",     "Сызрань",     "Нерюнгри",   "Смоленск",   "Ессентуки",  "Славгород",
                                     "Саяногорск",  "Новокузнецк", "Звенигород", "Всеволожск", "Новодвинск", "Завитинск",
                                     "Владивосток", "Оленегорск",  "Нефтегорск", "Биробиджан", "Чебоксары",  "Байкальск",
                                     "Снежинск",    "Кострома",    "Енисейск",   "Балтийск",   "Шелехов",    "Балашиха",
                                     "Харовск",     "Туринск",     "Вологда",    "Когалым",    "Плесецк",    "Суздаль"};

        public string CreateRoute()
        {
            Random rand = new Random();
            _departureStation = _cities[rand.Next(_cities.Length)];
            _destinationStation = _cities[rand.Next(_cities.Length)];

            while (_departureStation == _destinationStation)
            {
                _destinationStation = _cities[rand.Next(_cities.Length)];
            }
            return $"Поезд направления {_departureStation} - {_destinationStation}";
        }
    }

    class CashDesk
    {
        public int Quantity { get; private set; }

        public int SellTickets()
        {
            Random rand = new Random();
            Quantity = rand.Next(5, 201);

            return Quantity;
        }
    }

    class Carriage
    {
        public int WagonCapacity { get; private set; }
        private static Random _rand = new Random();

        public Carriage()
        {
            WagonCapacity = _rand.Next(15, 46);
        }
    }

    class FastTrain
    {
        private List<Carriage> _carriages = new List<Carriage>();
        private string _trainComposition = "";
        private int _quantityPlaces = 0;

        public string CreateTrain(int quantiteTicket)
        {
            while (quantiteTicket > _quantityPlaces)
            {
                Carriage carriage = new Carriage();
                _quantityPlaces += carriage.WagonCapacity;
                _carriages.Add(carriage);
            }

            foreach (var carrige in _carriages)
            {
                _trainComposition += carrige.WagonCapacity + " ";
            }

            return _trainComposition;
        }
    }
}
