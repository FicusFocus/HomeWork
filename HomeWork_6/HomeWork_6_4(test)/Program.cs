using System;
using System.Collections.Generic;

namespace HomeWork_6_4_test_
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    class Shop
    {
        private List<Product> _productsList = new List<Product>();
        private List<Product> _basket = new List<Product>();
        private List<Product> _BuyerProducts = new List<Product>();

        public Shop()
        {
            _productsList.Add(new Product("Аспирин", 30, 100));
            _productsList.Add(new Product("Аскорбинка", 5, 100));
            _productsList.Add(new Product("Уголь активированный", 10, 100));
        }

        public void ShowProductList()
        {
                for (int i = 0; i < _productsList.Count; i++)
                {
                    if (_productsList[i].Amount > 0)
                        Console.WriteLine($"{i}) {_productsList[i].Name} - нет в наличии");
                    else
                        Console.WriteLine($"{i}) {_productsList[i].Name} - {_productsList[i].Price} руб.");
                }
        }

        public void AddToBasket()
        {

        }

        public void BuyAProduct()
        {

        }

        public void ShowPurchasedItems()
        {

        }
    }
    class Product
    {
        public int Amount { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Product(string name, int prise, int amount)
        {
            Name = name;
            Price = Price;
            Amount = amount;
        }
    }
    class Buyer
    {
        private int _money;
    }
}
