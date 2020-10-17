using System;
using System.Collections.Generic;

namespace HomeWork_6_4_test_
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();        
        }
    }
    class Shop
    {
        private int _moneyToPay = 0;
        private List<Product> _productsList = new List<Product>();
        private List<Product> _basket = new List<Product>();
        private List<Product> _buyerProducts = new List<Product>();

        public Shop()
        {
            _productsList.Add(new Product("Аспирин", 30, 100));
            _productsList.Add(new Product("Аскорбинка", 5, 100));
            _productsList.Add(new Product("Уголь активированный", 10, 100));
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
                                  "6) выйти\n" +
                                  "Выбирете действие: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        ShowProductList();
                        break;
                    case "2":
                        Console.Write("Введите номер продукта который желаете добавить в корзину.");
                        int productNumber = Convert.ToInt32(Console.ReadLine());
                        AddToBasket(productNumber);
                        break;
                    case "3":
                        ShowBasket();
                        break;
                    case "4":
                        break;
                    case "5":
                        ShowPurchasedItems();
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
        private void ShowProductList()
        {
                for (int i = 0; i < _productsList.Count; i++)
                {
                    if (_productsList[i].Amount > 0)
                        Console.WriteLine($"{i}) {_productsList[i].Name} - нет в наличии");
                    else
                        Console.WriteLine($"{i}) {_productsList[i].Name} - {_productsList[i].Price} руб.");
                }
        }
        private void ShowBasket()
        {
            for (int i = 0; i < _basket.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_basket[i].Name},{_basket[i].Amount} штук. Стоимость - {_basket[i].Amount * _basket[i].Price}");
            }
        }
        private void ShowPurchasedItems()
        {
            for (int i = 0; i < _buyerProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {_buyerProducts[i].Name},{_buyerProducts[i].Amount} штук.");
            }
        }
        private void AddToBasket( int productNumber)
        {
            if (productNumber < 0 || productNumber > _productsList.Count)
            {
                Console.WriteLine("Такого товара не существует.");
            }
            else
            {
                bool alreadyInBasket = false;
                int numberInBasket = 0;
                for (int i = 0; i < _basket.Count; i++)
                {
                    if(_basket[i].Name == _productsList[productNumber].Name)
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
                    _basket.Add(new Product(_productsList[productNumber].Name, _productsList[productNumber].Price, 1));
            }
        }
        public void BuyAProduct()
        {
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
        public bool CheckSolvency(int moneyToPay)
        {
            if (moneyToPay > _money)
                return false;
            else
                return true;
        }
    }
}
