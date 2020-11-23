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
                        seller.AddItem(item);
                        Console.Write("\nТовар добавлен\nНажмите любую клавишу...");
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
                                priceItem = seller.SellItem(nameItem, quantityItem);
                                buyer.BuyingItem(nameItem, quantityItem, priceItem);
                                Console.Write("\nТовар продан покупателю\nНажмите любую клавишу...");
                            }
                            else
                            {
                                Console.Write("\nНеобходимого количества нет в наличии\nНажмите любую клавишу...");
                            }
                        }
                        else
                        {
                            Console.Write("\nУказанного товара нет в продаже\nНажмите любую клавишу...");
                        }
                        break;
                    case "3":
                        seller.ShowSellerItem();
                        Console.WriteLine("\nНажмите любую клавишу...");
                        break;
                    case "4":
                        buyer.ShowBuyerItem();
                        Console.WriteLine("\nНажмите любую клавишу...");
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("\nНажмите любую клавишу...");
                        break;
                    default:
                        Console.Write("\nОшибка ввода\nНажмите любую клавишу...");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Item      // Товар
    {
        private string _name;
        private int _quantity;
        private double _price;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                _quantity = value;
            }
        }

        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public Item(string name, int quantity, double price)
        {
            _name = name;
            _quantity = quantity;
            _price = price;
        }
    }

    class Seller    // Продавец
    {
        private List<Item> _itemsSeller;

        public Seller()
        {
            _itemsSeller = new List<Item>();
        }

        public void ShowSellerItem()
        {
            foreach (var item in _itemsSeller)
            {
                Console.WriteLine(item.Name + "\t" + item.Quantity + " шт.\t" + item.Price + " руб.");
            }
        }

        public void AddItem(Item item)
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
            return isExist(nameItem);
        }

        private bool isExist(string nameItem)
        {
            return _itemsSeller.Exists(findItem => findItem.Name == nameItem);
        }

        public bool IsQuantity(string nameItem, int quantityItem)
        {
            return isQuantity(nameItem, quantityItem);
        }

        private bool isQuantity(string nameItem, int quantityItem)
        {
            Item item = _itemsSeller.Find(findItem => findItem.Name == nameItem);
            return item.Quantity >= quantityItem;
        }

        public double SellItem(string nameItem, int quantityItem)
        {
            Item itemSold = _itemsSeller.Find(findItem => findItem.Name == nameItem);
            itemSold.Quantity -= quantityItem;

            return itemSold.Price;
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
            return isExist(nameItem);
        }

        private bool isExist(string nameItem)
        {
            return _itemsBuyer.Exists(findItem => findItem.Name == nameItem);
        }

        public void BuyingItem(string nameItem, int quantityItem, double priceItem)
        {
            Item item = new Item(nameItem, quantityItem, priceItem);
            if (IsExist(nameItem))
            {
                Item itemPurchase = _itemsBuyer.Find(findItem => findItem.Name == nameItem);
                itemPurchase.Quantity += quantityItem;
            }
            else
            {
                _itemsBuyer.Add(item);
            }
        }

        public void ShowBuyerItem()
        {
            foreach (var item in _itemsBuyer)
            {
                Console.WriteLine(item.Name + "\t" + item.Quantity + " шт.\t" + item.Price + " руб.");
            }
        }
    }
}
