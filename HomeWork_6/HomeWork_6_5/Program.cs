using System;
using System.Collections.Generic;

namespace HomeWork6_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Subway subway = new Subway();
            subway.Work();
        }
    }
    class Subway
    {
        private int _soldTeickets;
        private Route _route;
        private Train _train;

        public void Work()
        {
            Random rand = new Random();
            bool inRoute = false;
            while (true)
            {
                if (inRoute)
                {
                    Console.Write($"В пути поезд - ");
                    _train.ShowInfo();
                    Console.WriteLine($"Прибудет к месту назначения через {_route.TimeInRoute} часов\n\n");
                }
                else
                {
                    Console.WriteLine("Поездов в пути нет.\n\n");
                }

                if (_route == null)
                {
                    Console.WriteLine("Для продолжения необходимо создать новый путь.");
                    CreateRoute();
                    _soldTeickets = rand.Next(50, 100);
                    CreateTrain();
                    inRoute = true;
                }
                else
                {
                    if (_route.TimeInRoute > 0)
                    {
                        _route.SkipHour();
                    }
                    else
                    {
                        Console.WriteLine($"Поезд {_train.RouteName} прибыл.");
                        _route = null;
                        _train = null;
                        inRoute = false;
                    }
                }

                Console.WriteLine("Для продолжения нажмите любую клавишу.");
                Console.ReadLine();
                Console.Clear();
            }


        }
        private void CreateTrain()
        {
            _train = new Train(_route.Name, _soldTeickets);
        }
        private void CreateRoute()
        {
            Console.Write("Введите название пути: ");
            string routeName = Console.ReadLine();
            Console.Write("\nВведите цену поездки: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nВведите время поездки: ");
            int timeInRoute = Convert.ToInt32(Console.ReadLine());

            _route = new Route(routeName, price, timeInRoute);
        }
    }
    class Route
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public int TimeInRoute { get; private set; }

        public Route(string name, int price, int timeInRoute)
        {
            Name = name;
            Price = price;
            TimeInRoute = timeInRoute;
        }

        public void SkipHour()
        {
            TimeInRoute--;
        }
    }
    class Wagon
    {
        public int PlaceAmount { get; private set; }

        public Wagon(int placeAmount)
        {
            PlaceAmount = placeAmount;
        }
    }
    class Train
    {
        public int WagonsAmount { get; private set; }
        public string RouteName { get; private set; }
        public int AllPlace { get; private set; }
        public int ReservedPlace { get; private set; }

        private List<Wagon> _wagons = new List<Wagon>();

        public Train(string routeName, int reservedPlace)
        {
            RouteName = routeName;
            ReservedPlace = reservedPlace;
            CreateWagon(ReservedPlace);
        }

        private void CreateWagon(int reservedPlace)
        {
            Random rand = new Random();
            AllPlace = 0;

            while (AllPlace < reservedPlace)
            {
                int placeinWagon = rand.Next(10, 16);
                _wagons.Add(new Wagon(placeinWagon));
                AllPlace += placeinWagon;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"поезд - {RouteName}, занято мест - {ReservedPlace}/{AllPlace}, количество вагонов - {_wagons.Count}.");
            for (int i = 0; i < _wagons.Count; i++)
            {
                Console.WriteLine($"вагон {i + 1}) мест - {_wagons[i].PlaceAmount}.");
            }
        }
    }
}
