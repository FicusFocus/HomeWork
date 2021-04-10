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
            
        }
    }

    class Zoo
    {
        private List<Aviary> _aviarys = new List<Aviary>();

        public Zoo()
        {
            AviarysList();
        }

        public void Excursion()
        {
            while (true)
            {
                Console.WriteLine("Добро пожадловать в Зоопарк!");
                Console.WriteLine("\n\nВыберите к какому вольеру желаете подойти:\n" +
                                  "1)Вольер со слонами\n" +
                                  "2) Вольер с попугаями\n" +
                                  "3) Вольер с тюленями\n" +
                                  "4) Вольер со львами\n" +
                                  "5) Вольер с гиенами\n" +
                                  "6) Вольер с дикими собаками Динго\n" +
                                  "7) Вольер с лисами\n");
            }
        }

        public void ShowAAviaryInfo()
        {
            
        }

        public void AviarysList()
        {
            _aviarys.Add(new Aviary(4, "Elephant", "toot"));
            _aviarys.Add(new Aviary(15, "Parrot", "tweet"));
            _aviarys.Add(new Aviary(8, "Seal", "ow-ow-ow"));
            _aviarys.Add(new Aviary(5, "Lion", "roar"));
            _aviarys.Add(new Aviary(10, "Hyena", "laugh"));
            _aviarys.Add(new Aviary(8, "Dingo", "woof"));
            _aviarys.Add(new Aviary(9, "Fox", "What does the fox say? ヽ(ﾟ〇ﾟ)/"));
        }
    }
}
