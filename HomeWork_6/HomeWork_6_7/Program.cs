﻿using System;
using System.Collections.Generic;

namespace HomeWork_6_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int productsAmount = 0;
            int buyersAmount = 10;

            Shop seller = new Shop(ref productsAmount);
            Random rand = new Random();

            while (buyersAmount > 0)
            {
                Buyer buyer = new Buyer();

                int productsInBasket = rand.Next(1, 10);

                Console.WriteLine("Очередной посетитель желает приобрести следующие товары:");

                for (int i = 0; i < productsInBasket; i++)
                {
                    int productNumber = rand.Next(0, productsAmount);

                    if (seller.CheckProductAvailability(productNumber, out string productName, out int productPrice))
                    {
                        buyer.AddToBasket(productName, productPrice);
                        seller.SubtractProductsAmount(productName);
                    }
                }

                buyer.ShowBasket();
                
                while(buyer.CheckSolvency() == false)
                {
                    string productName = null;

                    buyer.ChangeBasket(ref productName);
                    seller.AddProductsAmount(productName);
                }

                Console.WriteLine("На складе:\n");
                seller.ShowProducts();
                seller.AddMoney(buyer.MoneyToPay);
                buyer = null;
                buyersAmount--;
                Console.WriteLine($"\nПокупатель обслужен. Еще в очереди находится {buyersAmount} покупателей.");
                seller.SowMoney();
                Console.ReadLine();
            }

            Console.WriteLine("Все покупатели были обслужены.");
        }
    }

    class Shop
    {
        private int _money = 0;
        private List<Product> _products = new List<Product>();
        private Queue<Buyer> _buyers = new Queue<Buyer>();

        public Shop(ref int productAmount)
        {
            _products.Add(new Product("Колбаска", 260, 100));
            _products.Add(new Product("Сыр", 370, 100));
            _products.Add(new Product("Хлеб", 20, 100));
            _products.Add(new Product("Шоколадка", 70, 100));
            _products.Add(new Product("Пильмеши", 280, 100));

            productAmount = _products.Count;
        }

        public void AddMoney(int moneyToPay)
        {
            _money += moneyToPay;
        }

        public void ShowProducts()
        {
            for (int i = 0; i < _products.Count; i++)
            {
                Console.WriteLine($"{_products[i].Name}, " +
                                  $"{_products[i].Price}. " +
                                  $"В наличии - {_products[i].Amount} штук.");
            }
        }

        public void ShowBuyersBasket()
        {
            foreach (var buyer in _buyers)
            {
                buyer.ShowBasket();
                Console.WriteLine("\n");
            }
        }

        public bool CheckProductAvailability(int productNumber, out string productName, out int productPrice)
        {
            productName = null;
            productPrice = 0;

            if (productNumber < 0 || productNumber > _products.Count)
            {
                return false;
            }
            else
            {
                if (_products[productNumber].Amount == 0)
                {
                    return false;
                }
                else
                {
                    productName = _products[productNumber].Name;
                    productPrice = _products[productNumber].Price;
                    return true;
                }
            }
        }

        public void SubtractProductsAmount(string productName)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].Name == productName)
                {
                    _products[i].SubtractAmount();
                    continue;
                }
            }
        }

        public void AddProductsAmount(string productName)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].Name == productName)
                {
                    _products[i].AddAmount();
                    continue;
                }
            }
        }

        public void SowMoney()
        {
            Console.WriteLine($"на счету - {_money} рублей");
        }
    }

    class Buyer
    {
        public int MoneyToPay { get; private set; } = 0;
        private int _money;
        private List<Product> _basket = new List<Product>();

        public Buyer()
        {
            Random rand = new Random();
            _money = rand.Next(500, 2000);
        }

        public void AddToBasket(string productName, int productPrice)
        {
            bool alreadyInBasket = false;
            int numberInBasket = 0;
            for (int i = 0; i < _basket.Count; i++)
            {
                if (_basket[i].Name == productName)
                {
                    numberInBasket = i;
                    i = _basket.Count;
                    alreadyInBasket = true;
                }
                else
                {
                    alreadyInBasket = false;
                }
            }
            if (alreadyInBasket)
            {
                _basket[numberInBasket].AddAmount();
                MoneyToPay += _basket[numberInBasket].Price;
            }
            else
            {
                _basket.Add(new Product(productName, productPrice, 1));
                MoneyToPay += _basket[_basket.Count - 1].Price;
            }
        }

        public void ShowBasket()
        {
            for (int i = 0; i < _basket.Count; i++)
                Console.WriteLine($"    {i + 1}) {_basket[i].Name}, {_basket[i].Amount} штук. Стоимость - {_basket[i].Amount * _basket[i].Price}");
        }

        public void ChangeBasket(ref string productName)
        {
            Random rand = new Random();
            int productNumber = rand.Next(0, _basket.Count);
            productName = _basket[productNumber].Name;

            if (_basket[productNumber].Amount > 1)
            {
                Console.WriteLine($"Из корзины покупок был(а) удален(а) 1 {_basket[productNumber].Name}.");
                MoneyToPay -= _basket[productNumber].Price;
                _basket[productNumber].SubtractAmount();
            }
            else
            {
                Console.WriteLine($"Из корзины был(а) удален(а) {_basket[productNumber].Name}.");
                MoneyToPay -= _basket[productNumber].Price;
                _basket.RemoveAt(productNumber);
            }
        }

        public bool CheckSolvency()
        {
            Console.WriteLine($"общая стоимость покупок - {MoneyToPay} руб, на счету покупателя - {_money}руб.");

            if (MoneyToPay > _money)
            {
                return false;
            }
            else
            {
                Pay();
                return true;
            }
        }

        private void Pay()
        {
            _money -= MoneyToPay;
            Console.WriteLine($"Покупатель произвел оплату в размере - {MoneyToPay}руб. за:");
            ShowBasket();
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public int Amount { get; private set; }

        public Product(string name, int price, int amount = 1)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }

        public void AddAmount(int amount = 1)
        {
            Amount += amount;
        }

        public void SubtractAmount(int amount = 1)
        {
            Amount -= amount;
        }
    }
}
