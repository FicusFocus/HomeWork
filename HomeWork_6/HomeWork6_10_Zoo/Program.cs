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

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Добро пожадловать в Зоопарк!");
                Console.WriteLine("\n\nВыберите к какому вольеру желаете подойти:\n" +
                                  "1)Вольер со слонами\n" +
                                  "2) Вольер с попугаями\n" +
                                  "3) Вольер с тюленями\n" +
                                  "4) Вольер со львами\n" +
                                  "5) Вольер с гиенами\n" +
                                  "6) Вольер с дикими собаками Динго\n" +
                                  "7) Вольер с лисами\n" +
                                  "Нажмите Esc для выхода из программы.\n\n");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Escape:
                        Console.WriteLine("Всего доброго.");
                        isWork = false;
                        break;

                    case ConsoleKey.D1:
                        zoo.ShowAviaryInfo(1);
                        break;

                    case ConsoleKey.D2:
                        break;

                    case ConsoleKey.D3:
                        break;

                    case ConsoleKey.D4:
                        break;

                    case ConsoleKey.D5:
                        break;

                    case ConsoleKey.D6:
                        break;

                    case ConsoleKey.D7:
                        break;
                }
            }

        }
    }
}
