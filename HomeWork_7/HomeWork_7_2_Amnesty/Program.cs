using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_7_2_Amnesty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Criminal> criminals = new List<Criminal>();
            #region
            criminals.Add(new Criminal("Осипов И.А.", CriminalTip.AntiGovernment));
            criminals.Add(new Criminal("Чилищин Е.О.", CriminalTip.Vandalism));
            criminals.Add(new Criminal("Иваненко И.П.", CriminalTip.AntiGovernment));
            criminals.Add(new Criminal("Феактистов А.А.", CriminalTip.Vandalism));
            criminals.Add(new Criminal("Калинин П.А",  CriminalTip.AntiGovernment));
            criminals.Add(new Criminal("Угорелов А.Ю", CriminalTip.Vandalism));
            criminals.Add(new Criminal("Шабанов А.А.", CriminalTip.Murder));
            criminals.Add(new Criminal("Есенкулов Э.Е", CriminalTip.Murder));
            criminals.Add(new Criminal("Шевченко А.А", CriminalTip.AntiGovernment));
            criminals.Add(new Criminal("Ковалев И.И", CriminalTip.Vandalism));
            criminals.Add(new Criminal("Мамедов М. М", CriminalTip.Murder));
            criminals.Add(new Criminal("Лучко В.И", CriminalTip.AntiGovernment));
            criminals.Add(new Criminal("Бондарев Д.А.", CriminalTip.Vandalism));
            #endregion

            Console.WriteLine("До амнистии: ");
            ShowCriminals(criminals);

            var amnestyCriminals = criminals.Where(criminal => criminal.CriminalTip != CriminalTip.AntiGovernment);
            //criminals = amnestyCriminals.ToList();

            Console.WriteLine("После амнистии");

            //ShowCriminals(criminals);
            ShowCriminals(amnestyCriminals.ToList());

            Console.ReadLine();
        }

        public static void ShowCriminals(List<Criminal> criminals)
        {
            foreach (var criminal in criminals)
            {
                Console.Write($"{criminal.Fullname} преступление - {criminal.CriminalTip}");
                if (criminal.IsInCustody)
                    Console.WriteLine(" - под стражей.");
                else
                    Console.WriteLine(" - оправдан.");
            }
        }
    }

    class Criminal
    {
        public string Fullname { get; private set; }
        public bool IsInCustody { get; private set; }
        public CriminalTip CriminalTip { get; private set; }

        public Criminal(string fullName, CriminalTip criminalTip)
        {
            CriminalTip = criminalTip;
            Fullname = fullName;
            IsInCustody = true;
        }
    }

    enum CriminalTip
    {
        AntiGovernment,
        Vandalism,
        Murder
    }
}
