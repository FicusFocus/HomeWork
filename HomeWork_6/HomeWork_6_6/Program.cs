using System;

//Создать 5 бойцов, польщователь выбирает 2 из них и они сражаются друг с другом до смерти.
// У каждого бойца свои статы. Каждый  боец должен иметь особую способность для атаки, 
// которая свойственна только его классу.

namespace HomeWork_6_6
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class Fight
    {
        private Knight _knight = new Knight(50, 200, 3000);
        private Paladin _paladin = new Paladin(50, 200, 2500);
        private Druid _druid = new Druid(15, 100, 2200);
        private Assassin _assassin = new Assassin(15, 220, 1700);
        private Barbarian _barbarian = new Barbarian(30, 500, 2500);
    }

    class Warrior
    {
        public int Helth { get; private set; }
        public int Damage { get; private set; }
        public int Armor { get; private set; }
        public string ArmorTip { get; private set; }

        public Warrior(int armor, int damage, int helth)
        {
            Helth = helth;
            Armor = armor;
            Damage = damage;
        }

        public void TakeDamage(int damage, int armor)
        {

        }
    }
    class Knight : Warrior
    {
        public Knight(int armor, int damage, int helth) : base(armor, damage, helth)
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
