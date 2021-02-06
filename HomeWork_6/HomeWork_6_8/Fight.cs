using System;
using System.Collections.Generic;
using HomeWork_6_8.Fighters;

//TODO: Добавить способность бойцам.
//TODO: Возможно добавить новый класс для разнообразия.

namespace HomeWork_6_8
{
    class Fight
    {
        private List<Fighter> _firstSquad = new List<Fighter>();
        private List<Fighter> _secondSquad = new List<Fighter>();

        public Fight()
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

        public void StartFight()
        {
            bool win = false;
            Random rand = new Random();

            while (win == false)
            {
                ShowFightersInfo();
                Console.WriteLine("\n");

                for (int i = 0; i < _firstSquad.Count; i++)
                {
                    int damage = _firstSquad[i].Damage;
                    int enemyFighter = rand.Next(0, _secondSquad.Count);
                    _secondSquad[rand.Next(0, _secondSquad.Count)].TakeDamage(ref damage);

                    Console.WriteLine($"Боец {_firstSquad[i].Name} нанес {damage} урона - {_secondSquad[enemyFighter].Name}");
                }
                Console.WriteLine("\n");

                for (int i = 0; i < _secondSquad.Count; i++)
                {
                    int damage = _secondSquad[i].Damage;
                    int enemyFighter = rand.Next(0, _firstSquad.Count);
                    _firstSquad[enemyFighter].TakeDamage(ref damage);

                    Console.WriteLine($"Боец {_secondSquad[i].Name} нанес {damage} урона - {_firstSquad[enemyFighter].Name}");
                }

                for (int i = 0; i < _firstSquad.Count; i++)
                {
                    if(_firstSquad[i].CurrentHealth <= 0)
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

    }
}
