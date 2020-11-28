using System;
using System.Collections.Generic;

namespace YNI_Task_03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();
            string nameItem;
            int quantityItem;
            double priceItem;
            double sum = 0;



            nameItem = "тов1";
            quantityItem = Convert.ToInt32(Console.ReadLine());
            priceItem = (double)Convert.ToInt32("55") / (double)(quantityItem);
            Item item = new Item(nameItem, quantityItem, priceItem);
            items.Add(item);

            nameItem = "тов2";
            quantityItem = Convert.ToInt32(Console.ReadLine());
            priceItem = (double)Convert.ToInt32("75") / (double)(quantityItem);
            Item item1 = new Item(nameItem, quantityItem, priceItem);
            items.Add(item1);

            nameItem = "тов3";
            quantityItem = Convert.ToInt32(Console.ReadLine());
            priceItem = (double)Convert.ToInt32("91") / (double)Convert.ToInt32("23");
            Item item2 = new Item(nameItem, quantityItem, priceItem);
            items.Add(item2);

            foreach (var var_item in items)
            {
                sum += var_item.Price * var_item.Quantity;
            }

            Console.WriteLine(Math.Round(sum, 2));

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
}