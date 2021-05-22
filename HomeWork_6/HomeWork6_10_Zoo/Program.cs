using System;
using System.Collections.Generic;

namespace HomeWork6_10_Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Добро пожадловать в Зоопарк!");
                Console.WriteLine("\nВыберите к какому вольеру желаете подойти:\n");
                zoo.ShowAllAviarys();

                string userInput = Console.ReadLine();

                Console.Clear();

                if (int.TryParse(userInput, out int result))
                {
                    zoo.ChooseAviary(result - 1);
                }
                else if(userInput == "exit" || userInput == "Exit")
                {
                    Console.WriteLine("Всего доброго.");
                    isWork = false;
                }
                else
                {
                    Console.WriteLine("Неизвестная команда.");
                }

                Console.ReadLine();
                Console.Clear();
            }

        }
    }

    class Zoo
    {
        private List<Aviary> _aviarys = new List<Aviary>();

        public Zoo()
        {
            AddAviarys();
        }

        public void ChooseAviary(int aviaryNumber)
        {
            if (aviaryNumber < 0 || aviaryNumber > _aviarys.Count)
                Console.WriteLine("Такого вольера не существует");
            else
                ShowAviaryInfo(aviaryNumber);
        }

        public void ShowAviaryInfo(int aviaryNumber)
        {
            _aviarys[aviaryNumber].ShowInfo();
        }

        public void ShowAllAviarys()
        {
            for (int i = 0; i < _aviarys.Count; i++)
                Console.WriteLine($"Вольер {i + 1}) {_aviarys[i].Name} ");
        }

        private void AddAviarys()
        {
            _aviarys.Add(new Aviary(4, "Слонн", "\"Туу\"", "Слоны"));
            _aviarys.Add(new Aviary(15, "Попугай", "\"чирик-чирик\"", "Попугаи"));
            _aviarys.Add(new Aviary(8, "Тюлень", "\"оу-оу-оу\"", "Тюлени"));
            _aviarys.Add(new Aviary(5, "Лев", "\"Рычит\"", "Львы"));
            _aviarys.Add(new Aviary(10, "Гиена", "\"Смеется\"", "Гиены"));
            _aviarys.Add(new Aviary(8, "Динго", "\"Гав\"", "Дикие собаки Динго"));
            _aviarys.Add(new Aviary(9, "Лиса", "\"What the fox say? ヽ(ﾟОﾟ)/\"", "Лисы"));
        }
    }

    class Aviary
    {
        private static Random _rand = new Random();
        private List<Animal> _animals = new List<Animal>();
        private int _males = 0;
        private int _females = 0;

        public string Name { get; private set; }


        public Aviary(int plaseAmount, string AnimalName, string AnimalSound, string name)
        {
            Name = name;
            FillTheAviary(plaseAmount, AnimalName, AnimalSound);
        }

        private void FillTheAviary(int plaseAmount, string  name, string sound)
        {
            for (int i = 0; i < plaseAmount; i++)
            {
                string gender;
                _animals.Add(new Animal(name + (i + 1), sound, gender = AssignRandomGender()));

                if (_animals[i].Gender == "Самец")
                    _males++;
                else
                    _females++;
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"В вольере содержаться {Name}. {Name} издаеют звук {_animals[0].Sound}, " +
                              $"самок - {_females}, самцов - {_males}. Всего животных - {_animals.Count}.");
        }

        private string AssignRandomGender()
        {
            List<string> genders = new List<string>();
            genders.Add("Самец");
            genders.Add("Самка");

            int randomGender = _rand.Next(0, genders.Count);

            return genders[randomGender];
        }
    }

    class Animal
    {
        public string Name { get; private set; }
        public string Gender { get; private set; }
        public string Sound { get; private set; }

        public Animal(string name, string sound, string gender)
        {
            Name = name;
            Gender = gender;
            Sound = sound;
        }
    }
}
