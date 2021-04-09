using System;
using System.Collections.Generic;

//Пользователь запускает приложение и перед ним находится меню, 
//в котором он может выбрать, к какому вольеру подойти.
//При приближении к вольеру, 
//пользователю выводится информация о том, что это за вольер, 
//сколько животных там обитает, их пол и какой звук издает животное.
//Вольеров в зоопарке может быть много, в решении нужно создать минимум 4 вольера.

namespace HomeWork6_10_Zoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.AnimalsList();
            zoo.ShowAnimalsInfo();
            //while (true)
            //{
            //    Console.WriteLine("Добро пожадловать в Зоопарк!");
            //    Console.WriteLine("\n\nВыберите действие:\n" +
            //                      "1)Список животных зоопарка.\n" +
            //                      "2)Список вольеров\n");
            //}
        }
    }

    class Zoo
    {
        private List<Animal> _animals = new List<Animal>();

        public void ShowAnimalsInfo()
        {
            for (int i = 0; i < _animals.Count; i++)
            {
                _animals[i].ShowInfo();
            }
        }

        public void AnimalsList()
        {
            _animals.Add(new Animal("Elephant", "male", "toot"));
            _animals.Add(new Animal("Parrot", "male", "tweet"));
            _animals.Add(new Animal("Seal", "male", "ow-ow-ow"));
            _animals.Add(new Animal("Lion", "male", "roar"));
            _animals.Add(new Animal("Hyena", "male", "laugh"));
            _animals.Add(new Animal("Dingo", "male", "woof"));
            _animals.Add(new Animal("Fox", "male", "What does the fox say? ヽ(ﾟ〇ﾟ)/"));
        }
    }

    class Animal
    {
        public string Name { get; private set; }
        public string Gender { get; private set; }
        public string Sound { get; private set; }

        public Animal(string name, string gender, string sound)
        {
            Name = name;
            Gender = gender;
            Sound = sound;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}, пол - {Gender}, Издаваемый звук - {Sound}");
        }
    }
}
