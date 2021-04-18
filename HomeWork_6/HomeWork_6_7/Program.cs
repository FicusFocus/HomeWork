using System;
using System.Collections.Generic;

namespace HomeWork_6_7
{
    class Program
    {
        static void Main(string[] args)
        {
            int buyersAmount = 10;

            Shop seller = new Shop();
            Random rand = new Random();

            while (buyersAmount > 0)
            {
                Buyer buyer = new Buyer();

                int productsInBasket = rand.Next(1, 10);

                Console.WriteLine("Очередной посетитель желает приобрести следующие товары:");

                for (int i = 0; i < productsInBasket; i++)
                {
                    int productNumber = rand.Next(0, seller.ProductAmount);
                    string productName = null;
                    int productPrice = 0;

                    if (seller.CheckProductAvailability(productNumber, ref productName, ref productPrice))
                    {
                        buyer.AddToBasket(productName, productPrice);
                        seller.SubtractProductsAmount(productName);
                    }
                }

                buyer.ShowBasket();
                
                while(buyer.CheckSolvency() == false)
                {
                    string productName = null;

                    buyer.RemoveFromBasket(ref productName);
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
        private List<Storage> _productsInStorage = new List<Storage>();
        public int ProductAmount { get; private set; }

        public Shop()
        {
            _productsInStorage.Add(new Storage("Колбаска", 260, 100));
            _productsInStorage.Add(new Storage("Сыр", 370, 100));
            _productsInStorage.Add(new Storage("Хлеб", 20, 100));
            _productsInStorage.Add(new Storage("Шоколадка", 70, 100));
            _productsInStorage.Add(new Storage("Пильмеши", 280, 100));

            ProductAmount = _productsInStorage.Count;
        }

        public void AddMoney(int moneyToPay)
        {
            _money += moneyToPay;
        }

        public void ShowProducts()
        {
            foreach (var product in _productsInStorage)
                Console.WriteLine($"{product.Product.Name}, {product.Product.Price}. В наличии - {product.Amount} штук.");
        }

        public bool CheckProductAvailability(int productNumber, ref string productName, ref int productPrice)
        {
            if (productNumber < 0 || productNumber >= ProductAmount)
            {
                return false;
            }
            else
            {
                if (_productsInStorage[productNumber].Amount == 0)
                {
                    return false;
                }
                else
                {
                    productName = _productsInStorage[productNumber].Product.Name;
                    productPrice = _productsInStorage[productNumber].Product.Price;
                    return true;
                }
            }
        }

        public void SubtractProductsAmount(string productName)
        {
            for (int i = 0; i < _productsInStorage.Count; i++)
            {
                if (_productsInStorage[i].Product.Name == productName)
                {
                    _productsInStorage[i].SubtractAmount();
                    continue;
                }
            }
        }

        public void AddProductsAmount(string productName)
        {
            for (int i = 0; i < _productsInStorage.Count; i++)
            {
                if (_productsInStorage[i].Product.Name == productName)
                {
                    _productsInStorage[i].AddAmount();
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
        private int _money;
        private List<Storage> _basket = new List<Storage>();
        public int MoneyToPay { get; private set; } = 0;

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
                if (_basket[i].Product.Name == productName)
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
                MoneyToPay += _basket[numberInBasket].Product.Price;
            }
            else
            {
                _basket.Add(new Storage(productName, productPrice, 1));
                MoneyToPay += _basket[_basket.Count - 1].Product.Price;
            }
        }

        public void ShowBasket()
        {
            for (int i = 0; i < _basket.Count; i++)
                Console.WriteLine($"    {i + 1}) {_basket[i].Product.Name}, {_basket[i].Amount} штук. Стоимость - {_basket[i].Amount * _basket[i].Product.Price}");
        }

        public void RemoveFromBasket(ref string productName)
        {
            Random rand = new Random();
            int productNumber = rand.Next(0, _basket.Count);
            productName = _basket[productNumber].Product.Name;

            Console.WriteLine($"Из корзины покупок был(а) удален(а) 1 {_basket[productNumber].Product.Name}.");
            MoneyToPay -= _basket[productNumber].Product.Price;

            if (_basket[productNumber].Amount > 1)
                _basket[productNumber].SubtractAmount();
            else
                _basket.RemoveAt(productNumber);
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

    class Storage
    {
        public int Amount { get; private set; }
        public Product Product {get; private set;}

        public Storage(string name, int price, int amount)
        {
            Product = new Product(name, price);
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

    class Product
    {
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
