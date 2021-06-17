using System;
using System.Collections.Generic;
using System.Linq;

//У нас есть список всех игроков(минимум 10). 
//У каждого игрока есть поля: имя, уровень, сила.
//Требуется написать запрос для определения топ 3 игроков по уровню и топ 3 игроков по силе, после чего вывести каждый топ.
//2 запроса получится.

namespace HomeWork_7_4_PlayersTop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();

            players.Add(new Player("SantaKlauss", 83, 220));
            players.Add(new Player("ZombI228", 85, 222));
            players.Add(new Player("БурунБык", 73, 200));
            players.Add(new Player("Снедурочка", 90, 190));
            players.Add(new Player("kleoPETR", 50, 100));
            players.Add(new Player("InKYBaToR", 88, 210));
            players.Add(new Player("KlirrrIk", 60, 110));
            players.Add(new Player("StreloK", 81, 200));
            players.Add(new Player("KoloBloK", 90, 150));
            players.Add(new Player("Капатыч", 79, 201));
            players.Add(new Player("Купесь", 85, 193));

        }
    }

    class Player
    {
        public string  Name { get; private set; }
        public int Lvl { get; private set; }
        public int Strength { get; private set; }

        public Player(string name, int lvl, int strength)
        {
            name = name;
            Lvl = lvl;
            Strength = strength;
        }
    }
}
