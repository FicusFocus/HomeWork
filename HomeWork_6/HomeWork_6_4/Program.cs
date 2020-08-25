using System;
using System.Collections.Generic;


//TODO: прибавка суммы товара в корзину.
//TODO: организовать вывод корзины.
//TODO: сделать swith списсок товаров, выбрать товар, показать корзину, купить товар.

namespace HomeWork_6_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Seller seller = new Seller();
            Buyer buyer = new Buyer();
            FindProduct find = new FindProduct();
            List<Product> products = new List<Product>();
            Dictionary<string, int> shoppingСart = new Dictionary<string, int>();

            bool isWork = true;
            int productNumber;

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

                Console.WriteLine("\nВведите номер товара который желаете добавить в корзину: ");

                find.Find(products, out productNumber);
                shoppingСart.Add(products[productNumber].Name, products[productNumber].Price);
                
                



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

        public void ShoppingСart(string productName, int cost)
        {

        }
    }

    class FindProduct
    {
        public void Find(List<Product> products, out int number)
        {
            bool isCorrect = true;
            number = Convert.ToInt32(Console.ReadLine());

            if (number > products.Count || number <= 0)
            {
                while (isCorrect)
                {
                    if (number > products.Count || number < 0)
                    {
                        Console.WriteLine("Продукта с таким номером не существует. Введите номер повторно.");
                        number = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                        isCorrect = false;
                }
            }
        }
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
