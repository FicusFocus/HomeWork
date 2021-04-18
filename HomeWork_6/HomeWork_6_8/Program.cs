using System;
using System.Collections.Generic;

namespace HomeWork_6_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Fight fight = new Fight();
            fight.BeginBattle();
            Console.ReadLine();
        }
    }

    class Fight
    {
        private List<Fighter> _firstSquad = new List<Fighter>();
        private List<Fighter> _secondSquad = new List<Fighter>();
        public Random Rand = new Random();

        public void BeginBattle()
        {
            bool win = false;
            Random rand = new Random();

            AddFighters();

            while (win == false)
            {
                ShowFightersInfo();

                Console.WriteLine("\n");
                AttackEnemy(_firstSquad, _secondSquad);
                Console.WriteLine("\n");
                AttackEnemy(_secondSquad, _firstSquad);

                FinDeadMan(_firstSquad);
                FinDeadMan(_secondSquad);

                win = FindWinner();

                Console.ReadLine();
                Console.Clear();
            }

        }

        public bool FindWinner()
        {
            if (_firstSquad.Count == 0 || _secondSquad.Count == 0)
            {
                if (_firstSquad.Count == 0)
                    Console.WriteLine("Победил второй отряд.");
                else if(_secondSquad.Count == 0)
                    Console.WriteLine("Победил первый отряд.");
                else
                    Console.WriteLine("Пичья");

                return true;
            }

            return false;
        }

        public void FinDeadMan(List<Fighter> squad)
        {
            for (int i = 0; i < squad.Count; i++)
            {
                if (squad[i].CurrentHealth <= 0)
                {
                    Console.WriteLine($"{squad[i].Name} - умер");
                    squad.Remove(squad[i]);
                }
            }
        }

        public void AttackEnemy(List<Fighter> alliedSquad, List<Fighter> anemySquad)
        {
            for (int i = 0; i < alliedSquad.Count; i++)
            {
                int damage = alliedSquad[i].CalculateDamage();
                int enemyFighter = Rand.Next(0, anemySquad.Count);
                anemySquad[enemyFighter].TakeDamage(ref damage);

                Console.WriteLine($"Боец {alliedSquad[i].Name} нанес {damage} урона - {anemySquad[enemyFighter].Name}");
            }
        }

        public void ShowFightersInfo()
        {
            Console.WriteLine("\nПервый отряд:");

            foreach (var squad in _firstSquad)
                squad.ShowHelth();

            Console.WriteLine("\nВторой отряд:");

            foreach (var squad in _secondSquad)
                squad.ShowHelth();
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

    class Fighter
    {
        public string Name { get; protected set; }
        public int AverageDamage { get; protected set; }
        public int Helth { get; protected set; }
        public int CurrentHealth { get; protected set; }
        public int Armor { get; protected set; }

        public Fighter(string name, int averageDamage, int helth, int armor)
        {
            Name = name;
            AverageDamage = averageDamage;
            Helth = helth;
            Armor = armor;
            CurrentHealth = helth;
        }

        public virtual int CalculateDamage()
        {
            Random rand = new Random();
            int maxDamage = AverageDamage + (AverageDamage * 25 / 100);
            int minDamage = AverageDamage - (AverageDamage * 25 / 100);

            return rand.Next(minDamage, maxDamage);
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

        public bool CalculateOpportunity(int chanceOfTriggering)
        {
            Random rand = new Random();
            int Chance = rand.Next(0, 100);
            return (Chance < chanceOfTriggering);
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

        public override int CalculateDamage()
        {
            if (CalculateOpportunity(_critChanse))
            {
                int damage = AverageDamage;
                damage += AverageDamage * _criticalDamage / 100;
                Console.WriteLine($"{Name} совершает критическое попадание и наносит {damage} урона.");
            }

            return base.CalculateDamage();
        }

        public override void TakeDamage(ref int damage)
        {
            if (_healTiksAmount > 0)
            {
                if (CalculateOpportunity(_healChanse))
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
            if (CalculateOpportunity(_blockChance))
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
