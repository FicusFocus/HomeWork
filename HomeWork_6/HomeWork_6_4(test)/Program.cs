using System;
using System.Collections.Generic;

namespace HomeWork_6_4_test_
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            Seller seller = new Seller();

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Добро пожаловать в онлайн аптеку!");
                Console.WriteLine("Выберите действие:" +
                                  "\nПросмотр списка товаров - 1" +
                                  "\nПоиск товара по названию - 2" +
                                  "\nВыход - 0");

                switch (Console.ReadLine())
                {
                    case "1":
                        list.ShowAllProducts();
                        break;
                }
                Console.ReadLine();
            }
        }
    }
    class Seller
    {
        public int CashBox {get; private set;}

        
    }
    class List
    {
        private List<Product> _products = new List<Product>();
        public List()
        {
            _products.Add(new Product("Акорбинка", 5, 100));
            _products.Add(new Product("Аспирин", 30, 100));
            _products.Add(new Product("Димедрол", 30, 0));
        }
        public void ShowAllProducts()
        {
            for (int i = 0; i < _products.Count; i++)
            {
                if(_products[i].Amount > 0)
                {
                    Console.WriteLine($"{i + 1}){_products[i].Name}. стоимость - {_products[i].Price}. Есть в наличии");
                }
                else
                {
                    Console.WriteLine($"{i + 1}){_products[i].Name} - временно отсутствует.");
                }
            }

            _products[1].Amount -= 1;
        }
    }
    class Product
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public int Amount { get; private set; }

        public Product(string name, int price, int amount)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }
    }
    class Buyer
    {
        public int BuyerMoney { get; private set; }
    }
}
