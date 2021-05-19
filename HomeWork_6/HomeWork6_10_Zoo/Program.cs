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
                Console.WriteLine("\n\nВыберите к какому вольеру желаете подойти:\n" +
                                  "1) Вольер со слонами\n" +
                                  "2) Вольер с попугаями\n" +
                                  "3) Вольер с тюленями\n" +
                                  "4) Вольер со львами\n" +
                                  "5) Вольер с гиенами\n" +
                                  "6) Вольер с дикими собаками Динго\n" +
                                  "7) Вольер с лисами\n" +
                                  "Введите exit для выхода из программы.");

                string userInput = Console.ReadLine();

                Console.Clear();

                if (int.TryParse(userInput, out int result))
                {
                    zoo.ShowAviaryInfo(result - 1);
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

        public void ShowAviaryInfo(int aviaryNumber)
        {
            _aviarys[aviaryNumber].ShowInfo();
        }

        public void AddAviarys()
        {
            _aviarys.Add(new Aviary(4, "Слоны", "\"Туу\""));
            _aviarys.Add(new Aviary(15, "Попугаи", "\"чирик-чирик\""));
            _aviarys.Add(new Aviary(8, "Тюлени", "\"оу-оу-оу\""));
            _aviarys.Add(new Aviary(5, "Лъвы", "\"Рычит\""));
            _aviarys.Add(new Aviary(10, "Гиены", "\"Смеется\""));
            _aviarys.Add(new Aviary(8, "Дикие собаки Динго", "\"Гав\""));
            _aviarys.Add(new Aviary(9, "Лисы", "\"What the fox say? ヽ(ﾟОﾟ)/\""));
        }
    }

    class Aviary
    {
        private static Random _rand = new Random();
        private List<Animal> _animals = new List<Animal>();
        private int _plaseAmount;
        private string _name;
        private string _gender;
        private string _sound;

        public Aviary(int plaseAmount, string name, string sound)
        {
            _plaseAmount = plaseAmount;
            _name = name;
            _sound = sound;

            FillTheAviary();
        }

        public void FillTheAviary()
        {
            for (int i = 0; i < _plaseAmount; i++)
            {
                _animals.Add(new Animal(_name + (i + 1), _sound, _gender = AssignRandomGender()));
            }
        }

        public void ShowInfo()
        {
            int male = 0;
            int female = 0;

            foreach (var animal in _animals)
            {
                if (animal.Gender == "Самец")
                    male++;
                else
                    female++;
            }

            Console.WriteLine($"В вольере содержаться {_name}. {_name} издаеют звук {_sound}, самок - {female}, самцов - {male}.");
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
        public int Amount { get; private set; }

        public Animal(string name, string sound, string gender)
        {
            Name = name;
            Gender = gender;
            Sound = sound;
        }
    }
}
