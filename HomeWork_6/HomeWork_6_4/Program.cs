using System;

namespace HomeWork_6_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Seller seller = new Seller();
            Buyer buyer = new Buyer();
            Product[] products = new Product[];


        }
    }

    class Seller
    {
        private int _sellerMoney;
    }

    class Buyer
    {
        private int _buyerMoney;
    }

    class Product
    {
        private int _productNumber;
        public int Price;
        public string Name;

        public Product(int productNumber, string name, int price)
        {
            _productNumber = productNumber;
            Name = name;
            Price = price;
        }
    }
}
