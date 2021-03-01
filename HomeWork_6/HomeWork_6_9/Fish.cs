using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_6_9
{
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
            Console.WriteLine($"{Name} возраст {Age}. Продолжительность жизни - {MaxAge}");
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
                Console.WriteLine("Рыбка издохла и всплыла кверху пузом.");
                return false;
            }
        }
    }
}
