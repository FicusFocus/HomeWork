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

        public Shop()
        {
            _productsList.Add(new Product("Аспирин", 30, 100));
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
        private List<Product> _basket = new List<Product>();
        private int _money;
    }
}
