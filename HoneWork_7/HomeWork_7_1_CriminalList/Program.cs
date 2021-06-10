using System;
using System.Collections.Generic;
using System.Linq;

//У нас есть список всех преступников.
//В преступнике есть поля: ФИО, заключен ли он под стражу, рост, вес, национальность.
//Вашей программой будут пользоваться детективы.
//У детектива запрашиваются данные (рост, вес, национальность), и детективу выводятся все преступники, которые подходят под эти параметры, 
//но уже заключенные под стражу выводиться не должны. 

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
            Console.WriteLine("Введите данные преступника (рост, вес, национальность):");
            Console.Write("Введите рост - ");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nВведите вес - ");
            int weigth = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Выберите национальность:\n1) - {Nationality.Грузин}\n2) - {Nationality.Русский}\n 3) {Nationality.Украинец}");
            int nattionalityNumber = Convert.ToInt32(Console.ReadLine());

            var filteredCriminals = criminals.Where(criminal => criminal.Height == height).
                                    Where(criminal => criminal.Weight == weigth);
                                    //Where(criminal => criminal.Nationality == Nationality);

            foreach (var criminal in filteredCriminals)
            {
                Console.WriteLine(criminal.FullName);
            }

            Console.ReadLine();
        }
    }

    enum Nationality
    {
        Русский,
        Украинец,
        Грузин
    }

    class Criminal
    {
        public string FullName { get; private set; }
        public bool IsInCustody { get; private set; }
        public int Height { get;  set; }
        public int Weight { get;  set; }
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
