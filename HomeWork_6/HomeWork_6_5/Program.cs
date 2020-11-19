using System;
using System.Collections.Generic;


//У вас есть программа, которая помогает пользователю составить план поезда.
//Есть 4 основных шага в создании плана:
//-Создать направление - создает направление для поезда(к примеру Бийск - Барнаул)
//-Продать билеты - вы получаете рандомное кол-во пассажиров, которые купили билеты на это направление
//-Сформировать поезд - вы создаете поезд и добавляете ему столько вагонов(вагоны могут быть разные по вместительности), сколько хватит для перевозки всех пассажиров.
//-Отправить поезд - вы отправляете поезд, после чего можете снова создать направление.
//В верхней части программы должна выводиться полная информация о текущем рейсе или его отсутствии. 



//у пасажира есть предпочитаемый маршрут и есть деньги, ты выбираешь какой ему дать маршрут.
//Если желаемый маршрут и тот который был присвоен не совпадают пасажир уходит. Если нехватает денег то пасажир уходит
//Как только все пассажиры были раскиданы отправляется первый поезд. 
//

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

        private Queue<Passenger> _passengers = new Queue<Passenger>();
        private List<Train> _trains = new List<Train>();

        public Subway(int passengersCount)
        {
            Random rand = new Random();

            _trains.Add(new Train("Москва - Питер", 12000, 5, rand.Next(1, 3), rand.Next(2, 6)));
            _trains.Add(new Train("Москва - Краснодар", 10000, 8, rand.Next(1, 3), rand.Next(2, 6)));
            _trains.Add(new Train("Москва - Калининград", 9000, 8, rand.Next(1, 3), rand.Next(2, 6)));
            _trains.Add(new Train("Москва - Барнаул", 15000, 12, rand.Next(1, 3), rand.Next(2, 6)));

            for (int i = 0; i < passengersCount; i++)
            {
                _passengers.Enqueue(new Passenger(_trains[rand.Next(0, _trains.Count)].Name, rand.Next(8900, 17001)));
            }
        }
        public void Work()
        {

            while (true)
            {
                for (int i = 0; i < _trains.Count; i++)
                {
                    Console.WriteLine($"Поезд {_trains[i].Name}. Свободно мест - {_trains[i].FreePlace}/{_trains[i].AllPleaces}");
                }
            }
        }

        public void ShowCurrentCruise()
        {

        }
    }

    class Train
    {
        public int Wagons { get; private set; }
        public int PleaceInWagon { get; private set; }
        public int AllPleaces { get; private set; }
        public int Price { get; private set; }
        public int TravelTime { get; private set; }
        public int FreePlace { get; private set; }
        public string Name { get; private set; }

        public Train(string name, int price, int travelTime, int wagons, int pleaseInWagon)
        {
            Name = name;
            Price = price;
            TravelTime = travelTime;
            Wagons = wagons;
            PleaceInWagon = pleaseInWagon;
            AllPleaces = pleaseInWagon * wagons;
            FreePlace = AllPleaces;

        }

        public void ChangePleace()
        {

        }
    }
    
    class Passenger
    {
        private int _money;
        
        public string DesiredRoute { get; private set; }

        public Passenger(string desiredRoute, int money = 20000)
        {
            _money = money;
            DesiredRoute = desiredRoute;
        }

        private bool CheckSolvency(int moneyToPay)
        {
            if (moneyToPay > _money || moneyToPay < 0)
                return false;
            else
                return true;
        }
        public void Pay(int moneyToPay)
        {
            if (CheckSolvency(moneyToPay))
                _money -= moneyToPay;
            else
                Console.WriteLine("У пассажира недостаточно денег");
        }
    }
}