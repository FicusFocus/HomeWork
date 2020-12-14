using System;
using System.Collections.Generic;

//Взаимодействие продавца и игрока лучше сделать в main, одна из сторон сделок не должна контролировать и напрямую вызывать методы другой

namespace HomeWork_6_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Buyer buyer = new Buyer(rand.Next(50, 100));
            Seller seller = new Seller();
            seller.Work(buyer);

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Добро пожаловать в онлайн аптеку!\n\n");
                Console.WriteLine("1) просмотр списка лекарств\n" +
                                  "2) добавить товар в корзину (по номеру)\n" +
                                  "3) показать корзину покупок\n" +
                                  "4) приобрести товары в корзине\n" +
                                  "5) убрать товар из корзины\n" +
                                  "7) выйти\n" +
                                  "Выбирете действие: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        seller.ShowProducts();
                        break;

                    case "2":
                        Console.Write("Введите номер продукта который желаете добавить в корзину:");
                        int productNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (productNumber < 0 || productNumber > seller.Products.Count)
                        {
                            Console.WriteLine("Такого товара не существует.");
                        }
                        else
                        {
                            if (seller.Products[productNumber].Amount == 0)
                            {
                                Console.WriteLine("Данного товара нет в наличии");
                            }
                            else
                            {
                                buyer.AddToBasket(seller.Products[productNumber].Name, seller.Products[productNumber].Price);
                                seller.Products[productNumber].SubtractAmount();
                            }
                        }
                        break;

                    case "3":
                        buyer.ShowBasket();
                        break;

                    case "4":
                        buyer.ShowBalance();
                        int moneyToPay = 0;

                        if (buyer.Pay(ref moneyToPay))
                            seller.AddMoney(moneyToPay);
                        break;

                    case "5":
                        Console.Write("Введите номер продукта который желаете исключить из корзины:");
                        productNumber = Convert.ToInt32(Console.ReadLine());
                        string productName;
                        buyer.RemoveFormBasket(productNumber - 1, out productName);
                        for (int i = 0; i < seller.Products.Count; i++)
                        {
                            if (seller.Products[i].Name == productName)
                            {
                                seller.Products[i].AddAmount();
                                continue;
                            }
                        }
                        break;

                    case "6":
                        isWork = false;
                        Console.WriteLine("Спасибо за покупки!");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Seller
    {
        private int _money;
        public List<Product> Products { get; private set; } = new List<Product>();
        
        public Seller()
        {
            Products.Add(new Product("Аспирин", 30, 100));
            Products.Add(new Product("Аскорбинка", 5, 100));
            Products.Add(new Product("Уголь активированный", 10, 100));
            Products.Add(new Product("Гематогенка", 20, 0));
        }

        public void ShowProducts()
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Amount <= 0)
                    Console.WriteLine($"{i + 1}) {Products[i].Name} - нет в наличии");
                else
                    Console.WriteLine($"{i + 1}) {Products[i].Name} - {Products[i].Price} руб.");
            }
        }

        public void AddMoney(int moneyToPay)
        {
            _money += moneyToPay;
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
                                  "5) убрать товар из корзины\n" +
                                  "7) выйти\n" +
                                  "Выбирете действие: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        ShowProducts();
                        break;

                    case "2":
                        Console.Write("Введите номер продукта который желаете добавить в корзину:");
                        int productNumber = Convert.ToInt32(Console.ReadLine()) - 1;
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
                                Products[productNumber].SubtractAmount();
                            }
                        }
                        break;

                    case "3":
                        buyer.ShowBasket();
                        break;

                    case "4":
                        buyer.ShowBalance();
                        int moneyToPay = 0;

                        if (buyer.Pay(ref moneyToPay))
                            _money += moneyToPay;
                        break;

                    case "5":
                        Console.Write("Введите номер продукта который желаете исключить из корзины:");
                        productNumber = Convert.ToInt32(Console.ReadLine());
                        string productName;
                        buyer.RemoveFormBasket(productNumber - 1, out productName);
                        for (int i = 0; i < Products.Count; i++)
                        {
                            if (Products[i].Name == productName)
                            {
                                Products[i].AddAmount();
                                continue;
                            }
                        }
                        break;

                    case "6":
                        isWork = false;
                        Console.WriteLine("Спасибо за покупки!");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Buyer
    {
        private int _money;
        private List<Product> _basket = new List<Product>();

        public Buyer(int money)
        {
            _money = money;
        }

        public bool Pay(ref int moneyToPay)
        {
            if (CheckSolvency(ref moneyToPay))
            {
                _money -= moneyToPay;
                Console.WriteLine("Покупка прошла успешно.");
                _basket = null;

                return true;
            }
            else
            {
                Console.WriteLine($"Стимсоть всех товаров в корзине составляет - {moneyToPay} руб.");
                Console.WriteLine("К сожалению у Вас недостаточно денег для совершения покупки");

                return false;
            }
        }

        private bool CheckSolvency(ref int moneyToPay)
        {
            for (int i = 0; i < _basket.Count; i++)
                moneyToPay += _basket[i].Price * _basket[i].Amount;

            if (moneyToPay > _money)
                return false;
            else
                return true;
        }

        public void ShowBalance()
        {
            Console.WriteLine($"У Вас на баласне - {_money} руб.");
        }

        public void ShowBasket()
        {
            int moneyToPay = 0;
            for (int i = 0; i < _basket.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_basket[i].Name},{_basket[i].Amount} штук. Стоимость - {_basket[i].Amount * _basket[i].Price}");
                moneyToPay += _basket[i].Amount * _basket[i].Price;
            }
            Console.WriteLine($"общая стоимость покупок - {moneyToPay} руб.");
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
                _basket[numberInBasket].AddAmount();
            else
                _basket.Add(new Product(productName, productPrice, 1));
        }

        public bool RemoveFormBasket(int productNumber, out string productName)
        {
            if (productNumber < 0 || productNumber > _basket.Count)
            {
                Console.WriteLine("Данного продукта в корзине не нет.");
                productName = null;
                return false;
            }
            else
            {
                if (_basket[productNumber].Amount > 1)
                    _basket[productNumber].SubtractAmount();
                else
                    _basket.Remove(_basket[productNumber]);
                productName = _basket[productNumber].Name;
                return true;
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

        public void SubtractAmount(int amount = 1)
        {
            Amount -= amount;
        }

        public void AddAmount(int amount = 1)
        {
            Amount += amount;
        }
    } 
}