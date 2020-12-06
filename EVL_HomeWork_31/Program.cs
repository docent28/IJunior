using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_31
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            string itemMenu;
            Seller seller = new Seller();
            Buyer buyer = new Buyer();

            while (!exit)
            {
                Console.WriteLine("1 - завезти товар в магазин");
                Console.WriteLine("2 - продать товар покупателю");
                Console.WriteLine("3 - показать товар в магазине");
                Console.WriteLine("4 - показать товар у покупателя");
                Console.WriteLine("5 - выйти из программы");
                Console.Write("\nВыберите нужный пункт - ");

                int cursorPositionRow = Console.CursorTop;
                int cursorPositionCol = Console.CursorLeft;
                Console.SetCursorPosition(0, 25);
                Console.WriteLine($"У покупателя в кошельке {Math.Round(buyer.Money, 2)} рублей.");
                Console.SetCursorPosition(cursorPositionCol, cursorPositionRow);

                itemMenu = Console.ReadLine();

                switch (itemMenu)
                {
                    case "1":
                        seller.CapitalizeItem(seller);
                        break;
                    case "2":
                        buyer.BuyItem(seller, buyer);
                        break;
                    case "3":
                        seller.ShowItems();
                        break;
                    case "4":
                        buyer.ShowItems();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.Write("\nОшибка ввода");
                        break;
                }

                Console.Write("\nНажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class TransactionParticipant
    {
        protected List<Item> Items;

        public TransactionParticipant()
        {
            Items = new List<Item>();
        }

        public void ShowItems()
        {
            decimal sum = 0;

            foreach (Item item in Items)
            {
                Console.WriteLine(item.Name + "\t" + item.Quantity + " шт.\t" + string.Format("{0:0.00}", item.Price) + " руб.");
                sum += item.Price * item.Quantity;
            }
            Console.WriteLine($"\nИтого товаров на сумму - " + string.Format("{0:0.00}", sum) + " руб.");
        }

        public bool IsItemAvailable(string nameItem)
        {
            return Items.Exists(findItem => findItem.Name == nameItem);
        }

        public void Add(Item item)
        {
            decimal averagePrice;

            if (IsItemAvailable(item.Name))
            {
                Item itemCurrent = Items.Find(findItem => findItem.Name == item.Name);
                averagePrice = Math.Round((item.Quantity * item.Price + itemCurrent.Quantity * itemCurrent.Price) / (item.Quantity + itemCurrent.Quantity), 2);
                itemCurrent.ChangeQuantity(item.Quantity);
                itemCurrent.ChangePrice(averagePrice);
            }
            else
            {
                Items.Add(item);
            }
        }
    }

    class Item
    {
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public Item(string name, int quantity, decimal price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public void ChangeQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public void ChangePrice(decimal price)
        {
            Price = price;
        }
    }

    class Seller : TransactionParticipant
    {
        public bool IsItemAvailable(string nameItem, int quantityItem)
        {
            Item item = Items.Find(findItem => findItem.Name == nameItem);
            return item.Quantity >= quantityItem;
        }

        public void CapitalizeItem(Seller seller)
        {
            string name;
            int quantity = 0;
            string numericValue;
            decimal price = 0;

            Console.Write("Введите наименование товара - ");
            name = Console.ReadLine();
            while (quantity <= 0)
            {
                Console.Write("Введите количество товара (> 0) - ");
                numericValue = Console.ReadLine();
                if (int.TryParse(numericValue, out quantity))
                {
                    if (quantity <= 0)
                    {
                        Console.Write("Неправильное значение. Необходимо значение больше 0\n\nНажмите любую клавишу...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Write("Неправильное значение. Необходимо числовое значение\n\nНажмите любую клавишу...");
                    Console.ReadKey();
                }
            }
            while (price <= 0)
            {
                Console.Write("Введите стоимость товара (> 0) - ");
                numericValue = Console.ReadLine();
                if (decimal.TryParse(numericValue, out price))
                {
                    if (quantity <= 0)
                    {
                        Console.Write("Неправильное значение. Необходимо значение больше 0\n\nНажмите любую клавишу...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Write("Неправильное значение. Необходимо числовое значение\n\nНажмите любую клавишу...");
                    Console.ReadKey();
                }
            }
            if (seller.IsItemAvailable(name))
            {
                Console.WriteLine("\nТакой товар уже есть в списке\nНа складе товар будет храниться по средней цене");
            }

            seller.Add(new Item(name, quantity, price));
            Console.Write("\nТовар добавлен");
        }

        public Item Sell(string nameItem, int quantityItem)
        {
            Item itemCurrent = Items.Find(findItem => findItem.Name == nameItem);
            itemCurrent.ChangeQuantity(-1 * quantityItem);
            Item item = new Item(nameItem, quantityItem, itemCurrent.Price);

            if (itemCurrent.Quantity == 0)
            {
                Items.Remove(itemCurrent);
            }

            return item;
        }

        public decimal SetPrice(string nameItem)
        {
            decimal price;
            Random random = new Random();

            Item itemSold = Items.Find(findItem => findItem.Name == nameItem);
            price = Math.Round(itemSold.Price + itemSold.Price * Convert.ToDecimal(random.NextDouble()), 2);

            return price;
        }
    }

    class Buyer : TransactionParticipant
    {
        public decimal Money { get; private set; }

        public Buyer()
        {
            Random random = new Random();
            Money = random.Next(500);
        }

        public void BuyItem(Seller seller, Buyer buyer)
        {
            string name;
            int quantity = 0;
            decimal price;
            string numericValue;

            Console.Write("Введите наименование приобретаемого товара - ");
            name = Console.ReadLine();
            if (seller.IsItemAvailable(name))
            {
                price = seller.SetPrice(name);
                Console.Write($"Я продам вам товар по цене - {price}\nВы согласны приобрести товар? y/n - ");
                if (Console.ReadLine().ToLower() != "y")
                {
                    Console.WriteLine("Вы отказались от покупки. Я жду вас в другой раз");
                    return;
                }
                while (quantity <= 0)
                {
                    Console.Write("Введите количество приобретаемого товара - ");
                    numericValue = Console.ReadLine();
                    if (int.TryParse(numericValue, out quantity))
                    {
                        if (quantity <= 0)
                        {
                            Console.Write("Неправильное значение. Необходимо значение больше 0\n\nНажмите любую клавишу...");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.Write("Неправильное значение. Необходимо числовое значение\n\nНажмите любую клавишу...");
                        Console.ReadKey();
                    }
                }

                if (seller.IsItemAvailable(name, quantity))
                {
                    if ((price * quantity) > buyer.Money)
                    {
                        Console.WriteLine($"У меня всего {string.Format("{0:0.00}", buyer.Money)} рублей.\nПриду позже");
                    }
                    else
                    {
                        Item buyItem = seller.Sell(name, quantity);
                        buyItem.ChangePrice(price);
                        buyer.BuyItem(buyItem);
                        Console.Write("\nТовар продан покупателю");
                    }
                }
                else
                {
                    Console.Write("\nНеобходимого количества нет в наличии");
                }
            }
            else
            {
                Console.Write("\nУказанного товара нет в продаже");
            }
        }

        public void BuyItem(Item item)
        {
            Pay(item.Price * item.Quantity);
            Add(item);
        }

        private void Pay(decimal payment)
        {
            Money -= payment;
        }
    }
}
