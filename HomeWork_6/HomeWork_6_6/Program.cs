using System;
using System.Collections.Generic;
using HomeWork_6_6.Warriors;


//Создать 5 бойцов, пользователь выбирает 2 из них и они сражаются друг с другом до смерти.
// У каждого бойца свои статы. Каждый  боец должен иметь особую способность для атаки, 
// которая свойственна только его классу.

namespace HomeWork_6_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Battle();

            
        }

        static void Battle()
        {
            List<Warrior> warriors = new List<Warrior>();

            warriors.Add(new Knight("Рыцарь"));
            warriors.Add(new Palladin("Палладин"));
            warriors.Add(new Druid("Друид"));
            warriors.Add(new Assassin("Убийца"));
            warriors.Add(new Barbarian("Варвар"));

            bool battleContinue = true;

            Console.WriteLine($"палладин против рыцаря");
            Console.Write("Палладин - ");
            warriors[1].ShowInfo();
            Console.Write("Рыцарь - ");
            warriors[0].ShowInfo();

            while (battleContinue)
            {
                warriors[0].TakeDamage(warriors[1].Damage);
                warriors[1].TakeDamage(warriors[0].Damage);

                Console.Write("Палладин - ");
                warriors[1].ShowInfo();
                Console.Write("Рыцарь - ");
                warriors[0].ShowInfo();

                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
