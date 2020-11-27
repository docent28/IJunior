﻿using System;
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
            int quantityItem;
            double priceItem;
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
                        priceItem = Convert.ToDouble(Console.ReadLine());
                        if (seller.IsExist(nameItem))
                        {
                            Console.WriteLine("\nТакой товар уже есть в списке\nНа складе товар будет храниться по средней цене");
                        }
                        Item item = new Item(nameItem, quantityItem, priceItem);
                        seller.Add(item);
                        Console.Write("\nТовар добавлен");
                        break;
                    case "2":
                        Console.Write("Введите наименование продаваемого товара - ");
                        nameItem = Console.ReadLine();
                        if (seller.IsExist(nameItem))
                        {
                            Console.Write("Введите количество продаваемого товара - ");
                            quantityItem = Convert.ToInt32(Console.ReadLine());
                            if (seller.IsQuantity(nameItem, quantityItem))
                            {
                                Item bayItem = seller.Sell(nameItem, quantityItem);
                                buyer.SetPrice();
                                priceItem = buyer.Price;
                                if ((priceItem * quantityItem) > buyer.Money)
                                {
                                    Console.WriteLine($"У меня всего {string.Format("{0:0.00}", buyer.Money)} рублей.\nПриду позже");
                                }
                                else
                                {
                                    bayItem.Price = priceItem;
                                    buyer.PaymentItem(priceItem * quantityItem);
                                    buyer.Add(bayItem);
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
                        seller.ShowItem();
                        break;
                    case "4":
                        buyer.ShowItem();
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
        private double _sum;
        private double _averagePrice;

        public TransactionParticipant()
        {
            Items = new List<Item>();
        }

        public void ShowItem()
        {
            _sum = 0;
            foreach (Item item in Items)
            {
                Console.WriteLine(item.Name + "\t" + item.Quantity + " шт.\t" + string.Format("{0:0.00}", item.Price) + " руб.");
                _sum += item.Price * item.Quantity;
            }
            Console.WriteLine($"\nИтого товаров на сумму - " + string.Format("{0:0.00}", _sum) + " руб.");
        }

        public bool IsExist(string nameItem)
        {
            return Items.Exists(findItem => findItem.Name == nameItem);
        }

        public void Add(Item item)
        {
            if (IsExist(item.Name))
            {
                Item itemAdd = Items.Find(findItem => findItem.Name == item.Name);
                _averagePrice = (item.Quantity * item.Price + itemAdd.Quantity * itemAdd.Price) / (item.Quantity + itemAdd.Quantity);
                itemAdd.Quantity += item.Quantity;
                itemAdd.Price = _averagePrice;
            }
            else
            {
                Items.Add(item);
            }
        }
    }

    class Item
    {
        public string Name { get; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Item(string name, int quantity, double price)
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
    }

    class Buyer : TransactionParticipant
    {
        public double Price { get; private set; }
        public double Money { get; private set; }

        public Buyer()
        {
            Random rand = new Random();
            Money = rand.Next(500);
        }

        public void PaymentItem(double payment)
        {
            Money -= payment;
        }

        public void SetPrice()
        {
            Console.Write("По какой цене вы продаете товар? - ");
            Price = Convert.ToDouble(Console.ReadLine());
        }
    }
}
