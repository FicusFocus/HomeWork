using System;
using System.Collections.Generic;

//ВСЕ ГОВНО ДАВАЙ ПОНОВОЙ!!!!!!!!!!!!!!!!!!!!!

//У вас есть программа, которая помогает пользователю составить план поезда.
//Есть 4 основных шага в создании плана:
//-Создать направление - создает направление для поезда(к примеру Бийск - Барнаул)
//-Продать билеты - вы получаете рандомное кол-во пассажиров, которые купили билеты на это направление
//-Сформировать поезд - вы создаете поезд и добавляете ему столько вагонов(вагоны могут быть разные по вместительности), сколько хватит для перевозки всех пассажиров.
//-Отправить поезд - вы отправляете поезд, после чего можете снова создать направление.
//В верхней части программы должна выводиться полная информация о текущем рейсе или его отсутствии. 


namespace HomeWork_6_5_test_
{
    class Program
    {
        static void Main(string[] args)
        {
            RailwayStation railway = new RailwayStation();
            railway.Work();
            //Console.WriteLine(10/ 8);
        }
    }

    class RailwayStation
    {
        private int _money = 0;
        private List<Passenger> _passengers = new List<Passenger>();
        private List<Route> _routes = new List<Route>();
        private Queue<Train> _trains = new Queue<Train>();
        Dictionary<string, int> _soldTickets = new Dictionary<string, int>();

        public RailwayStation()
        {
            Random rand = new Random();

            _routes.Add(new Route("Москва - Питер", 250, 3.2f));
            _routes.Add(new Route("Москва - Сургут", 120, 3));
            _routes.Add(new Route("Москва - Краснодар", 300, 4.5f));
            _routes.Add(new Route("Москва - Калининград", 200, 2.2f));

            
            AddPassenger(rand.Next(15, 21), rand);
        }

        public void Work()
        {
            Console.WriteLine("money - " + _money);
            SellTicket();
            Console.WriteLine("money - " + _money);
            AddTrains();
            ShowTrains();

            while (true)
            {
                Console.WriteLine($"На текущий момент в пути находится поезд - ");
            }
        }

        private void SellTicket()
        {
            int soldTickets = 0;

            for (int i = 0; i < _routes.Count; i++)
            {
                for (int j = 0; j < _passengers.Count; j++)
                {
                    if (_routes[i].Name == _passengers[j].DesiredRoute)
                    {
                        soldTickets += 1;
                        _money += _routes[i].Price;
                    }
                }
                _soldTickets.Add(_routes[i].Name, soldTickets);
            }
        }

        private void AddTrains()
        {
            Random rand = new Random();
            foreach (var soldTicket in _soldTickets)
            {
                int placeInWagon = rand.Next(5, 10);

                if(soldTicket.Value > placeInWagon)
                {
                    _trains.Enqueue(new Train(soldTicket.Key, placeInWagon, (soldTicket.Value / placeInWagon) + 1, soldTicket.Value));
                }
                else
                {
                    _trains.Enqueue(new Train(soldTicket.Key, placeInWagon, 1, soldTicket.Value));
                }
            }
        }

        private void ShowTrains()
        {
            int trainNumber = 1;
            foreach (var train in _trains)
            {
                Console.WriteLine($"поезд {trainNumber}) {train.RouteName}, свободных мест " +
                                  $"{train.FreePlace}/{train.AllPlaces}, количество вагонов - {train.WagonsAmount}, " +
                                  $"мест в вагоне - {train.PlaceInWagon}.");
                trainNumber++;
            }
        }

        private void AddPassenger(int passengerAmount, Random rand)
        {
            for (int i = 0; i < passengerAmount; i++)
            {
                _passengers.Add(new Passenger(_routes[rand.Next(0, _routes.Count)].Name, rand.Next(120, 300)));
            }
        }
    }

    class Passenger
    {
        private int _money;
        public string DesiredRoute { get; private set; }

        public Passenger(string desiredRoute, int money)
        {
            DesiredRoute = desiredRoute;
            _money = money;
        }
    }

    class Route
    {
        public string Name { get; private set; }
        public int Price { get; private set; }
        public float TravelTime { get; private set; }

        public Route(string name, int price, float travelTime)
        {
            Name = name;
            Price = price;
            TravelTime = travelTime;
        }
    }

    class Train
    {
        public string RouteName { get; private set; }
        public int WagonsAmount { get; private set; }
        public int PlaceInWagon { get; private set; }
        public int AllPlaces { get; private set; }
        public int BusyPlaces { get; private set; }
        public int FreePlace { get; private set; }

        public Train(string routeName, int placeInWagon, int wagonsAmount = 1, int busyPlaces = 0)
        {
            RouteName = routeName;
            WagonsAmount = wagonsAmount;
            PlaceInWagon = placeInWagon;
            AllPlaces = wagonsAmount * placeInWagon;
            FreePlace = AllPlaces - busyPlaces;
        }

        public void FreeThePlace()
        {
            FreePlace += 1;
        }
        public void TakeThePlace()
        {
            FreePlace -= 1;
        }
    }
}
