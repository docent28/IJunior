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
            string menuItem;
            string nameItem;
            string buyerConsent;
            int quantityItem;
            decimal priceItem;
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

                int oldRow = Console.CursorTop;
                int oldCol = Console.CursorLeft;
                Console.SetCursorPosition(0, 25);
                Console.WriteLine($"У покупателя в кошельке {Math.Round(buyer.Money, 2)} рублей.");
                Console.SetCursorPosition(oldCol, oldRow);

                menuItem = Console.ReadLine();

                switch (menuItem)
                {
                    case "1":
                        Console.Write("Введите наименование товара - ");
                        nameItem = Console.ReadLine();
                        Console.Write("Введите количество товара - ");
                        quantityItem = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите стоимость товара - ");
                        priceItem = Convert.ToDecimal(Console.ReadLine());
                        if (seller.IsExist(nameItem))
                        {
                            Console.WriteLine("\nТакой товар уже есть в списке\nНа складе товар будет храниться по средней цене");
                        }
                        Item item = new Item(nameItem, quantityItem, priceItem);
                        seller.Add(item);
                        Console.Write("\nТовар добавлен");
                        break;
                    case "2":
                        Console.Write("Введите наименование приобретаемого товара - ");
                        nameItem = Console.ReadLine();
                        if (seller.IsExist(nameItem))
                        {
                            priceItem = seller.SetPrice(nameItem);
                            Console.Write($"Я продам вам товар по цене - {priceItem}\nВы согласны приобрести товар? y/n - ");
                            buyerConsent = Console.ReadLine();
                            if (buyerConsent != "y")
                            {
                                Console.WriteLine("Вы отказались от покупки. Я жду вас в другой раз");
                                break;
                            }
                            Console.Write("Введите количество приобретаемого товара - ");
                            quantityItem = Convert.ToInt32(Console.ReadLine());
                            if (seller.IsQuantity(nameItem, quantityItem))
                            {
                                if ((priceItem * quantityItem) > buyer.Money)
                                {
                                    Console.WriteLine($"У меня всего {string.Format("{0:0.00}", buyer.Money)} рублей.\nПриду позже");
                                }
                                else
                                {
                                    Item bayItem = seller.Sell(nameItem, quantityItem);
                                    bayItem.Price = priceItem;

                                    buyer.BuyItem(bayItem);
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

        public bool IsExist(string nameItem)
        {
            return Items.Exists(findItem => findItem.Name == nameItem);
        }

        public void Add(Item item)
        {
            decimal averagePrice;

            if (IsExist(item.Name))
            {
                Item itemAdd = Items.Find(findItem => findItem.Name == item.Name);
                averagePrice = (item.Quantity * item.Price + itemAdd.Quantity * itemAdd.Price) / (item.Quantity + itemAdd.Quantity);
                itemAdd.Quantity += item.Quantity;
                itemAdd.Price = Math.Round(averagePrice, 2);
            }
            else
            {
                if (item.Quantity > 0)
                {
                    Items.Add(item);
                }
            }
        }
    }

    class Item
    {
        public string Name { get; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Item(string name, int quantity, decimal price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }
    }

    class Seller : TransactionParticipant
    {
        public bool IsQuantity(string nameItem, int quantityItem)
        {
            Item item = Items.Find(findItem => findItem.Name == nameItem);
            return item.Quantity >= quantityItem;
        }

        public Item Sell(string nameItem, int quantityItem)
        {
            Item itemSold = Items.Find(findItem => findItem.Name == nameItem);
            itemSold.Quantity -= quantityItem;
            Item item = new Item(nameItem, quantityItem, itemSold.Price);

            if (itemSold.Quantity == 0)
            {
                Items.Remove(itemSold);
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
            Random rand = new Random();
            Money = rand.Next(500);
        }

        public void BuyItem(Item bayItem)
        {
            PayItem(bayItem.Price * bayItem.Quantity);
            Add(bayItem);
        }

        private void PayItem(decimal payment)
        {
            Money -= payment;
        }
    }
}
