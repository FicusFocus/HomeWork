using System;

namespace HomeWork_6_6.Warriors
{
//    	Палладин
//2500ХР, армор 50%.
//урон 200.
//если остается 20%хп то может помолиться и восстановить 50% здоровья.
    class Palladin : Warrior
    {
        public Palladin(string name) : base(name ,50, 200, 2500)
        {
        }

        public override int TakeDamage(int damage)
        {
            Random rand = new Random();

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

        private void Pray(int prayPower = 50)
        {
            CurrentHealth += Helth * prayPower / 100;
        }
    }
}
