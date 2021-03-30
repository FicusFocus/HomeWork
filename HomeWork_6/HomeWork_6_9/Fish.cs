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
        public bool IsAlive { get; private set; }

        public Fish(string name, int maxAge, int age = 0)
        {
            Name = name;
            MaxAge = maxAge;
            Age = age;
            IsAlive = true;
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
