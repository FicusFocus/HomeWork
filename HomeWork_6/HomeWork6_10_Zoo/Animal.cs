using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork6_10_Zoo
{
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

        public void ShowInfo()
        {
            Console.WriteLine($"{Name}, пол - {Gender}, Издаваемый звук - {Sound}");
        }
    }
}
