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
            criminals.Add(new Criminal("Осипов И.А.", true, 178, 85, Nationality.Russian));
            criminals.Add(new Criminal("Чилищин Е.О.", false, 187, 90, Nationality.Russian));
            criminals.Add(new Criminal("Иваненко И.П.", true, 160, 93, Nationality.Ukrainian));
            criminals.Add(new Criminal("Феактистов А.А.", false, 210, 115, Nationality.Russian));
            criminals.Add(new Criminal("Калинин П.А", false, 192, 100, Nationality.Russian));
            criminals.Add(new Criminal("Угорелов А.Ю", true, 175, 70, Nationality.Russian));
            criminals.Add(new Criminal("Шабанов А.А.", true, 183, 68, Nationality.Russian));
            criminals.Add(new Criminal("Есенкулов Э.Е", true, 197, 105, Nationality.Georgian));
            criminals.Add(new Criminal("Шевченко А.А", false, 169, 78, Nationality.Ukrainian));
            criminals.Add(new Criminal("Ковалев И.И", false, 190, 80, Nationality.Russian));
            criminals.Add(new Criminal("Мамедов М. М", true, 185, 80, Nationality.Georgian));
            criminals.Add(new Criminal("Лучко В.И", false, 187, 90, Nationality.Ukrainian));
            criminals.Add(new Criminal("Бондарев Д.А.", false, 188, 93, Nationality.Russian));
            #endregion

            bool isWork = true;

            while (isWork)
            {
                int height;
                int weight;
                int nattionalityNumber;
                string userInput;


                Console.WriteLine("Введите рост, вес и национальность:\n");
                Console.Write("Введите рост: ");
                userInput = Console.ReadLine();
                var result = int.TryParse(userInput, out height);
                Console.Write("\nВведите вес: ");
                userInput = Console.ReadLine();
                result = int.TryParse(userInput, out weight);
                Console.Write($"\nВыберите национальность:\n1) - {(Nationality)1}\n2) - {(Nationality)2}\n3) {(Nationality)3}\n");
                userInput = Console.ReadLine();
                result = int.TryParse(userInput, out nattionalityNumber);

                var filteredCriminals = criminals.Where(criminal => criminal.Height == height &&
                                                        criminal.Weight == weight &&
                                                        criminal.Nationality == (Nationality)nattionalityNumber &&
                                                        criminal.IsInCustody == false);

                foreach (var criminal in filteredCriminals)
                    Console.WriteLine(criminal.FullName);


                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    enum Nationality
    {
        Russian = 1,
        Ukrainian,
        Georgian
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
