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
            Shop shop = new Shop();
            shop.Work(buyer);
        }
    }
    class Shop
    {
        private List<Product> _products = new List<Product>();
        
        public Shop()
        {
            _products.Add(new Product("Аспирин", 30, 100));
            _products.Add(new Product("Аскорбинка", 5, 100));
            _products.Add(new Product("Уголь активированный", 10, 100));
            _products.Add(new Product("Гематогенка", 20, 0));
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
        public void Work(Buyer buyer)
        {
            Seller seller = new Seller();

            bool isWork = true;
            while (true)
            {
                Console.WriteLine("Добро пожаловать в онлайн аптеку!\n\n");
                Console.WriteLine("1) просмотр списка лекарств\n" +
                                  "2) добавить товар в корзину (по номеру)\n" +
                                  "3) показать корзину покупок\n" +
                                  "4) приобрести товары в корзине\n" +
                                  "5) показать список приобретенных товаров\n" +
                                  "6) убрать товар из корзины\n" +
                                  "7) Показать список проданных товаров\n" + 
                                  "8) выйти\n" +
                                  "Выбирете действие: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        ShowProducts();
                        break;

                    case "2":
                        Console.Write("Введите номер продукта который желаете добавить в корзину:");
                        int productNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (productNumber < 0 || productNumber > _products.Count)
                        {
                            Console.WriteLine("Такого товара не существует.");
                        }
                        else
                        {
                            if (_products[productNumber].Amount == 0)
                                Console.WriteLine("Данного товара нет в наличии");
                            else
                                buyer.AddToBasket(_products[productNumber].Name, _products[productNumber].Price);
                        }
                        break;

                    case "3":
                        buyer.ShowBasket();
                        break;

                    case "4":
                        buyer.ShowBalance();

                        if(buyer.Pay())
                            seller.AddMoney();
                        break;

                    case "5":
                        buyer.ShowPurchasedItems();
                        break;

                    case "6":
                        Console.Write("Введите номер продукта который желаете исключить из корзины:");
                        productNumber = Convert.ToInt32(Console.ReadLine());
                        if (buyer.RemoveFormBasket(productNumber - 1))
                            seller.RemoveFormSales(productNumber - 1);
                        break;

                    case "7":
                        seller.ShowSales();
                        break;

                    case "8":
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
        private List<Product> _sales = new List<Product>();

        public void ShowSales()
        {
            for (int i = 0; i < _sales.Count; i++)
                Console.WriteLine($"{i + 1}) {_sales[i].Name}. Продано {_sales[i].Amount} на сумму {_sales[i].Amount * _sales[i].Price}");
        }
        public void AddToSales(string productName, int productPrice)
        {
            bool alreadyInSales = false;
            int numberInSales = 0;
            for (int i = 0; i < _sales.Count; i++)
            {
                if (_sales[i].Name == productName)
                {
                    numberInSales = i;
                    i = _sales.Count;
                    alreadyInSales = true;
                }
                else
                {
                    alreadyInSales = false;
                }
            }
            if (alreadyInSales)
                _sales[numberInSales].AddAmount();
            else
                _sales.Add(new Product(productName, productPrice, 1));
        }
        public void RemoveFormSales(int productNumber)
        {
            bool alreadyInBasket = false;
            for (int i = 0; i < _sales.Count; i++)
            {
                if (_sales[i].Name == _sales[productNumber].Name)
                {
                    alreadyInBasket = true;
                    i = _sales.Count;
                }
                else
                {
                    alreadyInBasket = false;
                }
            }
            if (alreadyInBasket)
                _sales[productNumber].SubtractAmount();
            else
                _sales.Remove(_sales[productNumber]);
        }
        public void AddMoney()
        {
            for (int i = 0; i < _sales.Count; i++)
            {
                _money += _sales[i].Price;
            }
        }
    }
    class Buyer
    {
        private int _money;
        private List<Product> _purchasedProducts = new List<Product>();
        private List<Product> _basket = new List<Product>();

        public Buyer(int money)
        {
            _money = money;
        }

        public bool Pay()
        {
            int moneyToPay = 0;

            if (CheckSolvency(ref moneyToPay))
            {
                _money -= moneyToPay;
                Console.WriteLine("Покупка прошла успешно.");
                if (_purchasedProducts.Count == 0)
                {
                    _purchasedProducts = _basket;
                }
                else
                {
                    bool alreanyInSales = false;

                    for (int i = 0; i < _purchasedProducts.Count; i++)
                    {
                        for (int j = 0; j < _basket.Count; j++)
                        {
                            if (_basket[j].Name == _purchasedProducts[i].Name)
                            {
                                _purchasedProducts[i].AddAmount(_basket[j].Amount);
                                alreanyInSales = false;
                            }
                            if (alreanyInSales)
                            {
                                _purchasedProducts.Add(new Product(_basket[j].Name, _basket[j].Price, _basket[j].Amount));
                            }
                        }
                    }
                }
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
        public bool RemoveFormBasket(int productNumber)
        {
            if (productNumber < 0 || productNumber > _basket.Count)
            {
                Console.WriteLine("Данного продукта в корзине не нет.");
                return false;
            }
            else
            {
                bool alreadyInBasket = false;
                for (int i = 0; i < _basket.Count; i++)
                {
                    if (_basket[i].Name == _basket[productNumber].Name)
                    {
                        alreadyInBasket = true;
                        i = _basket.Count;
                    }
                    else
                    {
                        alreadyInBasket = false;
                    }
                }
                if (alreadyInBasket)
                    _basket[productNumber].SubtractAmount();
                else
                    _basket.Remove(_basket[productNumber]);
                return true;
            }
        }
        public void ShowPurchasedItems()
        {
            for (int i = 0; i < _purchasedProducts.Count; i++)
                Console.WriteLine($"{i + 1}) {_purchasedProducts[i].Name},{_purchasedProducts[i].Amount} штук.");
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