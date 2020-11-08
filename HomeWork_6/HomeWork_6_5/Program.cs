using System;
using System.Collections.Generic;


//У вас есть программа, которая помогает пользователю составить план поезда.
//Есть 4 основных шага в создании плана:
//-Создать направление - создает направление для поезда(к примеру Бийск - Барнаул)
//-Продать билеты - вы получаете рандомное кол-во пассажиров, которые купили билеты на это направление
//-Сформировать поезд - вы создаете поезд и добавляете ему столько вагонов(вагоны могут быть разные по вместительности), сколько хватит для перевозки всех пассажиров.
//-Отправить поезд - вы отправляете поезд, после чего можете снова создать направление.
//В верхней части программы должна выводиться полная информация о текущем рейсе или его отсутствии. 


namespace HomeWork_6_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Subway subway = new Subway(20);
            subway.Work();
        }
    }

    class Subway
    {
        private List<Route> _routes = new List<Route>();
        private List<Passenger> _passengers = new List<Passenger>();
        private Queue<Train> _trains = new Queue<Train>();

        public Subway(int passengersCount)
        {
            Random rand = new Random();

            _routes.Add(new Route("Москва - Питер", 12000));
            _routes.Add(new Route("Москва - Краснодар", 10000));
            _routes.Add(new Route("Москва - Калининград", 9000));
            _routes.Add(new Route("Москва - Барнаул", 15000));

            for (int i = 0; i < passengersCount; i++)
            {
                _passengers.Add(new Passenger(_routes[rand.Next(0, _routes.Count)].Name));
            }
        }

        public void ShowRoutes()
        {
            for (int i = 0; i < _routes.Count; i++)
            {
                Console.WriteLine($"Стоимость билетов {_routes[i].Name} составляет - {_routes[i].Price}руб.");
            }
        }

        public void Work()
        {
            for (int i = 0; i < _passengers.Count; i++)
            {
                Console.WriteLine($"пассажир №{i + 1}. Желаемый рейс {_passengers[i].DesiredRoute}, денег - {_passengers[i]._money}");
            }        
        }
        public void ShowCurrentVoyage()
        {

        }
    }

    class Route
    {
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Route(string name,int price)
        {
            Name = name;
            Price = price;
        }
    }

    class Train
    {
        public int Wagons { get; private set; }
        public int PleaceInWagon { get; private set; }

        public Train(int wagons, int pleaseInWagons)
        {
            Wagons = wagons;
            PleaceInWagon = pleaseInWagons;
        }
    }
    
    class Passenger
    {
        public int _money { get; private set; }

        public string DesiredRoute { get; private set; }

        public Passenger(string desiredRoute, int money = 20000)
        {
            _money = money;
            DesiredRoute = desiredRoute;
        }
    }
}