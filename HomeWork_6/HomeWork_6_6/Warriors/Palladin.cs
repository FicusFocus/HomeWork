using System;

//    	Палладин
//2500ХР, армор 50%.
//урон 200.
//если остается 20%хп то может помолиться и восстановить 30% здоровья.

namespace HomeWork_6_6.Warriors
{
    class Palladin : Warrior
    {
        public Palladin(string name) : base(name ,50 , 200, 2500){}

        public override int TakeDamage(int damage)
        {
            if(CurrentHealth < 2500 * 10 / 100)
            {
                if (SpellChance(20))
                {
                    Pray();
                    Console.WriteLine("Палладин помолился и восстановил часть здоровья");
                }
            }
            return base.TakeDamage(damage);
        }

        private void Pray(int prayPower = 30)
        {
            CurrentHealth += Helth * prayPower / 100;
        }
    }
}
