using System;

//Создать 5 бойцов, пользователь выбирает 2 из них и они сражаются друг с другом до смерти.
// У каждого бойца свои статы. Каждый  боец должен иметь особую способность для атаки, 
// которая свойственна только его классу.

namespace HomeWork_6_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Knight _knight = new Knight(50, 200, 3000);
            Paladin _paladin = new Paladin(50, 200, 2500);
            Druid _druid = new Druid(15, 100, 2200);
            Assassin _assassin = new Assassin(15, 220, 1700);
            Barbarian _barbarian = new Barbarian(30, 500, 2500);


        }

        public void battle()
        {

        }
    }

    class Warrior
    {
        protected int Helth;
        protected int Damage;
        protected int Armor;

        public Warrior(int armor, int damage, int helth)
        {
            Helth = helth;
            Armor = armor;
            Damage = damage;
        }

        public void TakeDamage(int damage, int armor)
        {
            Helth -= damage - (armor * 100);
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

    class Knight : Warrior
    {
        public int MyProperty { get; private set; }
        public Knight(int armor, int damage, int helth) : base(armor, damage, helth)
        {
        }

        public void Bleed()
        {

        }
    }

    class Paladin : Warrior
    {
        public Paladin(int armor, int damage, int helth) : base(armor, damage, helth)
        {
        }
    }

    class Druid : Warrior
    {
        public Druid(int armor, int damage, int helth) : base(armor, damage, helth)
        {
        }
    }

    class Barbarian : Warrior
    {
        public Barbarian(int armor, int damage, int helth) : base(armor, damage, helth)
        {
        }
    }

    class Assassin : Warrior
    {
        public Assassin(int armor, int damage, int helth) : base(armor, damage, helth)
        {
        }
    }
}
