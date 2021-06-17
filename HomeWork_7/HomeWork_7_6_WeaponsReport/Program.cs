using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_7_6_WeaponsReport
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>();

            soldiers.Add(new Soldier("James", Weapon.automaton, Ranks.Lieutenant, 35));
            soldiers.Add(new Soldier("Oliver", Weapon.shotgun, Ranks.Captain, 30));
            soldiers.Add(new Soldier("Jacob", Weapon.rifle, Ranks.Cadet, 8));
            soldiers.Add(new Soldier("Charley", Weapon.pistol, Ranks.Major, 58));
            soldiers.Add(new Soldier("Thomas", Weapon.rifle, Ranks.Captain, 28));
            soldiers.Add(new Soldier("George", Weapon.automaton, Ranks.Lieutenant, 40));
            soldiers.Add(new Soldier("William", Weapon.rifle, Ranks.Cadet, 10));

            var shortInfo = from Soldier soldier in soldiers select new { soldier.Name, soldier.ServiceLife };

            foreach (var soldier in shortInfo)
                Console.WriteLine($"{soldier.Name}, на службе - {soldier.ServiceLife} месяцев.");

            Console.ReadLine();
        }
    }

    class Soldier
    {
        public string Name { get; private set; }
        public Weapon Weapon { get; private set; }
        public Ranks Rank { get; private set; }
        public int ServiceLife { get; private set; }

        public Soldier(string name, Weapon weapon, Ranks rank, int serviceLife)
        {
            Name = name;
            Weapon = weapon;
            Rank = rank;
            ServiceLife = serviceLife;
        }
    }

    enum Ranks
    {
    Cadet,
    Lieutenant,
    Captain,
    Major,
    }

    enum Weapon
    {
        automaton,
        shotgun,
        pistol,
        rifle
    }
}
