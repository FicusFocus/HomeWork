using System;
using System.Collections.Generic;

//У вас есть программа, которая помогает пользователю составить план поезда.
//Есть 4 основных шага в создании плана:
//-Создать направление - создает направление для поезда(к примеру Бийск - Барнаул)
//-Продать билеты - вы получаете рандомное кол-во пассажиров, которые купили билеты на это направление
//-Сформировать поезд - вы создаете поезд и добавляете ему столько вагонов(вагоны могут быть разные по вместительности), сколько хватит для перевозки всех пассажиров.
//-Отправить поезд - вы отправляете поезд, после чего можете снова создать направление.
//В верхней части программы должна выводиться полная информация о текущем рейсе или его отсутствии. 

namespace HomeWork6_5_test2
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
        private List<Route> _routes = new List<Route>();
        private List<Passenger> _passangers = new List<Passenger>();
        private List<Train> _trains = new List<Train>();

        public void Work()
        {
            Random rand = new Random();
            bool inRoute = false;
            int routeNumber = 0;

            Console.WriteLine("Необходимо создать первый путь.");
            CreateRoute();

            while (true)
            {
                Console.Clear();

                if (inRoute)
                    Console.WriteLine($"На текущий момент в пути находится поезд - {_trains[_trains.Count - 1].RouteName}");
                else
                    Console.WriteLine("Поездов в пути нет.");

                //Создание пути и продажа билетов
                #region
                Console.Read();
                    Console.WriteLine("Желаете выбрать имеющийся маршрут или создать новый? " +
                                      "\n1) - выбрать имеющийся маршрут." +
                                      "\n2) - создать новый.");
                    switch (Console.ReadLine())
                    {
                        case "1":
                            for (int i = 0; i < _routes.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}) {_routes[i].Name}, стоимость билета - {_routes[i].Price}, всемя поездки - {_routes[i].TimeInRoute}");
                            }
                            Console.Write("Введите номер желаемого маршрута:");
                            routeNumber = Convert.ToInt32(Console.ReadLine()) -1;
                            SellTickets(routeNumber, rand.Next(50, 100));
                            break;

                        case "2":
                            CreateRoute();
                            routeNumber = _routes.Count - 1;
                            SellTickets(routeNumber, rand.Next(50, 100));
                            break;
                    }
                #endregion

                CreateTrain(routeNumber);
                inRoute = true;

                Console.WriteLine("Для продолжения нажмите любую клавишу.");
                Console.Read();
            }
        }

        private void CreateTrain(int routeNumber)
        {
            Random rand = new Random();
            int placeInWagon = rand.Next(10, 15);

            _trains.Add(new Train(_routes[routeNumber].Name, placeInWagon, _passangers.Count / placeInWagon + 1, _passangers.Count));

            Console.WriteLine($"{_passangers.Count} - количество пассажиров");
            Console.WriteLine($"{_trains[0].RouteName}, {_trains[0].PlaceInWagon} - мест в вагоне" +
                              $"\n{_trains[0].ReservedPlace} - занято мест, {_trains[0].FreePlace} - свободно мест." +
                              $"\n{_trains[0].AllPlace} - всего мест. {_trains[0].WagonsAmount} - количество вагонов.");
        }

        private void SellTickets(int routeNumber, int passengersAmount)
        {
            for (int i = 0; i < passengersAmount; i++)
            {
                _passangers.Add(new Passenger(_routes[routeNumber].Name));
            }
        }

        private void CreateRoute()
        {
            Console.Write("Введите название пути: ");
            string routeName = Console.ReadLine();
            Console.Write("\nВведите цену поездки: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nВведите время поездки: ");
            int timeInRoute = Convert.ToInt32(Console.ReadLine());

            _routes.Add(new Route(routeName, price, timeInRoute));
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
