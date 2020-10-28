using System;
using System.Collections.Generic;

namespace HomeWork_6_4_test_
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            shop.Work();
        }
    }
    class Shop
    {
        private int _moneyToPay = 0;
        private List<Product> _products = new List<Product>();
        private List<Product> _basket = new List<Product>();
        private List<Product> _buyerProducts = new List<Product>();

        public Shop()
        {
            _products.Add(new Product("Аспирин", 30, 100));
            _products.Add(new Product("Аскорбинка", 5, 100));
            _products.Add(new Product("Уголь активированный", 10, 100));
            _products.Add(new Product("Гематогенка", 20, 0));
        }
        public void Work()
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
                        AddToBasket(productNumber - 1);
                        break;
                    case "3":
                        ShowBasket();
                        break;
                    case "4":
                        Random rand = new Random();
                        Buyer buyer = new Buyer(rand.Next(10, 100));
                        buyer.ShowBalance();
                        BuyAProduct(buyer);
                        break;
                    case "5":
                        ShowPurchasedItems();
                        break;
                    case "6":
                        Console.Write("Введите номер продукта который желаете исключить из корзины.");
                        productNumber = Convert.ToInt32(Console.ReadLine());
                        RemoveFormBasket(productNumber - 1);
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
                for (int i = 0; i < _products.Count; i++)
                {
                    if (_products[i].Amount <= 0)
                        Console.WriteLine($"{i + 1}) {_products[i].Name} - нет в наличии");
                    else
                        Console.WriteLine($"{i + 1}) {_products[i].Name} - {_products[i].Price} руб.");
                }
        }
        private void AddToBasket( int productNumber)
        {
            if (productNumber < 0 || productNumber > _products.Count)
            {
                Console.WriteLine("Такого товара не существует.");
            }
            else
            {
                if(_products[productNumber].Amount == 0)
                {
                    Console.WriteLine("Данного товара нет в наличии");
                }
                else
                {
                    bool alreadyInBasket = false;
                    int numberInBasket = 0;
                    for (int i = 0; i < _basket.Count; i++)
                    {
                        if (_basket[i].Name == _products[productNumber].Name)
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
                        _basket[numberInBasket].AddAmount();
                    else
                        _basket.Add(new Product(_products[productNumber].Name, _products[productNumber].Price, 1));
                }
            }
        }
        private void RemoveFormBasket(int productNumber)
        {
            if(productNumber < 0 || productNumber > _basket.Count)
                Console.WriteLine("Данного продукта в корзине не нет.");
            else
                _basket.Remove(_basket[productNumber]);
        }
        private void ShowBasket()
        {
            for (int i = 0; i < _basket.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_basket[i].Name},{_basket[i].Amount} штук. Стоимость - {_basket[i].Amount * _basket[i].Price}");
                _moneyToPay = _basket[i].Amount * _basket[i].Price;
            }
            Console.WriteLine($"общая стоимость покупок - {_moneyToPay} руб.");
            _moneyToPay = 0;
        }
        private void BuyAProduct(Buyer buyer)
        {
            for (int i = 0; i < _basket.Count; i++)
                _moneyToPay += _basket[i].Price * _basket[i].Amount;

            buyer.Pay(_moneyToPay);
        }
        private void ShowPurchasedItems()
        {
            for (int i = 0; i < _buyerProducts.Count; i++)
                Console.WriteLine($"{i + 1}) {_buyerProducts[i].Name},{_buyerProducts[i].Amount} штук.");
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
    }
}
