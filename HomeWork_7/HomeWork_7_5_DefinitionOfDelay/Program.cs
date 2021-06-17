using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_7_5_DefinitionOfDelay
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> storage = new List<Product>();

            storage.Add(new Product("тушенка из говядины", 2010, 5));
            storage.Add(new Product("тушенка из свинины", 2011, 4));
            storage.Add(new Product("тушенка из баранины", 2010, 7));

            Console.Write("Введите сегдняшнюю дату: ");
            bool result = int.TryParse(Console.ReadLine(), out int currentDate);

            var delayProdects = storage.Where(stew => stew.ManufactureDate + stew.ShelfLife < currentDate);

            foreach (var stew in delayProdects)
                Console.WriteLine($"{stew.Name}. Дата производства - {stew.ManufactureDate}," +
                                  $" употредить до - {stew.ManufactureDate + stew.ShelfLife}");
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public int ManufactureDate { get; private set; }
        public int ShelfLife { get; private set; }

        public Product(string name, int manufacturedate, int shelfLife)
        {
            Name = name;
            ManufactureDate = manufacturedate;
            ShelfLife = shelfLife;
        }
    }
}
