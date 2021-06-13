using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_7_3_AnarchyInTheHospital
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>();
            #region
            patients.Add(new Patient("Осипов И.А.", 25, Disease.influenza));
            patients.Add(new Patient("Чилищин Е.О.", 18, Disease.quinsy));
            patients.Add(new Patient("Иваненко И.П.", 45, Disease.influenza));
            patients.Add(new Patient("Феактистов А.А.", 25, Disease.quinsy));
            patients.Add(new Patient("Калинин П.А", 18, Disease.allergy));
            patients.Add(new Patient("Угорелов А.Ю", 40, Disease.quinsy));
            patients.Add(new Patient("Шабанов А.А.", 30, Disease.diabetes));
            patients.Add(new Patient("Есенкулов Э.Е", 25, Disease.diabetes));
            patients.Add(new Patient("Шевченко А.А", 20, Disease.allergy));
            patients.Add(new Patient("Ковалев И.И", 30, Disease.quinsy));
            patients.Add(new Patient("Мамедов М. М", 50, Disease.diabetes));
            patients.Add(new Patient("Лучко В.И", 45, Disease.influenza));
            patients.Add(new Patient("Бондарев Д.А.", 18, Disease.quinsy));
            #endregion

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("               БОЛЬНИЦА");
                Console.WriteLine("Выберите по какому параметру желаете отсортировать больных:\n" +
                                  "1)Отсортировать всех больных по фио\n" +
                                  "2)Отсортировать всех больных по возрасту\n" +
                                  "3)Вывести больных с определенным заболеванием");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        var filteredByFullName = patients.OrderBy(patient => patient.Fullname);

                        foreach (var patient in filteredByFullName)
                            patient.ShowInfo();

                        break;

                    case ConsoleKey.D2:
                        var filteredByAge = patients.OrderBy(patient => patient.Age);

                        foreach (var patient in filteredByAge)
                            patient.ShowInfo();

                        break;

                    case ConsoleKey.D3:
                        Console.Write("Введите название заболевания:");
                        string userInput = Console.ReadLine().ToLower();

                        var filteredByDisease = patients.Where(patient => patient.DiseaseName.ToString() == userInput);

                        foreach (var patient in filteredByDisease)
                            patient.ShowInfo();

                        break;
                }

                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    class Patient
    {
        public string Fullname { get; private set; }
        public int Age { get; private set; }
        public Disease DiseaseName { get; private set; }
        public Patient(string fullName, int age, Disease diseaseName)
        {
            this.DiseaseName = diseaseName;
            Fullname = fullName;
            Age = age;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"\n{Fullname} - {Age}лет, заболевание - {DiseaseName}");
        }
    }

    enum Disease
    {
        influenza,
        quinsy,
        diabetes,
        allergy
    }
}
