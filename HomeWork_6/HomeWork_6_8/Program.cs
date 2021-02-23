using System;
using System.Collections.Generic;

namespace HomeWork_6_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Fight fight = new Fight();
            fight.StartFight();
            Console.ReadLine();
        }
    }

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

        public virtual int CalculateDamage(int damage)
        {
            Random rand = new Random();

            int maxDamage = damage + (damage * 25 / 100);
            int minDamage = damage - (damage * 25 / 100);

            return damage = rand.Next(minDamage, maxDamage);
        }

        public virtual void TakeDamage(ref int damage)
        {
            damage = damage - (damage * Armor / 100);
            CurrentHealth -= damage;
        }

        public void ShowHelth()
        {
            Console.WriteLine($"На текущий момент у {Name} - {CurrentHealth}/{Helth} HP");
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

    class Fight
    {
        private List<Fighter> _firstSquad = new List<Fighter>();
        private List<Fighter> _secondSquad = new List<Fighter>();

        public void StartFight()
        {
            bool win = false;
            Random rand = new Random();

            AddFighters();

            while (win == false)
            {
                ShowFightersInfo();
                Console.WriteLine("\n");

                for (int i = 0; i < _firstSquad.Count; i++)
                {
                    int damage = _firstSquad[i].CalculateDamage(_firstSquad[i].Damage);
                    int enemyFighter = rand.Next(0, _secondSquad.Count);
                    _secondSquad[rand.Next(0, _secondSquad.Count)].TakeDamage(ref damage);

                    Console.WriteLine($"Боец {_firstSquad[i].Name} нанес {damage} урона - {_secondSquad[enemyFighter].Name}");
                }
                Console.WriteLine("\n");

                for (int i = 0; i < _secondSquad.Count; i++)
                {
                    int damage = _secondSquad[i].CalculateDamage(_secondSquad[i].Damage);
                    int enemyFighter = rand.Next(0, _firstSquad.Count);
                    _firstSquad[enemyFighter].TakeDamage(ref damage);

                    Console.WriteLine($"Боец {_secondSquad[i].Name} нанес {damage} урона - {_firstSquad[enemyFighter].Name}");
                }

                for (int i = 0; i < _firstSquad.Count; i++)
                {
                    if (_firstSquad[i].CurrentHealth <= 0)
                    {
                        Console.WriteLine($"{_firstSquad[i].Name} - умер");
                        _firstSquad.Remove(_firstSquad[i]);
                    }
                }

                for (int i = 0; i < _secondSquad.Count; i++)
                {
                    if (_secondSquad[i].CurrentHealth <= 0)
                    {
                        Console.WriteLine($"{_secondSquad[i].Name} - умер");
                        _secondSquad.Remove(_secondSquad[i]);
                    }
                }

                if (_firstSquad.Count == 0 || _secondSquad.Count == 0)
                {
                    if (_firstSquad.Count == 0)
                        Console.WriteLine("Победил второй отряд.");
                    else
                        Console.WriteLine("Победил первый отряд.");

                    win = true;
                }

                Console.ReadLine();
                Console.Clear();
            }

        }

        public void ShowFightersInfo()
        {
            Console.WriteLine("\nПервый отряд:");

            for (int i = 0; i < _firstSquad.Count; i++)
                _firstSquad[i].ShowHelth();

            Console.WriteLine("\nВторой отряд:");

            for (int i = 0; i < _secondSquad.Count; i++)
                _secondSquad[i].ShowHelth();
        }

        private void AddFighters()
        {
            _firstSquad.Add(new Spearman("Копейщик(1)"));
            _firstSquad.Add(new Spearman("Копейщик(2)"));
            _firstSquad.Add(new Swoardsman("Мечник(1)"));
            _firstSquad.Add(new Swoardsman("Мечник(2)"));
            _firstSquad.Add(new Swoardsman("Мечник(3)"));

            _secondSquad.Add(new Spearman("Копейщик(1)"));
            _secondSquad.Add(new Spearman("Копейщик(2)"));
            _secondSquad.Add(new Swoardsman("Мечник(1)"));
            _secondSquad.Add(new Swoardsman("Мечник(2)"));
            _secondSquad.Add(new Swoardsman("Мечник(3)"));
        }
    }

    class Spearman : Fighter
    {
        private int _critChanse = 40;
        private int _criticalDamage = 70;
        private int _healChanse = 35;
        private int _healTiksAmount = 3;
        private int _increasedHealing = 30;
        private int _healingPover = 50;

        public Spearman(string name) : base(name, 70, 400, 20) { }

        public override int CalculateDamage(int damage)
        {
            if (SpellChance(_critChanse))
            {
                damage += Damage * _criticalDamage / 100;
                Console.WriteLine($"{Name} совершает критическое попадание и нанесет {damage} урона.");
            }

            return base.CalculateDamage(damage);
        }

        public override void TakeDamage(ref int damage)
        {
            if (_healTiksAmount > 0)
            {
                if (SpellChance(_healChanse))
                {
                    CurrentHealth += _healingPover;
                    _healingPover += _increasedHealing;
                    _healTiksAmount--;

                    Console.WriteLine($"{Name} накладывает повязку и восстанавливает {_healingPover} здоровья");
                }
            }

            base.TakeDamage(ref damage);
        }
    }

    class Swoardsman : Fighter
    {
        private int _blockChance = 35;
        private int _elixirsAmount = 2;
        private int _elixirsPover = 250;

        public Swoardsman(string name) : base(name, 50, 500, 20) { }

        public override void TakeDamage(ref int damage)
        {
            if (SpellChance(_blockChance))
            {
                damage = 0;
                Console.WriteLine($"{Name} блокирует удар щитом, урон не прошел.");
            }

            if (CurrentHealth < Helth * 15 / 100 && _elixirsAmount > 0)
            {
                CurrentHealth += _elixirsPover;
                _elixirsAmount--;
                Console.WriteLine($"{Name} Выпивает зелье регинирации и востанавливает {_elixirsPover} здоровья.");
            }

            base.TakeDamage(ref damage);
        }
    }
}
