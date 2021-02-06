using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_6_8
{
    class Fighter
    {
        public string Name { get; protected set; }
        public int Damage { get; protected set; }
        public int Helth { get; protected set; }
        public int CurrentHealth { get; protected set; }
        public int Armor { get; protected set; }

        public Fighter(string name, int damage, int helth, int armor, int positionX = 0, int positionY = 0)
        {
            Name = name;
            Damage = damage;
            Helth = helth;
            Armor = armor;
            CurrentHealth = helth;
        }

        public int TakeDamage(ref int damage)
        {
            Random rand = new Random(); 

            int maxDamage = damage + (damage * 25 / 100);
            int minDamage = damage - (damage * 25 / 100);

            damage = rand.Next(minDamage, maxDamage);
            CurrentHealth -= damage;
            return damage;
        }

        public void ShowHelth()
        {
            Console.WriteLine($"На текущий момент у {Name} - {CurrentHealth}/{Helth} HP");
        }
    }
}
