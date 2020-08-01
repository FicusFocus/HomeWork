using System;

namespace HomeWork_6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player();
            player1.ShowStats("Bananza", 1000, 15, 150);
        }
    }

    class Player
    {
        private string _name;
        private int _helth;
        private int _armor;
        private int _damage;

        public void ShowStats(string name, int helth, int armor, int damage)
        {
            if (name != null)
                _name = name;
                else _name = "Player";
            if (helth !< 0)
                _helth = helth;
                else _helth = 100;
            if (armor !< 0)
                _armor = armor;
                else _armor = 10;
            if (damage !< 0)
                _damage = damage;
                else _damage = 5;

            Console.WriteLine($"имя - {_name}.\nздоровье - {_helth}.\nброня - {_armor}.\nурон - {_damage}.");
        }
    }
}
