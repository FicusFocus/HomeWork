using System;
using System.Collections.Generic;

//TODO: передаю список продуктов в покупателя. Придумать как исправить.
//TODO: Добавить класс продовца.

namespace HomeWork_6_4_test_
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Buyer buyer = new Buyer(rand.Next(30, 100));
            Shop shop = new Shop();
            shop.Work(buyer);
        }
    }
    class Shop
    {
        private int _moneyToPay = 0;

        public List<Product> Products { get; private set; } = new List<Product>();
        
        public Shop()
        {
            Products.Add(new Product("Аспирин", 30, 100));
            Products.Add(new Product("Аскорбинка", 5, 100));
            Products.Add(new Product("Уголь активированный", 10, 100));
            Products.Add(new Product("Гематогенка", 20, 0));
        }
        public void Work(Buyer buyer)
        {
            bool isWork = true;
            while (isWork)
            {
                Console.WriteLine("Добро пожаловать в онлайн аптеку!\n\n");
                Console.WriteLine("1) просмотр списка лекарств\n" +
                                  "2) добавить товар в корзину (по номеру)\n" +
                                  "3) показать корзину покупок\n" +
                                  "4) приобрести товары в корзине\n" +
                                  "5) показать список приобретенных товаров\n" +
                                  "6) убрать товар из корзины\n" +
                                  "7) выйти\n" +
                                  "Выбирете действие: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        ShowProducts();
                        break;
                    case "2":
                        Console.Write("Введите номер продукта который желаете добавить в корзину.");
                        int productNumber = Convert.ToInt32(Console.ReadLine());
                        if (productNumber < 0 || productNumber > Products.Count)
                        {
                            Console.WriteLine("Такого товара не существует.");
                        }
                        else
                        {
                            if (Products[productNumber].Amount == 0)
                            {
                                Console.WriteLine("Данного товара нет в наличии");
                            }
                            else
                            {
                                buyer.AddToBasket(Products[productNumber].Name, Products[productNumber].Price);
                            }
                        }
                        break;
                    case "3":
                        buyer.ShowBasket(ref _moneyToPay);
                        break;
                    case "4":
                        buyer.ShowBalance();
                        buyer.BuyAProduct(buyer, _moneyToPay);
                        break;
                    case "5":
                        buyer.ShowPurchasedItems();
                        break;
                    case "6":
                        Console.Write("Введите номер продукта который желаете исключить из корзины.");
                        productNumber = Convert.ToInt32(Console.ReadLine());
                        buyer.RemoveFormBasket(productNumber - 1);
                        break;
                    case "7":
                        isWork = false;
                        Console.WriteLine("Спасибо за покупки!");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
        private void ShowProducts()
        {
                for (int i = 0; i < Products.Count; i++)
                {
                    if (Products[i].Amount <= 0)
                        Console.WriteLine($"{i + 1}) {Products[i].Name} - нет в наличии");
                    else
                        Console.WriteLine($"{i + 1}) {Products[i].Name} - {Products[i].Price} руб.");
                }
        }
        
    }
    class Product
    {
        public int Amount { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Product(string name, int price, int amount)
        {
            Name = name;
            Price = price;
            Amount = amount;
        }

        public void AddAmount()
        {
            Amount++;
        }
    }
    class Buyer
    {
        private int _money;

        public List<Product> Basket { get; private set; } = new List<Product>();
        public  List<Product> BuyerProducts { get; private set; } = new List<Product>();

        public Buyer(int money)
        {
            _money = money;
        }
        public void Pay(int moneyToPay)
        {
            if (moneyToPay > _money) 
            {
                Console.WriteLine($"Стимсоть всех товаров в корзине составляет - {moneyToPay} руб.");
                Console.WriteLine("К сожалению у Вас недостаточно денег для совершения покупки");
            }
            else
            {
                _money -= moneyToPay;
                Console.WriteLine("Покупка прошла успешно.");
            }
        }
        public void ShowBalance()
        {
            Console.WriteLine($"У Вас на баласне - {_money} руб.");
        }
        public void ShowBasket(ref int moneyToPay)
        {
            for (int i = 0; i < Basket.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {Basket[i].Name},{Basket[i].Amount} штук. Стоимость - {Basket[i].Amount * Basket[i].Price}");
                moneyToPay = Basket[i].Amount * Basket[i].Price;
            }
            Console.WriteLine($"общая стоимость покупок - {moneyToPay} руб.");
            moneyToPay = 0;
        }
        public void AddToBasket(string productName, int productPrice)
        {
            bool alreadyInBasket = false;
            int numberInBasket = 0;
            for (int i = 0; i < Basket.Count; i++)
            {
                if (Basket[i].Name == productName)
                {
                    numberInBasket = i;
                    alreadyInBasket = true;
                }
                else
                {
                    alreadyInBasket = false;
                }
            }
            if (alreadyInBasket)
                Basket[numberInBasket].AddAmount();
            else
                Basket.Add(new Product(productName, productPrice, 1));
        }
        public void RemoveFormBasket(int productNumber)
        {
            if (productNumber < 0 || productNumber > Basket.Count)
                Console.WriteLine("Данного продукта в корзине не нет.");
            else
                Basket.Remove(Basket[productNumber]);
        }
        public void BuyAProduct(Buyer buyer, int moneyToPay)
        {
            for (int i = 0; i < Basket.Count; i++)
                moneyToPay += Basket[i].Price * Basket[i].Amount;

            buyer.Pay(moneyToPay);
        }
        public void ShowPurchasedItems()
        {
            for (int i = 0; i < BuyerProducts.Count; i++)
                Console.WriteLine($"{i + 1}) {BuyerProducts[i].Name},{BuyerProducts[i].Amount} штук.");
        }
    }
}