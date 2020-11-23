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

                menuItem = Console.ReadLine();

                switch (menuItem)
                {
                    case "1":
                        Console.Write("Введите наименование товара - ");
                        nameItem = Console.ReadLine();
                        Console.Write("Введите количество товара - ");
                        quantityItem = Convert.ToInt32(Console.ReadLine());
                        if (seller.IsExist(nameItem))
                        {
                            Console.WriteLine("\nТакой товар уже есть в списке\nПриходуем по старой цене");
                            priceItem = 0;
                        }
                        else
                        {
                            Console.Write("Введите стоимость товара - ");
                            priceItem = Convert.ToDouble(Console.ReadLine());
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
                                buyer.BuyItem(bayItem);
                                Console.Write("\nТовар продан покупателю");
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

    class Item      // Товар
    {
        public string Name { get; }

        public int Quantity { get; set; }

        public double Price { get; }

        public Item(string name, int quantity, double price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }
    }

    class Seller    // Продавец
    {
        private List<Item> _itemsSeller;

        public Seller()
        {
            _itemsSeller = new List<Item>();
        }

        public void ShowItem()
        {
            foreach (var item in _itemsSeller)
            {
                Console.WriteLine(item.Name + "\t" + item.Quantity + " шт.\t" + item.Price + " руб.");
            }
        }

        public void Add(Item item)
        {
            if (IsExist(item.Name))
            {
                Item itemAdd = _itemsSeller.Find(findItem => findItem.Name == item.Name);
                itemAdd.Quantity += item.Quantity;
            }
            else
            {
                _itemsSeller.Add(item);
            }
        }

        public bool IsExist(string nameItem)
        {
            return _itemsSeller.Exists(findItem => findItem.Name == nameItem);
        }

        public bool IsQuantity(string nameItem, int quantityItem)
        {
            Item item = _itemsSeller.Find(findItem => findItem.Name == nameItem);
            return item.Quantity >= quantityItem;
        }

        public Item Sell(string nameItem, int quantityItem)
        {
            Item itemSold = _itemsSeller.Find(findItem => findItem.Name == nameItem);
            itemSold.Quantity -= quantityItem;
            Item item = new Item(nameItem, quantityItem, itemSold.Price);

            if (itemSold.Quantity == 0)
            {
                _itemsSeller.Remove(itemSold);
            }

            return item;
        }
    }

    class Buyer     // Покупатель
    {
        private List<Item> _itemsBuyer;

        public Buyer()
        {
            _itemsBuyer = new List<Item>();
        }

        public bool IsExist(string nameItem)
        {
            return _itemsBuyer.Exists(findItem => findItem.Name == nameItem);
        }

        public void BuyItem(Item item)
        {
            if (IsExist(item.Name))
            {
                Item itemPurchase = _itemsBuyer.Find(findItem => findItem.Name == item.Name);
                itemPurchase.Quantity += item.Quantity;
            }
            else
            {
                _itemsBuyer.Add(item);
            }
        }

        public void ShowItem()
        {
            foreach (var item in _itemsBuyer)
            {
                Console.WriteLine(item.Name + "\t" + item.Quantity + " шт.\t" + item.Price + " руб.");
            }
        }
    }
}
