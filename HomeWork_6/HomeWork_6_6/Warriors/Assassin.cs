using System;

namespace HomeWork_6_6.Warriors
{
    class Assassin : Warrior
    {
        private int _critChanse = 15;
        private int _criticalDamage = 170;
        private int _dodgeChance = 25;

        public Assassin(string name) : base(name, 15, 220, 1700){}

        public override void TakeDamage(int damage)
        {
            if(SpellChance(_dodgeChance))
                Console.WriteLine("Боец уклонился");
            else
                base.TakeDamage(damage);
        }

        public override int CalculateDamage(int damage)
        {
            if(SpellChance(_critChanse))
                damage = Damage * _criticalDamage / 100; 

            return base.CalculateDamage(damage);
        }
    }
}
