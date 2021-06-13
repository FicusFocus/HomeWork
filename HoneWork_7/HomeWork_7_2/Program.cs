using System;
using System.Collections.Generic;
using System.Linq;

//В нашей великой стране Арстоцка произошла амнистия!
//Всех людей, заключенных за преступление "Антиправительственное", следует исключить из списка заключенных.
//Есть список заключенных, каждый заключенный состоит из полей: ФИО, преступление.
//Вывести список до амнистии и после.

namespace HomeWork_7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Criminal> criminals = new List<Criminal>();

            criminals.Add(new Criminal("Осипов И.А.", CriminalTip.Антиправительственное));
            criminals.Add(new Criminal("Чилищин Е.О.", CriminalTip.Вандализм));
            criminals.Add(new Criminal("Иваненко И.П.", CriminalTip.Антиправительственное));
            criminals.Add(new Criminal("Феактистов А.А.", CriminalTip.Убийство));
            criminals.Add(new Criminal("Калинин П.А",  CriminalTip.Антиправительственное));
            criminals.Add(new Criminal("Угорелов А.Ю", CriminalTip.Вандализм));
            criminals.Add(new Criminal("Шабанов А.А.", CriminalTip.Убийство));
            criminals.Add(new Criminal("Есенкулов Э.Е", CriminalTip.Убийство));
            criminals.Add(new Criminal("Шевченко А.А", CriminalTip.Антиправительственное));
            criminals.Add(new Criminal("Ковалев И.И", CriminalTip.Вандализм));
            criminals.Add(new Criminal("Мамедов М. М", CriminalTip.Убийство));
            criminals.Add(new Criminal("Лучко В.И", CriminalTip.Антиправительственное));
            criminals.Add(new Criminal("Бондарев Д.А.", CriminalTip.Вандализм));

        }
    }

    class Criminal
    {
        public string Fullname { get; private set; }
        public bool IsInCustody { get; private set; }
        public CriminalTip criminalTip { get; private set; }

        public Criminal(string fullName, CriminalTip criminalTip)
        {
            this.criminalTip = criminalTip;
        }
    }

    enum CriminalTip
    {
        Антиправительственное,
        Вандализм,
        Убийство
    }
}
