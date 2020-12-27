using System;

namespace HomeWork_6_6
{
    class Warrior
    {
        public string Name { get; protected set; }
        public int Helth { get; protected set; }
        public int CurrentHealth { get; protected set; }
        public int Damage { get; protected set; }
        public int Armor { get; protected set; }

        public Warrior(string name, int armor, int damage, int helth)
        {
            Name = name;
            Helth = helth;
            CurrentHealth = Helth;
            Armor = armor;
            Damage = damage;
        }

        public virtual int CalculateDamage(int damage)
        {
            Random rand = new Random();

            int lowerBar = damage - (damage * 25 / 100);
            int upperBar = damage + (damage * 25 / 100);
            damage = rand.Next(lowerBar, upperBar);

            return damage;
        }

        public virtual void TakeDamage(int damage)
        {
            damage = damage - (damage * Armor / 100);
            CurrentHealth -= damage;
        }

        public void ShowInfo()
        {
            Console.WriteLine($" урон - {Damage}, броня - {Armor}, HP - {Helth}");
        }

        public void ShowHP()
        {
            Console.WriteLine($"осталось здоровья - {CurrentHealth}");
        }

        public bool SpellChance(int prockChance)
        {
            Random rand = new Random();
            int Chance = rand.Next(0, 100);
            if (Chance < prockChance)
                return true;
            else
                return false;

            
        }
    }
}
