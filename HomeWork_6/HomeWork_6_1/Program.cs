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
            _name = name;
            _helth = helth;
            _armor = armor;
            _damage = damage;

            Console.WriteLine($"имя - {_name}.\nздоровье - {_helth}.\nброня - {_armor}.\nурон - {_damage}.");
        }
    }
}
