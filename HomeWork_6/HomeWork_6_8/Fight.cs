using System;
using System.Collections.Generic;
using System.Text;
using HomeWork_6_8.Fighters;

namespace HomeWork_6_8
{
    class Fight
    {
        private List<Fighter> _firstGroup = new List<Fighter>();
        private List<Fighter> _secondGroup = new List<Fighter>();

        public Fight()
        {
            _firstGroup.Add(new Archer("Лучник"));
            _firstGroup.Add(new Spearman("Копейщик"));
            _firstGroup.Add(new Swoardsman("Мечник"));

            _secondGroup.Add(new Archer("Лучник"));
            _secondGroup.Add(new Spearman("Копейщик"));
            _secondGroup.Add(new Swoardsman("Мечник"));
        }

        public void StartFight()
        {

        }
    }
}
