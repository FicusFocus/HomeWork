using System;
using System.Collections.Generic;

//У вас есть автосервис, в который приезжают люди, чтобы починить свои автомобили.
//У вашего автосервиса есть баланс денег и склад деталей.
//Когда приезжает автомобиль, у него сразу ясна его поломка, 
//и эта поломка отображается у вас в консоли вместе с ценой за починку(цена за починку складывается из цены детали + цена за работу).
//Поломка всегда чинится заменой детали, но количество деталей ограничено тем, что находится на вашем складе деталей.
//Если у вас нет нужной детали на складе, то вы можете отказать клиенту, и в этом случае вам придется выплатить штраф.
//Если вы замените не ту деталь, то вам придется возместить ущерб клиенту.
//За каждую удачную починку вы получаете выплату за ремонт, которая указана в чек-листе починки. 

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
                Console.WriteLine("В автосервис на ремонт прибыла новая машина");

                string brokenPartName = null;
                int brokenPartPrice = 0;
                int brokenPartNumber = rand.Next(0, carService.PartsAmount);

                if (carService.CheckSparePartAvailabiliti(brokenPartNumber, ref brokenPartName, ref brokenPartPrice))
                {

                }

                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    class CarService
    {
        private List<Storage> _spareParts = new List<Storage>();
        private int _mone;

        public int PartsAmount { get; private set; }

        public CarService()
        {
            _spareParts.Add(new Storage("Двигатель", 700, 350, 30));
            _spareParts.Add(new Storage("Коробка передач", 600, 400, 30));
            _spareParts.Add(new Storage("Проводка",300 ,300 ,50));
            _spareParts.Add(new Storage("Аккумулятор", 100, 10, 50));

            PartsAmount = _spareParts.Count;
        }

        public bool CheckSparePartAvailabiliti(int sparePartNumber, ref string sparePartName, ref int sparePartPrice)
        {
            bool inStorage = false;

            sparePartPrice = 0;
            sparePartName = null;
            
            for (int i = 0; i < _spareParts.Count; i++)
            {
                if (_spareParts[i].SparePart.Name == _spareParts[sparePartNumber].SparePart.Name && _spareParts[i].Amount > 0)
                {
                    sparePartName = _spareParts[i].SparePart.Name;
                    sparePartPrice = _spareParts[i].SparePart.Price;
                    return inStorage = true;
                }
            }

            if (inStorage == false)
                Console.WriteLine("Детали нет на складе");

            return inStorage;
        }
    }

    class Car
    {
        public SparePart BrokenPart { get; private set; }
        

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
