using System;
using System.Collections.Generic;
using HomeWork_6_6.Warriors;


//Создать 5 бойцов, пользователь выбирает 2 из них и они сражаются друг с другом до смерти.
// У каждого бойца свои статы. Каждый  боец должен иметь особую способность для атаки, 
// которая свойственна только его классу.

//TODO: вылазит эксэпшн если ввесли число больше 5 при выборе бойца.
//TODO: 

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
                    int damage;


                    damage = Warriors[firstFiter].CalculateDamage(Warriors[firstFiter].Damage);
                    Warriors[secondFiter].TakeDamage(damage);
                    Console.WriteLine($"{Warriors[firstFiter].Name} атакует {Warriors[secondFiter].Name} " +
                                      $"и наносит урон в размере - {damage}");
                    Warriors[secondFiter].ShowHP();

                    damage = Warriors[secondFiter].CalculateDamage(Warriors[secondFiter].Damage);
                    Warriors[firstFiter].TakeDamage(damage);
                    Console.WriteLine($"{Warriors[secondFiter].Name} атакует {Warriors[firstFiter].Name} " +
                                      $"и наносит урон в размере - {damage}");
                    Warriors[firstFiter].ShowHP();
                    Console.WriteLine();

                    if (Warriors[firstFiter].CurrentHealth <= 0 || Warriors[secondFiter].CurrentHealth <= 0)
                    {
                        if(Warriors[firstFiter].CurrentHealth <= 0)
                            Console.WriteLine($"Победу одержал {Warriors[secondFiter].Name}.");
                        else
                            Console.WriteLine($"Победу одержал {Warriors[firstFiter].Name}.");
                        battleContinue = false;
                        Warriors[firstFiter].Refresh();
                        Warriors[secondFiter].Refresh();
                    }
                }

                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
