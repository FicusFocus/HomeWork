using System;

//2200ХР, армор 15%.
//урон - 150, после кажой атаки урон увеличивается на 50.
//шанс 15% востановить хп на 300.

namespace HomeWork_6_6.Warriors
{
    class Druid : Warrior
    {
        private int _baseDamage = 150;
        private int _increaseAttack = 30;
        private int _healChance = 15;
        private int _healPover = 300;

        public Druid(string name) : base(name, 15, 150, 2200){}

        public override int CalculateDamage(int damage)
        {
            if (SpellChance(_healChance))
                HealingTouch();

            Damage += _increaseAttack;
            return base.CalculateDamage(damage);
        }

        private void HealingTouch()
        {
            CurrentHealth += _healPover;
            Console.WriteLine("Друид совершает целительное прикосновение и восстаналвивает 300 здоровья");
        }
    }
}
