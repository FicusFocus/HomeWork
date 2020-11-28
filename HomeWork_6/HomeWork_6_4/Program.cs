using System;
using System.Collections.Generic;

namespace HomeWork_6_4_test_
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
            while (isWork)
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
                            {
                                Console.WriteLine("Данного товара нет в наличии");
                            }
                            else
                            {
                                buyer.AddToBasket(_products[productNumber].Name, _products[productNumber].Price);
                            }
                        }
                        break;
                    case "3":
                        buyer.ShowBasket();
                        break;
                    case "4":
                        buyer.ShowBalance();

                        if (buyer.CheckSolvency())
                            seller.AddSales(buyer.Basket);
                        break;
                    case "5":
                        buyer.ShowPurchasedItems();
                        break;
                    case "6":
                        Console.Write("Введите номер продукта который желаете исключить из корзины:");
                        productNumber = Convert.ToInt32(Console.ReadLine());
                        buyer.RemoveFormBasket(productNumber - 1);
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
        public void AddSales(List<Product> basket)
        {
            if (_sales.Count == 0)
            {
                _sales = basket;
            }
            else
            {
                bool alreanyInSales = false;

                for (int i = 0; i < _sales.Count; i++)
                {
                    for (int j = 0; j < basket.Count; j++)
                    {
                        if (basket[j].Name == _sales[i].Name)
                        {
                            _sales[i].AddAmount(basket[j].Amount);
                            alreanyInSales = false;
                        }
                        if (alreanyInSales)
                        {
                            _sales.Add(new Product(basket[j].Name, basket[j].Price, basket[j].Amount));
                        }
                    }
                }
            }
            for (int i = 0; i < _sales.Count; i++)
                _money += _sales[i].Price * _sales[i].Amount;
        }
    }
    class Buyer
    {
        private int _money;
        private List<Product> _buyerProducts = new List<Product>();

        public List<Product> Basket { get; private set; } = new List<Product>();

        private void Pay(int moneyToPay)
        {
            _money -= moneyToPay;
            Console.WriteLine("Покупка прошла успешно.");
            if (_buyerProducts.Count == 0)
            {
                _buyerProducts = Basket;
            }
            else
            {
                bool alreanyInSales = false;

                for (int i = 0; i < _buyerProducts.Count; i++)
                {
                    for (int j = 0; j < Basket.Count; j++)
                    {
                        if (Basket[j].Name == _buyerProducts[i].Name)
                        {
                            _buyerProducts[i].AddAmount(Basket[j].Amount);
                            alreanyInSales = false;
                        }
                        if (alreanyInSales)
                        {
                            _buyerProducts.Add(new Product(Basket[j].Name, Basket[j].Price, Basket[j].Amount));
                        }
                    }
                }
            }
        }
        public Buyer(int money)
        {
            _money = money;
        }
        public void ShowBalance()
        {
            Console.WriteLine($"У Вас на баласне - {_money} руб.");
        }
        public void ShowBasket()
        {
            int moneyToPay = 0;
            for (int i = 0; i < Basket.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {Basket[i].Name},{Basket[i].Amount} штук. Стоимость - {Basket[i].Amount * Basket[i].Price}");
                moneyToPay += Basket[i].Amount * Basket[i].Price;
            }
            Console.WriteLine($"общая стоимость покупок - {moneyToPay} руб.");
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
                    i = Basket.Count;
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
            {
                Console.WriteLine("Данного продукта в корзине не нет.");
            }
            else
            {
                bool alreadyInBasket = false;
                for (int i = 0; i < Basket.Count; i++)
                {
                    if (Basket[i].Name == Basket[productNumber].Name)
                    {
                        alreadyInBasket = true;
                        i = Basket.Count;
                    }
                    else
                    {
                        alreadyInBasket = false;
                    }
                }
                if (alreadyInBasket)
                    Basket[productNumber].SubtractAmount();
                else
                    Basket.Remove(Basket[productNumber]);
            }
        }
        public bool CheckSolvency()
        {
            int moneyToPay = 0;

            for (int i = 0; i < Basket.Count; i++)
                moneyToPay += Basket[i].Price * Basket[i].Amount;

            if (moneyToPay > _money)
            {
                Console.WriteLine($"Стимсоть всех товаров в корзине составляет - {moneyToPay} руб.");
                Console.WriteLine("К сожалению у Вас недостаточно денег для совершения покупки");
                return false;
            }
            else
            {
                Pay(moneyToPay);
                return true;
            }
        }
        public void ShowPurchasedItems()
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