using System;

//1700ХР, армор 15%. 
//урон  220.
//Крит шанс - увеличенная атака на 170%, 
//шанс уклониться - 25%

namespace HomeWork_6_6.Warriors
{
    class Assassin : Warrior
    {
        public Assassin(string name) : base(name, 15, 220, 1700){}

        public override int TakeDamage(int damage)
        {
            int dodgeChance = 25;

            if(SpellChance(dodgeChance))
            {
                Console.WriteLine("Боец уклонился");
                return 0;
            }
            else
            {
                return base.TakeDamage(damage);
            }
        }
    }
}
