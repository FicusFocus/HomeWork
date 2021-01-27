using System;

namespace HomeWork_6_6.Warriors
{
    class Knight : Warrior
    {

        public Knight(string name) : base(name, 50, 200, 3000){}

        public override void TakeDamage(int damage)
        {
            if (CurrentHealth < Helth * 30 / 100)
                IncreaseArmor();

            base.TakeDamage(damage);
        }

        private void IncreaseArmor()
        {
            Armor += 2;
            Console.WriteLine("Рыцарь увеличил броню на 1");
        }
    }
}
