using System;

//Создать 5 бойцов, польщователь выбирает 2 из них и они сражаются друг с другом до смерти.
// У каждого бойца свои статы. Каждый  боец должен иметь особую способность для атаки, 
// которая свойственна только его классу.

//Классы: Воин, Маг, Друид, Варвар, Убийца.

// рыцарь - латы, мечь (шанс кровотечения), шанс блокировать. 2000 хп, слаб против мага, с барбом на равне, силен против дру и убийцы.
//урон по тряпкам и коже
//
// Маг - тряпки, посох (ожоги), всегда получает по морде. 500 хп, слаб проитв друли и убийцы, силен против вара и барба.
// пробитие лат и кольчуги
//
// Друид - шкура, когти (шанс кровотечения), шанс уклониться. 1500 хп, слаб против вара и барба, силен против мага и убийцы.
//урон по тряпкам и коже
//
// Варвар - кольчуга, молот (шанс оглушения), Шанс парировать. 1800 хп, слаб против мага и убийцы, силен против дру. с варом на равне. 
// урон по латам
//
// Убийца - кожа, отравленные кинжалы(шанс отравить). шанс уклониться. 1000, силен против мага и барба, слаб против вара и дру.

namespace HomeWork_6_6
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    class Warrior
    {
        public int Helth { get; private set; }
        public int Damage { get; private set; }
        public int Armor { get; private set; }
        public string DamageTip { get; private set; }
        public string ArmorTip { get; private set; }

        public Warrior(int armor, int damage, int helth, string damageTip, string armorTip)
        {
            Helth = helth;
            Armor = armor;
            Damage = damage;
        }
    }

    class Knight : Warrior
    {
        
    }

    class Wizard : Warrior
    {
        
    }

    class Druid : Warrior
    {
       
    }

    class Barbarian : Warrior
    {
        
    }

    class Assassin : Warrior
    {
        
    }
}
