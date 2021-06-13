using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//У вас есть список больных(минимум 10 записей)
//Класс больного состоит из полей: ФИО, возраст, заболевание.
//Требуется написать программу больницы, в которой перед пользователем будет меню со следующими пунктами:
//1)Отсортировать всех больных по фио
//2)Отсортировать всех больных по возрасту
//3)Вывести больных с определенным заболеванием
//(название заболевания вводится пользователем с клавиатуры)

namespace HomeWork_7_3_AnarchyInTheHospital
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Patient> criminals = new List<Patient>();
            #region
            criminals.Add(new Patient("Осипов И.А.", Disease.AntiGovernment));
            criminals.Add(new Patient("Чилищин Е.О.", Disease.Vandalism));
            criminals.Add(new Patient("Иваненко И.П.", Disease.AntiGovernment));
            criminals.Add(new Patient("Феактистов А.А.", Disease.Vandalism));
            criminals.Add(new Patient("Калинин П.А", Disease.AntiGovernment));
            criminals.Add(new Patient("Угорелов А.Ю", Disease.Vandalism));
            criminals.Add(new Patient("Шабанов А.А.", Disease.Murder));
            criminals.Add(new Patient("Есенкулов Э.Е", Disease.Murder));
            criminals.Add(new Patient("Шевченко А.А", Disease.AntiGovernment));
            criminals.Add(new Patient("Ковалев И.И", Disease.Vandalism));
            criminals.Add(new Patient("Мамедов М. М", Disease.Murder));
            criminals.Add(new Patient("Лучко В.И", Disease.AntiGovernment));
            criminals.Add(new Patient("Бондарев Д.А.", Disease.Vandalism));
            #endregion
        }
    }

    class Patient
    {
        public string Fullname { get; private set; }
        public bool IsInCustody { get; private set; }
        public Disease DiseaseName { get; private set; }
        public Patient(string fullName, Disease criminalTip)
        {
            this.DiseaseName = criminalTip;
            Fullname = fullName;
            IsInCustody = true;
        }
    }

    enum Disease
    {
        AntiGovernment,
        Vandalism,
        Murder
    }
}
