using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_7_7_UnificationOfTheTroops
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> firstSquad = new List<Soldier>();
            List<Soldier> secondSquad = new List<Soldier>();

            firstSquad.Add(new Soldier("Даниил", "Бондарев", Ranks.Cadet));
            firstSquad.Add(new Soldier("Александр", "Волков", Ranks.Cadet));
            firstSquad.Add(new Soldier("Артем", "Феоктистов", Ranks.Captain));
            firstSquad.Add(new Soldier("Еврегий", "Бредихин", Ranks.Cadet));
            firstSquad.Add(new Soldier("Павел", "Шабанов", Ranks.Cadet));

            secondSquad.Add(new Soldier("Василий", "Пупкин", Ranks.Captain));
            secondSquad.Add(new Soldier("Николай", "Заречный", Ranks.Cadet));
            secondSquad.Add(new Soldier("Дмитрий", "Лежнин", Ranks.Cadet));
            secondSquad.Add(new Soldier("Андрей", "Ефимов", Ranks.Cadet));
            secondSquad.Add(new Soldier("Николай", "Прокопов", Ranks.Cadet));

            var filteredFirstSquad = firstSquad.Where(soldier => soldier.SecondName.StartsWith("Б"));
            firstSquad = firstSquad.Except(filteredFirstSquad).ToList();

            secondSquad = secondSquad.Union(filteredFirstSquad).ToList();

            Console.WriteLine("Новый второй отряд:");

            foreach (var soldier in secondSquad)
                Console.WriteLine($"{soldier.SecondName}");

            Console.WriteLine("\nНовый первый отряд");

            foreach (var soldier in firstSquad)
                Console.WriteLine($"{soldier.SecondName}");

            Console.ReadLine();
        }
    }

    class Soldier
    {
        public string SecondName { get; private set; }
        public string FerstName { get; private set; }
        public Ranks Rank { get; private set; }

        public Soldier(string ferstName, string secondName, Ranks rank)
        {
            FerstName = ferstName;
            SecondName = secondName;
            Rank = rank;
        }
    }

    enum Ranks
    {
        Cadet,
        Captain
    }
}
