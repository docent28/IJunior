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
            Direction direction = new Direction();
            Console.WriteLine($"Поезд направления {direction.DepartureStation} - {direction.DestinationStation}");
            Ticket ticket = new Ticket();
            Console.WriteLine($"Продано {ticket.Quantity} билетов");
        }
    }

    class Direction     // направление
    {
        public string DepartureStation { get; private set; }       // станция отправления
        public string DestinationStation { get; private set; }     // станция назначения
        private string[] _cities = { "Саранск",     "Сызрань",     "Нерюнгри",   "Смоленск",   "Ессентуки",  "Славгород",
                                     "Саяногорск",  "Новокузнецк", "Звенигород", "Всеволожск", "Новодвинск", "Завитинск",
                                     "Владивосток", "Оленегорск",  "Нефтегорск", "Биробиджан", "Чебоксары",  "Байкальск",
                                     "Снежинск",    "Кострома",    "Енисейск",   "Балтийск",   "Шелехов",    "Балашиха",
                                     "Харовск",     "Туринск",     "Вологда",    "Когалым",    "Плесецк",    "Суздаль"};

        public Direction()
        {
            Random rand = new Random();
            DepartureStation = _cities[rand.Next(_cities.Length)];
            DestinationStation = _cities[rand.Next(_cities.Length)];

            while (DepartureStation == DestinationStation)
            {
                DestinationStation = _cities[rand.Next(_cities.Length)];
            }
        }
    }

    class Ticket        // билет
    {
        public int Quantity { get; private set; }           // количество билетов

        public Ticket()
        {
            Random rand = new Random();
            Quantity = rand.Next(5, 201);
        }
    }

    class Carriage      // вагон
    {
        public int WagonCapacity { get; private set; }             // вместимость вагона

        public Carriage()
        {
            Random rand = new Random();
            WagonCapacity = rand.Next(15, 46);
        }
    }

    class FastTrain     // скорый поезд
    {
        private List<Carriage> _carriages = new List<Carriage>();

    }
}
