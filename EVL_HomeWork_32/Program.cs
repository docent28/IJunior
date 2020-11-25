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


            Direction direction = new Direction();
            Console.WriteLine(direction.CreateRoute());

            Ticket ticket = new Ticket();
            quantityTicket = ticket.SellTickets();
            Console.WriteLine($"Продано {quantityTicket} билетов");

            FastTrain fastTrain = new FastTrain();
            listCarriages = fastTrain.CreateTrain(quantityTicket);

            Console.WriteLine("Поезд состоит из вагонов следующей вместимости:");
            Console.WriteLine(listCarriages);
        }
    }

    class Direction     // направление
    {
        private string _departureStation;       // станция отправления
        private string _destinationStation;     // станция назначения
        private string[] _cities = { "Саранск",     "Сызрань",     "Нерюнгри",   "Смоленск",   "Ессентуки",  "Славгород",
                                     "Саяногорск",  "Новокузнецк", "Звенигород", "Всеволожск", "Новодвинск", "Завитинск",
                                     "Владивосток", "Оленегорск",  "Нефтегорск", "Биробиджан", "Чебоксары",  "Байкальск",
                                     "Снежинск",    "Кострома",    "Енисейск",   "Балтийск",   "Шелехов",    "Балашиха",
                                     "Харовск",     "Туринск",     "Вологда",    "Когалым",    "Плесецк",    "Суздаль"};

        public Direction() { }

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

    class Ticket        // билет
    {
        public int Quantity { get; private set; }           // количество билетов

        public Ticket() { }

        public int SellTickets()
        {
            Random rand = new Random();
            Quantity = rand.Next(5, 201);

            return Quantity;
        }
    }

    class Carriage      // вагон
    {
        public int WagonCapacity { get; private set; }             // вместимость вагона
        static Random rand = new Random();

        public Carriage()
        {
            WagonCapacity = rand.Next(15, 46);
        }
    }

    class FastTrain     // скорый поезд
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
