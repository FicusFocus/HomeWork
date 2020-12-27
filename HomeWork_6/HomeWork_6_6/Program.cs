using System;
using System.Collections.Generic;

//Создать 5 бойцов, пользователь выбирает 2 из них и они сражаются друг с другом до смерти.
// У каждого бойца свои статы. Каждый  боец должен иметь особую способность для атаки, 
// которая свойственна только его классу.

//TODO: вылазит эксэпшн если ввесли число больше 5 при выборе бойца.
//TODO: 

namespace HomeWork_6_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Figth figth = new Figth();
            figth.Battle();
        }
    }
}
