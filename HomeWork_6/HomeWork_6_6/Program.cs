using System;
using System.Collections.Generic;
using HomeWork_6_6.Warriors;


//Создать 5 бойцов, пользователь выбирает 2 из них и они сражаются друг с другом до смерти.
// У каждого бойца свои статы. Каждый  боец должен иметь особую способность для атаки, 
// которая свойственна только его классу.

//TODO: криво работает бой. исправить.

namespace HomeWork_6_6
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Warrior> Warriors = new List<Warrior>(); //Это должно быть в отдельном класе, как и оснавная бойня.
            Warriors.Add(new Knight("Рыцарь"));
            Warriors.Add(new Palladin("Палладин"));
            Warriors.Add(new Druid("Друид"));
            Warriors.Add(new Assassin("Убийца"));
            Warriors.Add(new Barbarian("Варвар"));

            while (true)
            {
                bool battleContinue = true;
                int firstFiter;
                int secondFiter;

                Console.WriteLine("Выберите двух бойцов из списка которые будут сражаться.");

                // убрать список бойцов в отдельный метод
                for (int i = 0; i < Warriors.Count; i++)
                    Console.WriteLine($"{i + 1}){Warriors[i].Name}: HP - {Warriors[i].Helth}, броня - {Warriors[i].Armor}, урон - {Warriors[i].Damage}.");

                Console.Write("Номер первого бойца: ");
                firstFiter = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Write("Номер второго бойца: ");
                secondFiter = Convert.ToInt32(Console.ReadLine()) - 1;

                while (battleContinue)
                {
                    int damdge;

                    damdge = Warriors[secondFiter].TakeDamage(Warriors[firstFiter].Damage);
                    Console.WriteLine($"{Warriors[firstFiter].Name} атакует {Warriors[secondFiter].Name} " +
                                      $"и наносит урон в размере - {damdge}");
                    damdge = Warriors[firstFiter].TakeDamage(Warriors[secondFiter].Damage);
                    Console.WriteLine($"{Warriors[secondFiter].Name} атакует {Warriors[firstFiter].Name}");


                    Warriors[firstFiter].TakeDamage(Warriors[secondFiter].Damage);
                    Warriors[secondFiter].TakeDamage(Warriors[firstFiter].Damage);

                    Console.Write(Warriors[firstFiter].Name);
                    Console.WriteLine("нанес урон " + damage1 + " ");
                    Warriors[firstFiter].ShowInfo();
                    Console.Write(Warriors[secondFiter].Name);
                    Console.WriteLine("нанес урон " + damage2 + " ");
                    Warriors[secondFiter].ShowInfo();

                    Console.WriteLine("");

                    if (Warriors[firstFiter].Helth <= 0 || Warriors[secondFiter].Helth <= 0)
                    {
                        if(Warriors[firstFiter].Helth <= 0)
                            Console.WriteLine($"Победу одержал {Warriors[secondFiter].Name}.");
                        else
                            Console.WriteLine($"Победу одержал {Warriors[firstFiter].Name}.");
                        battleContinue = false;
                    }
                }

                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
