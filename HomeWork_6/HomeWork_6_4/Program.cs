using System;
using System.Collections.Generic;

namespace HomeWork_6_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Buyer buyer = new Buyer(rand.Next(50, 100));
            Seller seller = new Seller();

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

                        if(seller.CheckProductAvailability(productNumber, out string productName, out int productPrice))
                        {
                            buyer.AddToBasket(productName, productPrice);
                            seller.SubtractProductsAmount(productName);
                        }
                        break;

                    case "3":
                        buyer.ShowBasket();
                        break;

                    case "4":
                        buyer.ShowBalance();
                        int moneyToPay;

                        if (buyer.Pay(out moneyToPay))
                            seller.AddMoney(moneyToPay);
                        break;

                    case "5":
                        buyer.ShowBasket();
                        Console.Write("Введите номер продукта который желаете исключить из корзины:");
                        productNumber = Convert.ToInt32(Console.ReadLine());

                        buyer.RemoveFormBasket(productNumber - 1, out bool isRemove, out productName);

                        if (isRemove)
                            seller.AddProductsAmount(productName);
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
        private List<Product> _products = new List<Product>();
        
        public Seller()
        {
            _products.Add(new Product("Аспирин", 30, 100));
            _products.Add(new Product("Аскорбинка", 5, 100));
            _products.Add(new Product("Уголь активированный", 10, 100));
            _products.Add(new Product("Гематогенка", 20, 0));
        }

        public bool CheckProductAvailability(int productNumber, out string productName, out int productPrice)
        {
            productName = null;
            productPrice = 0;

            if (productNumber < 0 || productNumber > _products.Count)
            {
                Console.WriteLine("Такого товара не существует.");
                return false;
            }
            else
            {
                if (_products[productNumber].Amount == 0)
                {
                    Console.WriteLine("Данного товара нет в наличии");
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

        public void AddProductsAmount(string productName)
        {
            for (int i = 0; i < _products.Count; i++)
            {
                if(_products[i].Name == productName)
                {
                    _products[i].AddAmount();
                    continue;
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

        public void ShowProducts()
        {
            for (int i = 0; i < _products.Count; i++)
            {
                if (_products[i].Amount <= 0)
                    Console.WriteLine($"{i + 1}) {_products[i].Name} - нет в наличии");
                else
                    Console.WriteLine($"{i + 1}) {_products[i].Name} - {_products[i].Price} руб.");
            }
        }

        public void AddMoney(int moneyToPay)
        {
            _money += moneyToPay;
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

        public bool Pay(out int moneyToPay)
        {
            
            if (CheckSolvency(out moneyToPay))
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

        private bool checkProductAvailabilityInBasket(int productNumber)
        {
            if (productNumber < 0 || productNumber > _basket.Count)
            {
                Console.WriteLine("Такого товара в корзине нет.");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CheckSolvency(out int moneyToPay)
        {
            moneyToPay = 0;

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

        public void RemoveFormBasket(int productNumber, out bool isRemove, out string productName)
        {
            if (checkProductAvailabilityInBasket(productNumber))
            {
                if (_basket[productNumber].Amount > 1)
                    _basket[productNumber].SubtractAmount();
                else
                    _basket.Remove(_basket[productNumber]);
                isRemove = true;
                productName = _basket[productNumber].Name;
            }
            else
            {
                isRemove = false;
                productName = null;
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