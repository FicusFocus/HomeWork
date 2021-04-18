﻿using System;
using System.Collections.Generic;

//1. if (productNumber < 0 || productNumber >= _productsInStorage.Count) - у вас есть свойство ProductsAmount, 
//его можно использовать вместо _productsInStorage.Count 
//готово
//2. При запуске кода все продукты с супермаркете отсутствуют в наличии 
//готово
//3. for (int i = 0; i < _productsInStorage.Count; i++) - в большинстве таких циклов можно обойтись использованием foreach 
//готово
//4. class Storage : Product - склад не может являться продуктом, склад должен содержать их. 
//
//5. public void ChangeBasket - по названию непонятно как именно изменяется содержимое корзины 
//готово
//6. if (_basket[productNumber].Amount > 1) ... else { ... } - код в этих условиях дублируется и есть общая часть, 
//которую можно вынести из них 
//готово
//7. public int _amount { get; private set; } - не забывайте про правила именования.
//Также это свойство не используется вне класса, поэтому оно не должно быть public 
//готово
//8. public bool CheckProductAvailability(int productNumber, out string productName, out int productPrice) - модификаторы out не нужны, 
//так как после выполнения метода их значения остаются как были
//

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
                Console.WriteLine($"{product.Name}, {product.Price}. В наличии - {product.Amount} штук.");
        }

        public bool CheckProductAvailability(int productNumber, out string productName, out int productPrice) // out нужен (вроде как).
        {
            productName = null;
            productPrice = 0;

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
                    productName = _productsInStorage[productNumber].Name;
                    productPrice = _productsInStorage[productNumber].Price;
                    return true;
                }
            }
        }

        public void SubtractProductsAmount(string productName)
        {
            for (int i = 0; i < _productsInStorage.Count; i++)
            {
                if (_productsInStorage[i].Name == productName)
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
                if (_productsInStorage[i].Name == productName)
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
                _basket.Add(new Storage(productName, productPrice, 1));
                MoneyToPay += _basket[_basket.Count - 1].Price;
            }
        }

        public void ShowBasket()
        {
            for (int i = 0; i < _basket.Count; i++)
                Console.WriteLine($"    {i + 1}) {_basket[i].Name}, {_basket[i].Amount} штук. Стоимость - {_basket[i].Amount * _basket[i].Price}");
        }

        public void RemoveFromBasket(ref string productName)
        {
            Random rand = new Random();
            int productNumber = rand.Next(0, _basket.Count);
            productName = _basket[productNumber].Name;

            if (_basket[productNumber].Amount > 1)
            {
                ShowDeleteMassage(productNumber);
                _basket[productNumber].SubtractAmount();
            }
            else
            {
                ShowDeleteMassage(productNumber);
                _basket.RemoveAt(productNumber);
            }
        }

        private void ShowDeleteMassage(int productNumber) // кривое название
        {
            Console.WriteLine($"Из корзины покупок был(а) удален(а) 1 {_basket[productNumber].Name}.");
            MoneyToPay -= _basket[productNumber].Price;
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

    class Storage : Product
    {
        public int Amount { get; private set; }

        public Storage(string name, int price, int amount) : base(name, price)
        {
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