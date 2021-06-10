using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_7_1_CriminalList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Criminal> criminals = new List<Criminal>();
            #region
            criminals.Add(new Criminal("Осипов И.А.", true, 178, 85, Nationality.Русский));
            criminals.Add(new Criminal("Чилищин Е.О.", false, 187, 90, Nationality.Русский));
            criminals.Add(new Criminal("Иваненко И.П.", true, 160, 93, Nationality.Украинец));
            criminals.Add(new Criminal("Феактистов А.А.", false, 210, 115, Nationality.Русский));
            criminals.Add(new Criminal("Калинин П.А", false, 192, 100, Nationality.Русский));
            criminals.Add(new Criminal("Угорелов А.Ю", true, 175, 70, Nationality.Русский));
            criminals.Add(new Criminal("Шабанов А.А.", true, 183, 68, Nationality.Русский));
            criminals.Add(new Criminal("Есенкулов Э.Е", true, 197, 105, Nationality.Грузин));
            criminals.Add(new Criminal("Шевченко А.А", false, 169, 78, Nationality.Украинец));
            criminals.Add(new Criminal("Ковалев И.И", false, 190, 80, Nationality.Русский));
            criminals.Add(new Criminal("Мамедов М. М", true, 185, 80, Nationality.Грузин));
            criminals.Add(new Criminal("Лучко В.И", false, 187, 90, Nationality.Украинец));
            criminals.Add(new Criminal("Бондарев Д.А.", false, 188, 93, Nationality.Русский));
            #endregion

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("По какому параметру желаете найти пресутпника:\n" +
                                  "1) по росту\n" +
                                  "2) по весу\n" +
                                  "3) по национальности\n" +
                                  "4) по всем параметрам сразу.");


                switch (Console.ReadKey().Key)
                {

                    case ConsoleKey.Escape:
                        isWork = false;
                        Console.WriteLine("Сеанс завершен.");
                        break;

                    case ConsoleKey.D1:
                        Console.Write("Введите предпологаемый рост цели:");

                        int height;
                        string input = Console.ReadLine();
                        bool result = int.TryParse(input, out height);

                        var filteredCriminals = criminals.Where(criminal => criminal.Height == height).Where(criminal => criminal.IsInCustody == false);

                        foreach (var criminal in filteredCriminals)
                            Console.WriteLine(criminal.FullName);
                        break;

                    case ConsoleKey.D2:
                        Console.Write("Введите предпологаемый вес цели:");

                        int weigth;
                        input = Console.ReadLine();
                        result = int.TryParse(input, out weigth);
                        filteredCriminals = criminals.Where(criminal => criminal.Weight == weigth).Where(criminal => criminal.IsInCustody == false);

                        foreach (var criminal in filteredCriminals)
                            Console.WriteLine(criminal.FullName);
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine($"Выберите национальность:\n1) - {(Nationality)1}\n2) - {(Nationality)2}\n 3) {(Nationality)3}\n");
                        
                        int nattionalityNumber;
                        input = Console.ReadLine();
                        result = int.TryParse(input, out nattionalityNumber);
                        filteredCriminals = criminals.Where(criminal => (criminal.Nationality == (Nationality)nattionalityNumber)).Where(criminal => criminal.IsInCustody == false);

                        foreach (var criminal in filteredCriminals)
                            Console.WriteLine(criminal.FullName);

                        break;
                }

                Console.ReadLine();
                Console.Clear();
            }
        }

        enum Nationality
        {
            Русский = 1,
            Украинец,
            Грузин
        }

        class Criminal
        {
            public string FullName { get; private set; }
            public bool IsInCustody { get; private set; }
            public int Height { get; set; }
            public int Weight { get; set; }
            public Nationality Nationality { get; private set; }

            public Criminal(string fullName, bool isInCustody, int height, int weight, Nationality nationality)
            {
                FullName = fullName;
                IsInCustody = isInCustody;
                Height = height;
                Weight = weight;
                Nationality = nationality;
            }
        }
    }
}
