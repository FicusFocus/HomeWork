using System;
using System.Collections.Generic;

//TODO: AddSales не работает, удаление из корзины удалает все товары данного типа (переделать чтоб уменьшало количество).

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
        private List<Product> _products = new List<Product>();
        
        public Shop()
        {
            _products.Add(new Product("Аспирин", 30, 100));
            _products.Add(new Product("Аскорбинка", 5, 100));
            _products.Add(new Product("Уголь активированный", 10, 100));
            _products.Add(new Product("Гематогенка", 20, 0));
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
                        _showProducts();
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

                        if(buyer.CheckSolvency())
                            _sellProduct(buyer.Basket);
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
        private void _showProducts()
        {
                for (int i = 0; i < _products.Count; i++)
                {
                    if (_products[i].Amount <= 0)
                        Console.WriteLine($"{i + 1}) {_products[i].Name} - нет в наличии");
                    else
                        Console.WriteLine($"{i + 1}) {_products[i].Name} - {_products[i].Price} руб.");
                }
        }
        private void _sellProduct(List<Product> basket)
        {
            Seller seller = new Seller();

            for (int i = 0; i < basket.Count; i++)
            {
                for (int j = 0; j < _products.Count; j++)
                {
                    if (basket[i].Name == _products[j].Name)
                    {
                        _products[j].SubtractAmount(basket[i].Amount);
                    }
                }
                    seller.AddSales(basket[i].Name, basket[i].Price, basket[i].Amount);
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
    class Seller
    {
        private int _money;
        private List<Product> _sales = new List<Product>();

        public void AddMoney(int moneyToPay)
        {
            _money += moneyToPay;
        }

        public void ShowSales()
        {
            for (int i = 0; i < _sales.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_sales[i].Name}. Продано {_sales[i].Amount} на сумму {_sales[i].Amount * _sales[i].Price}");
            }
        }

        public void AddSales(string productName, int productPrice, int productAmount = 1)
        {
            bool alreadyInBasket = false;
            int numberInBasket = 0;
            for (int i = 0; i < _sales.Count; i++)
            {
                if (_sales[i].Name == productName)
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
                _sales[numberInBasket].AddAmount(productAmount);
            else
                _sales.Add(new Product(productName, productPrice, productAmount));
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
            _buyerProducts = Basket;
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
}