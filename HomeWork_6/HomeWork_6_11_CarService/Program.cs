using System;
using System.Collections.Generic;

namespace HomeWork_6_11_CarService
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsAmount = 80;

            CarService carService = new CarService();
            Random rand = new Random();

            while (carsAmount > 0)
            {
                Client car = new Client();
                int moneyToPay = 0;

                Console.WriteLine("В автосервис на ремонт прибыла новая машина");

                string brokenPartName = null;
                int brokenPartPrice = 0;
                int PriceForRepairs = 0;
                int brokenPartNumber = rand.Next(0, carService.PartsAmount);

                if (carService.CheckSparePartAvailabiliti(brokenPartNumber, ref brokenPartName, ref brokenPartPrice, ref PriceForRepairs))
                {
                    car.AddToBasket(brokenPartName, brokenPartPrice);
                    carService.SubtractSparePartsAmount(brokenPartName);
                    moneyToPay = brokenPartPrice + PriceForRepairs;

                    if (car.CheckSolvency(moneyToPay))
                    {
                        carService.AddMoney(car.MoneyToPay);
                        Console.WriteLine($"\nКлиент обслужен. Еще в очереди находится {carsAmount} машин.\n");
                    }
                    else
                    {
                        Console.WriteLine("Клиент небыл обслужен.");
                    }
                }

                car = null;
                carsAmount--;
                carService.ShowMoney();
                carService.ShowStorage();

                Console.ReadLine();
                Console.Clear();
            }

            Console.WriteLine("Все покупатели были обслужены.");
        }
    }

    class CarService
    {
        private List<Storage> _spareParts = new List<Storage>();
        private int _money = 100;
        private int _fine = 20;

        public int PartsAmount { get; private set; }

        public CarService()
        {
            _spareParts.Add(new Storage("Двигатель", 700, 350, 30));
            _spareParts.Add(new Storage("Коробка передач", 600, 400, 30));
            _spareParts.Add(new Storage("Проводка", 300, 300, 40));
            _spareParts.Add(new Storage("Аккумулятор", 100, 10, 50));

            PartsAmount = _spareParts.Count;
        }

        public bool CheckSparePartAvailabiliti(int sparePartNumber, ref string sparePartName, ref int sparePartPrice, ref int sparePartPriceForRepairs)
        {
            bool inStorage = false;

            sparePartPrice = 0;
            sparePartPriceForRepairs = 0;
            sparePartName = null;
            
            for (int i = 0; i < _spareParts.Count; i++)
            {
                if (_spareParts[i].SparePart.Name == _spareParts[sparePartNumber].SparePart.Name && _spareParts[i].Amount > 0)
                {
                    Console.WriteLine($"Сломанная деталь - {_spareParts[i].SparePart.Name}. стоимость детали - {_spareParts[i].SparePart.Price}, стоимость замены - {_spareParts[i].PriceForRepairs}");
                    sparePartName = _spareParts[i].SparePart.Name;
                    sparePartPrice = _spareParts[i].SparePart.Price;
                    sparePartPriceForRepairs = _spareParts[i].PriceForRepairs;
                    return inStorage = true;
                }
                else if (_spareParts[i].SparePart.Name == _spareParts[sparePartNumber].SparePart.Name && _spareParts[i].Amount <= 0)
                {
                    Console.WriteLine($"Сломанная деталь - {_spareParts[i].SparePart.Name}. На складе подобных не осталось.\n");
                    Console.WriteLine("штраф - 20$");

                    SubtractMoney(_fine);
                }
            }

            if (inStorage == false)
                Console.WriteLine("Подобной детали на складе не существует.");

            return inStorage;
        }

        public void ShowStorage()
        {
            foreach (var sparePart in _spareParts)
            {
                Console.WriteLine($"{sparePart.SparePart.Name}. Стоимость - {sparePart.SparePart.Price}, на складе - {sparePart.Amount}");
            }
        }

        public void SubtractSparePartsAmount(string partName)
        {
            for (int i = 0; i < _spareParts.Count; i++)
            {
                if (_spareParts[i].SparePart.Name == partName)
                {
                    _spareParts[i].SubtractAmount();
                    break;
                }
            }
        }

        public void AddMoney(int moneyToPay)
        {
            _money += moneyToPay;
        }

        public void ShowMoney()
        {
            Console.WriteLine($"на балансе сервисного центра - {_money}$");
        }

        private void SubtractMoney(int moneyToFine)
        {
            if (moneyToFine > _money)
            {
                Console.WriteLine("Сервис центр абанкротился и закрылся.");
                _money = 0;
            }
            else
            {
                _money -= moneyToFine;
            }
        }
    }

    class Client
    {
        private Random _rand = new Random();
        private SparePart _basket;
        private int _money;
        public int MoneyToPay { get; private set; }

        public Client()
        {
            _money = _rand.Next(1000, 2000);
        }
        
        public void AddToBasket(string brokenPartName, int brokenPartPrice)
        {
            _basket = new SparePart(brokenPartName, brokenPartPrice);
        }

        public bool CheckSolvency(int moneyToPay)
        {
            Console.WriteLine($"Стоимость покупки - {moneyToPay}$, на счету клиента - {_money}$.");

            if (moneyToPay > _money)
            {
                Console.WriteLine("У клиента недостаточно денег для оплаты ремонта. Клиент ушел");
                return false;
            }
            else
            {
                MoneyToPay = moneyToPay;
                Pay();
                return true;
            }
        }

        private void Pay()
        {
            _money -= MoneyToPay;
            Console.WriteLine($"Покупатель произвел оплату в размере - {MoneyToPay}$. за: {_basket.Name}");
        }
    }

    class Storage
    {
        public SparePart SparePart { get; private set; }
        public int Amount { get; private set; }
        public int PriceForRepairs { get; private set; }

        public Storage(string name, int price, int priceForRepairs, int amount)
        {
            SparePart = new SparePart(name, price);
            PriceForRepairs = priceForRepairs;
            Amount = amount;
        }

        public void SubtractAmount(int amount = 1)
        {
            Amount -= amount;
        }
    }

    class SparePart
    {
        public string Name { get; private set; }
        public int Price { get; private set; }

        public SparePart(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
