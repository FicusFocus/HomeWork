using System;

namespace HomeWork_6_6
{
    class Warrior
    {
        public string Name { get; protected set; }
        public int Helth { get; protected set; }
        public int Damage { get; protected set; }
        public int Armor { get; protected set; }

        public Warrior(string name, int armor, int damage, int helth)
        {
            Name = name;
            Helth = helth;
            Armor = armor;
            Damage = damage;
        }

        public void TakeDamage(int damage)
        {
            Helth -= damage * Armor / 100;
        }

        public void ShowInfo()
        {
            Console.WriteLine($" урон - {Damage}, броня - {Armor}, HP - {Helth}");
        }

        public bool SpellChance(int prockChance)
        {
            bool chance;

            Random rand = new Random();
            int intChance = rand.Next(0, 100);
            if (intChance < prockChance)
                chance = true;
            else
                chance = false;

            return chance;
        }
    }
}
