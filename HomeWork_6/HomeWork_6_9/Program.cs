using System;
using System.Collections.Generic;

namespace HomeWork_6_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();

            aquarium.ShowLifeInside();
        }
    }

    class Aquarium
    {
        private int _placeAmount = 10;
        private List<Fish> _fishesInside = new List<Fish>();
        private List<Fish> _listOfPossibleFishes = new List<Fish>();

        public Aquarium()
        {
            _listOfPossibleFishes.Add(new Fish("Скат", 23));
            _listOfPossibleFishes.Add(new Fish("Бычок", 6));
            _listOfPossibleFishes.Add(new Fish("Сомик", 10));
            _listOfPossibleFishes.Add(new Fish("Илистый прыгун", 3));
            _listOfPossibleFishes.Add(new Fish("Пескарь", 7));
            _listOfPossibleFishes.Add(new Fish("Угорь", 12));
            _listOfPossibleFishes.Add(new Fish("Рыба игла", 10));
        }

        public void ShowLifeInside()
        {
            FillAquarium();
            bool closeProgramm = false;

            while (closeProgramm == false)
            {
                ShowInhabitants();
                CheckAge();

                if (_fishesInside.Count < _placeAmount)
                {
                    Console.WriteLine("Освободились места, добавляется новая рыбка.");
                    FillAquarium();
                }

                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    closeProgramm = true;

                Console.Clear();
                AddAge();
            }
        }

        public void CheckAge()
        {
            bool isEverybodyAlive = true;

            for (int i = 0; i < _fishesInside.Count; i++)
            {
                if (_fishesInside[i].Age >= _fishesInside[i].MaxAge)
                {
                    Console.WriteLine($"Мертвую рыбку {_fishesInside[i].Name} выкинули.");
                    DeleteFish(i);
                    isEverybodyAlive = false;
                    i--;
                }
            }

            if (isEverybodyAlive)
            {
                Console.WriteLine("Все рыбки живы.");
            }
        }

        private void AddAge()
        {
            for (int i = 0; i < _fishesInside.Count; i++)
            {
                _fishesInside[i].AddAge();
            }
        }

        public void DeleteFish(int fishNumber)
        {
            _fishesInside.RemoveAt(fishNumber);
        }

        public void FillAquarium()
        {
            Random rand = new Random();
            while (_fishesInside.Count < _placeAmount)
            {
                int randdomFish = rand.Next(0, _listOfPossibleFishes.Count);
                string fishName = _listOfPossibleFishes[randdomFish].Name;
                string newName = fishName;
                int fishNumber = 1;

                while (CheckNames(newName))
                {
                    fishNumber++;
                    newName = fishName + Convert.ToString(fishNumber);
                    CheckNames(newName);
                }

                _fishesInside.Add(new Fish(newName, _listOfPossibleFishes[randdomFish].MaxAge));
            }

            Console.WriteLine("Аквариум Полон.\n");
        }

        private bool CheckNames(string fishName)
        {
            bool alreadyInAquarium = false;

            for (int i = 0; i < _fishesInside.Count; i++)
            {
                if (_fishesInside[i].Name == fishName)
                {
                    alreadyInAquarium = true;
                    break;
                }
            }

            return alreadyInAquarium;
        }

        public void ShowInhabitants()
        {
            foreach (var fish in _fishesInside)
            {
                fish.Showinfo();
            }
        }
    }

    class Fish
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int MaxAge { get; private set; }

        public Fish(string name, int maxAge, int age = 0)
        {
            Name = name;
            MaxAge = maxAge;
            Age = age;
        }

        public void Showinfo()
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            char[] helthbar = new char[MaxAge];

            Console.Write($"{Name}: возраст - {Age}/{MaxAge}");
            Console.CursorLeft = 30;

            for (int i = 0; i < Age; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.Write("_");
            }
            for (int i = Age; i < MaxAge; i++)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("_");
            }

            Console.BackgroundColor = defaultColor;
            Console.WriteLine("\n");
        }

        public bool AddAge()
        {
            if (Age <= MaxAge)
            {
                Age++;
                return true;
            }
            else
            {
                Console.WriteLine("Рыбка померла.");
                return false;
            }
        }
    }
}
