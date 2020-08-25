using System;
using System.Collections.Generic;

namespace HomeWork_6_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Seller seller = new Seller();
            Buyer buyer = new Buyer();
            List<Product> products = new List<Product>();

            bool isWork = true;

            products.Add(new Product(products.Count + 1, "Анальгин", 100));
            products.Add(new Product(products.Count + 1, "Димедрол", 100));
            products.Add(new Product(products.Count + 1, "Аспирин", 100));
            products.Add(new Product(products.Count + 1, "Панкриатин", 100));
            products.Add(new Product(products.Count + 1, "Алахол", 100));
            products.Add(new Product(products.Count + 1, "Хлоргикседин", 100));
            products.Add(new Product(products.Count + 1, "Уголь активированный", 100));
            products.Add(new Product(products.Count + 1, "Аскорбинка", 100));
            products.Add(new Product(products.Count + 1, "Систейн", 100));

            while (isWork)
            {
                Console.SetCursorPosition(25, 0);
                Console.WriteLine("Онлайн аптека.");
                Console.WriteLine("\n\nСписок товаров:");
                for (int i = 0; i < products.Count; i++)
                    products[i].ShowInfo();
                Console.WriteLine("Введите номер товара который желаете добавить в корзину: ");


                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case (1):
                        break;
                }


                Console.SetCursorPosition(0, 20);
                Console.WriteLine("Сумма покупок: " + buyer.PurchaseAmount);
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    class Seller
    {
        public int _sellerMoney { get; private set; }
    }

    class Buyer
    {
        public int PurchaseAmount { get; private set; }
    }

    class Product
    {
        public int ProductNumber { get; private set; }
        public int Price { get; private set; }
        public string Name { get; private set; }
        public int Amount { get; private set; }

        public Product(int productNumber, string name, int price, int amount = 30)
        {
            ProductNumber = productNumber;
            Name = name;
            Price = price;
            Amount = amount;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{ProductNumber}) {Name} - {Price} руб. на складе осталось - {Amount}");
        }
    }
}
