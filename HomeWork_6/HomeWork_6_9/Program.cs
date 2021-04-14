using System;
using System.Collections.Generic;

//1. FishList - не глагол 
//готово
//2. else { alreadyInAquarium = false; } - лишнее.Оно и так останется false, если не нашел имя 
//
//3. randdomfish - 2 слова 
//
//4. FillTheAquarium - The не надо. 
//готово
//5. FillTheAquarium - много дубляжа кода. 
//
//6. private List<Fish> _fishInAquarium = new List<Fish>(); private List<Fish> _fishs = new List<Fish>(); 
//- Поля/свойства не инициализируем в классе, для этого есть конструктор. 
//
//7. while (true) - у цикла обязательно должно быть условие окончания 
//готово
//8. LifeInside - не глагол.
//

namespace HomeWork_6_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();

            aquarium.LifeInside();
        }
    }

    class Aquarium
    {
        private int _placeAmount = 10;
        private List<Fish> _fishInAquarium = new List<Fish>();
        private List<Fish> _fishs = new List<Fish>();

        public Aquarium()
        {
            _fishs.Add(new Fish("Скат", 23));
            _fishs.Add(new Fish("Бычок", 6));
            _fishs.Add(new Fish("Сомик", 10));
            _fishs.Add(new Fish("Илистый прыгун", 3));
            _fishs.Add(new Fish("Пескарь", 7));
            _fishs.Add(new Fish("Угорь", 12));
            _fishs.Add(new Fish("Рыба игла", 10));
        }

        public void LifeInside()
        {
            FillAquarium();
            bool closeProgramm = false;

            while (closeProgramm == false)
            {
                ShowInhabitants();
                CheckAge();

                if (_fishInAquarium.Count < _placeAmount)
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
            for (int i = 0; i < _fishInAquarium.Count; i++)
            {
                if (_fishInAquarium[i].Age >= _fishInAquarium[i].MaxAge)
                {
                    Console.WriteLine($"Мертвую рыбку {_fishInAquarium[i].Name} выкинули.");
                    DeleteFish(i);
                }
                else
                {
                    Console.WriteLine("Все рыбки живы и здоровы.");
                }
            }
        }

        private void AddAge()
        {
            for (int i = 0; i < _fishInAquarium.Count; i++)
            {
                _fishInAquarium[i].AddAge();
            }
        }

        public void DeleteFish(int fishNumber)
        {
            _fishInAquarium.RemoveAt(fishNumber);
        }

        public void FillAquarium()
        {
            Random rand = new Random();
            while (_fishInAquarium.Count < _placeAmount)
            {
                int randdomfish = rand.Next(0, _fishs.Count);
                string fishName = _fishs[randdomfish].Name;
                string newName = fishName;
                int fishNumber = 1;

                while (CheckNames(newName))
                {
                    fishNumber++;
                    newName = fishName + Convert.ToString(fishNumber);
                    CheckNames(newName);
                }

                _fishInAquarium.Add(new Fish(newName, _fishs[randdomfish].MaxAge));
            }

            Console.WriteLine("Аквариум Полон.\n");
        }

        private bool CheckNames(string fishName)
        {
            bool alreadyInAquarium = false;

            for (int i = 0; i < _fishInAquarium.Count; i++)
            {
                if (_fishInAquarium[i].Name == fishName)
                {
                    alreadyInAquarium = true;
                    break;
                }
                else
                {
                    alreadyInAquarium = false;
                }
            }

            return alreadyInAquarium;
        }

        public void ShowInhabitants()
        {
            foreach (var fish in _fishInAquarium)
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
