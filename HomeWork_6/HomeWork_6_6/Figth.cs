using System;
using System.Collections.Generic;
using HomeWork_6_6.Warriors;

namespace HomeWork_6_6
{
    class Figth
    {
        private List<Warrior> _warriors = new List<Warrior>();

        public void StartFight()
        {
            while (true)
            {
                bool battleContinue = true;
                int firstFiter;
                int secondFiter;

                CrateFighters();
                ShowFighters();
                CheckInput(out firstFiter, out secondFiter);

                while (battleContinue)
                {
                    int damage;

                    damage = _warriors[firstFiter].CalculateDamage(_warriors[firstFiter].Damage);
                    _warriors[secondFiter].TakeDamage(damage);
                    Console.WriteLine($"{_warriors[firstFiter].Name} атакует {_warriors[secondFiter].Name} " +
                                      $"и наносит урон в размере - {damage}");
                    _warriors[firstFiter].ShowHP();

                    damage = _warriors[secondFiter].CalculateDamage(_warriors[secondFiter].Damage);
                    _warriors[firstFiter].TakeDamage(damage);
                    Console.WriteLine($"{_warriors[secondFiter].Name} атакует {_warriors[firstFiter].Name} " +
                                      $"и наносит урон в размере - {damage}");
                    _warriors[secondFiter].ShowHP();
                    Console.WriteLine();

                    if (_warriors[firstFiter].CurrentHealth <= 0 || _warriors[secondFiter].CurrentHealth <= 0)
                    {
                        if (_warriors[firstFiter].CurrentHealth <= 0)
                            Console.WriteLine($"Победу одержал {_warriors[secondFiter].Name}.");
                        else
                            Console.WriteLine($"Победу одержал {_warriors[firstFiter].Name}.");

                        _warriors.RemoveRange(0, _warriors.Count);
                        battleContinue = false;
                    }
                }

                Console.ReadLine();
                Console.Clear();
            }
        }

        private void CheckInput(out int firstFiter, out int secondFiter)
        {
            bool inputIncorrect = true;

            firstFiter = 0;
            secondFiter = 0;

            while (inputIncorrect)
            {
                bool firstInput = false;
                bool secondfinput = false;
                string input;

                Console.WriteLine("Выберите двух бойцов из списка которые будут сражаться.");
                Console.Write("Номер первого бойца: ");
                input = Console.ReadLine();

                if (int.TryParse(input, out firstFiter))
                {
                    firstFiter--;
                    firstInput = true;
                }
                else 
                {
                    Console.WriteLine("Неверное значение"); 
                }

                Console.Write("Номер первого бойца: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out secondFiter))
                {
                    secondFiter--;
                    secondfinput = true;
                }
                else
                {
                    Console.WriteLine("Неверное значение");
                }

                if (firstInput && secondfinput)
                    inputIncorrect = false;
            }
        }

        private void CrateFighters()
        {
            _warriors.Add(new Knight("Рыцарь"));
            _warriors.Add(new Palladin("Палладин"));
            _warriors.Add(new Druid("Друид"));
            _warriors.Add(new Assassin("Убийца"));
            _warriors.Add(new Barbarian("Варвар"));
        }

        private void ShowFighters()
        {
            for (int i = 0; i < _warriors.Count; i++)
            {
                Console.Write($"\n{i + 1}) ");
                _warriors[i].ShowInfo();
            }
        }
    }
}
