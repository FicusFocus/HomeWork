using System;
using System.Collections.Generic;
using System.Linq;

//Есть 2 списка в солдатами.
//Всех бойцов из отряда 1, у которых фамилия начинается на букву Б, требуется перевести в отряд 2

namespace HomeWork_7_7_UnificationOfTheTroops
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> ferstSquad = new List<Soldier>();
            List<Soldier> secondSquad = new List<Soldier>();

            ferstSquad.Add(new Soldier("Даниил", "Бондарев", Ranks.Cadet));
            ferstSquad.Add(new Soldier("Александр", "Волков", Ranks.Cadet));
            ferstSquad.Add(new Soldier("Артем", "Феоктистов", Ranks.Captain));
            ferstSquad.Add(new Soldier("Еврегий", "Бредихин", Ranks.Cadet));
            ferstSquad.Add(new Soldier("Павел", "Шабанов", Ranks.Cadet));

            secondSquad.Add(new Soldier("Василий", "Пупкин", Ranks.Captain));
            secondSquad.Add(new Soldier("Николай", "Заречный", Ranks.Cadet));
            secondSquad.Add(new Soldier("Дмитрий", "Лежнин", Ranks.Cadet));
            secondSquad.Add(new Soldier("Андрей", "Ефимов", Ranks.Cadet));
            secondSquad.Add(new Soldier("Николай", "Прокопов", Ranks.Cadet));

            var filteredFerstSquad = ferstSquad.Where(soldier => soldier.SecondName.StartsWith("Б"));
            ferstSquad.RemoveAll(soldier => soldier.SecondName.StartsWith("Б"));

            var updateSecondSquad = secondSquad.Union(filteredFerstSquad);
            secondSquad = updateSecondSquad.ToList();

            Console.WriteLine("Новый второй отряд:");

            foreach (var soldier in secondSquad)
                Console.WriteLine($"{soldier.SecondName}");

            Console.WriteLine("\nНовый первый отряд");

            foreach (var soldier in ferstSquad)
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
