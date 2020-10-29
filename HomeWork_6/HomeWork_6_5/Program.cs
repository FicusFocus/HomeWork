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
            
        }
    }

    class Subway
    {

    }

    class Train
    {
        public int Wagons { get; private set; }
        public int PleaceInWagon { get; private set; }
        public string Route { get; private set; }

        public Train(string route, int wagons, int pleaseInWagons)
        {
            Route = route;
            Wagons = wagons;
            PleaceInWagon = pleaseInWagons;
        }
    }
    
    class Passenger
    {
        private int _money;
    }
}