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
            _firstGroup.Add(new Spearman("Копейщик(1)"));
            _firstGroup.Add(new Spearman("Копейщик(2)"));
            _firstGroup.Add(new Swoardsman("Мечник(1)"));
            _firstGroup.Add(new Swoardsman("Мечник(2)"));
            _firstGroup.Add(new Swoardsman("Мечник(3)"));

            _secondGroup.Add(new Spearman("Копейщик(1)"));
            _secondGroup.Add(new Spearman("Копейщик(2)"));
            _secondGroup.Add(new Swoardsman("Мечник(1)"));
            _secondGroup.Add(new Swoardsman("Мечник(2)"));
            _secondGroup.Add(new Swoardsman("Мечник(3)"));
        }

        public void StartFight()
        {
            int fightersAmount = _firstGroup.Count + _secondGroup.Count;
            bool win = false;
            Random rand = new Random();

            while (win == false)
            {
                for (int i = 0; i < fightersAmount; i++)
                {

                }
            }
        }
        public void СhooseEnemy()
        {
            Random rand = new Random();

            for (int i = 0; i < _firstGroup.Count; i++)
            {

            }
        }

    }
}
