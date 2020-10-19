using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVL_HomeWork_04
{
    class Program
    {
        static void Main(string[] args)
        {
            int goldCoins;
            int priceCrystals = 15;
            int byuCrystals;
            bool optionPurchase;

            Console.Write("Сколько у вас золотых монет? - ");
            goldCoins = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Цена кристалла {priceCrystals} монет. Сколько вы хотите купить кристаллов? - ");
            byuCrystals = Convert.ToInt32(Console.ReadLine());

            optionPurchase = goldCoins >= priceCrystals * byuCrystals;
            byuCrystals *= Convert.ToInt32(optionPurchase);
            goldCoins -= priceCrystals * byuCrystals;

            Console.WriteLine($"У вас в сумке осталось {goldCoins} монет и появилось {byuCrystals} кристаллов.");
        }
    }
}
