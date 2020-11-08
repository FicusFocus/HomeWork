using System;
using System.Collections.Generic;

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
        }
    }

    class RailwayStation
    {
        private int _money = 0;
        private List<Passenger> _passengers = new List<Passenger>();
        private List<Route> _routes = new List<Route>();
        private List<Train> _trains = new List<Train>();
        private Dictionary<string, int> _soldTickets = new Dictionary<string, int>();

        public RailwayStation()
        {
            Random rand = new Random();

            _routes.Add(new Route("Москва - Питер", 250, 3.2f));
            _routes.Add(new Route("Москва - Сургут", 120, 3));
            _routes.Add(new Route("Москва - Краснодар", 300, 4.5f));
            _routes.Add(new Route("Москва - Калининград", 200, 2.2f));

            CreateTrain(rand);
            AddPassenger(rand.Next(15, 21), rand);
        }

        public void Work()
        {
            Console.WriteLine(_money);
            SellTicket();
            Console.WriteLine(_money);
        }
        private void CreateTrain(Random rand)
        {
            for (int i = 0; i < _soldTickets.Count; i++)
            {
                
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
                        soldTickets++;
                        _money += _routes[i].Price;
                    }
                }
                _soldTickets.Add(_routes[i].Name, soldTickets);
                soldTickets = 0;
            }
        }

        private void ShowTrains()
        {
            for (int i = 0; i < _trains.Count; i++)
            {
                Console.WriteLine($"поезд {i + 1}) {_trains[i].RouteName}, свободных мест {_trains[i].FreePlace}/{_trains[i].PlaceInWagon} ");
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
        public int FreePlace { get; private set; }

        public Train(string routeName, int placeInWagon, int wagonsAmpunt = 1)
        {
            RouteName = routeName;
            WagonsAmount = wagonsAmpunt;
            PlaceInWagon = placeInWagon;
            FreePlace = placeInWagon;
        }

        public void CreateNewWagon()
        {
            WagonsAmount += 1;
        }
        public void TakePlace()
        {
            FreePlace -= 1;
        }
    }
}
