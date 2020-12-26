using System;

namespace HomeWork_6_6.Warriors
{
    class Assassin : Warrior
    {
        public Assassin(string name) : base(name, 15, 220, 1700)
        {
        }

        public override int TakeDamage(int damage)
        {
            Random rand = new Random();
            int dodgeChance = rand.Next(1, 100);

            if(dodgeChance <= 20)
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
