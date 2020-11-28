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
        private List<Passenger> _passangers = new List<Passenger>();
        private Route _route;
        private Train _train;

        public void Work()
        {
            Random rand = new Random();
            bool inRoute = false;


            while (true)
            {
                if(inRoute)
                    Console.WriteLine($"В пути поезд - {_train.RouteName}. Прибудет к месту назначения через {_route.TimeInRoute} часов\n\n\n");
                else
                    Console.WriteLine("Поездов в пути нет.\n\n\n");

                if (_route == null)
                {
                    Console.WriteLine("Для продолжения необходимо создать новый путь.");
                    CreateRoute();
                    SellTickets(rand.Next(50, 100));
                    CreateTrain();
                    inRoute = true;
                }
                else
                {
                    if(_route.TimeInRoute > 0)
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
            Random rand = new Random();
            int placeInWagon = rand.Next(10, 15);

            _train = new Train(_route.Name, placeInWagon, _passangers.Count / placeInWagon + 1, _passangers.Count);

            Console.WriteLine($"\n{_train.RouteName}, {_train.PlaceInWagon} - мест в вагоне" +
                              $"\n{_train.ReservedPlace} - занято мест, {_train.FreePlace} - свободно мест." +
                              $"\n{_train.AllPlace} - всего мест. {_train.WagonsAmount} - количество вагонов.");
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
        private void SellTickets(int passengersAmount)
        {
            for (int i = 0; i < passengersAmount; i++)
            {
                _passangers.Add(new Passenger(_route.Name));
            }
        }
    }

    class Passenger
    {
        public string DesiredRoute { get; private set; }

        public Passenger(string desiredRoute)
        {
            DesiredRoute = desiredRoute;
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

    class Train
    {
        public int WagonsAmount { get; private set; }
        public int PlaceInWagon { get; private set; }
        public int AllPlace { get; private set; }
        public int ReservedPlace { get; private set; }
        public int FreePlace { get; private set; }
        public string RouteName { get; private set; }

        public Train(string routeName, int placeInWagon, int wagonsAmount, int reservedPlace)
        {
            RouteName = routeName;
            PlaceInWagon = placeInWagon;
            WagonsAmount = wagonsAmount;
            AllPlace = placeInWagon * wagonsAmount;
            ReservedPlace = reservedPlace;
            FreePlace = AllPlace - reservedPlace;
        }
    }
}
