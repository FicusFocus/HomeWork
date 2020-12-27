using System;

//2500ХР, армор 30%.
//урон - 500
// 10% возможно сть получить состояние берсерк - Вампиризм 30% на 5 ходов.

namespace HomeWork_6_6.Warriors
{
    class Barbarian : Warrior
    {
        private int _vampirism = 30;

        public Barbarian(string name) : base(name, 30, 500, 2500){}

        public override int CalculateDamage(int damage)
        {
            bool berserkPossible = true;
            bool berserkOn = false;
            int spellRemainder = 5;

            if (berserkPossible)
            {
                if (SpellChance(10))
                {
                    berserkOn = true;
                    berserkPossible = false;
                }
            }

            if (berserkOn && spellRemainder > 0)
                Berserk(damage);

            return base.CalculateDamage(damage);
        }
        public void Berserk(int damage)
        {
            Helth += damage * _vampirism / 100;
        }
    }

}
