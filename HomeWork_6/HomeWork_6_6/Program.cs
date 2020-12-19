using System;
using System.Collections.Generic;
using HomeWork_6_6.Warriors;


//Создать 5 бойцов, пользователь выбирает 2 из них и они сражаются друг с другом до смерти.
// У каждого бойца свои статы. Каждый  боец должен иметь особую способность для атаки, 
// которая свойственна только его классу.

//TODO: урать лишние циклы и ифы из мэйнаю

namespace HomeWork_6_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Warrior> warriors = new List<Warrior>();
            warriors.Add(new Knight("Рыцарь"));
            warriors.Add(new Palladin("Палладин"));
            warriors.Add(new Druid("Друид"));
            warriors.Add(new Assassin("Убийца"));
            warriors.Add(new Barbarian("Варвар"));

            while (true)
            {
                bool battleContinue = true;
                int firstFiter;
                int secondFiter;

                Console.WriteLine("Выберите двух бойцов из списка которые будут сражаться.");

                // убрать список бойцов в отдельный метод
                for (int i = 0; i < warriors.Count; i++)
                    Console.WriteLine($"{i + 1}){warriors[i].Name}: HP - {warriors[i].Helth}, броня - {warriors[i].Armor}, урон - {warriors[i].Damage}.");

                Console.Write("Номер первого бойца: ");
                firstFiter = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("Номер второго бойца: ");
                secondFiter = Convert.ToInt32(Console.ReadLine()) - 1;

                while (battleContinue)
                {
                    warriors[firstFiter].TakeDamage(warriors[secondFiter].Damage);
                    warriors[secondFiter].TakeDamage(warriors[firstFiter].Damage);

                    Console.Write(warriors[firstFiter].Name);
                    warriors[firstFiter].ShowInfo();
                    Console.Write(warriors[secondFiter].Name);
                    warriors[secondFiter].ShowInfo();

                    Console.WriteLine("");

                    if (warriors[firstFiter].Helth <= 0 || warriors[secondFiter].Helth <= 0)
                    {
                        if(warriors[firstFiter].Helth <= 0)
                            Console.WriteLine($"Победу одержал {warriors[secondFiter].Name}.");
                        else
                            Console.WriteLine($"Победу одержал {warriors[firstFiter].Name}.");
                        battleContinue = false;
                    }
                }

                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
