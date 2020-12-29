using System;

namespace HomeWork_6_6.Warriors
{
    class Palladin : Warrior
    {
        private int _prayPower = 30;
        private int _prayChance = 30;

        public Palladin(string name) : base(name ,50 , 200, 2500){}

        public override void TakeDamage(int damage)
        {
            if(CurrentHealth < Helth * 10 / 100)
            {
                if (SpellChance(_prayChance))
                {
                    Pray();
                    Console.WriteLine("Палладин помолился и восстановил часть здоровья");
                }
            }
            base.TakeDamage(damage);
        }

        private void Pray()
        {
            CurrentHealth += Helth * _prayPower / 100;
        }
    }
}
