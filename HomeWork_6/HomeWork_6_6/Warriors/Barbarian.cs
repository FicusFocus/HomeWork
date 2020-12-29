namespace HomeWork_6_6.Warriors
{
    class Barbarian : Warrior
    {
        private int _vampirism = 30;
        private int _vampirismRemaind = 5;
        private int _berserkChance = 10;
        private bool _berserkPossible = true;
        private bool _berserkOn = false;

        public Barbarian(string name) : base(name, 30, 500, 2500){}

        public override int CalculateDamage(int damage)
        {

            if (_berserkPossible)
            {
                if (SpellChance(_berserkChance))
                    _berserkOn = true;
            }

            if (_berserkOn && _vampirismRemaind > 0)
                Berserk(damage);

            return base.CalculateDamage(damage);
        }
        private void Berserk(int damage)
        {
            Helth += damage * _vampirism / 100;
            _vampirismRemaind--;
            _berserkPossible = false;
        }
    }

}
