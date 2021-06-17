using System;
using System.Collections.Generic;
using System.Linq;

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

            var topByLvl = players.OrderByDescending(player => player.Lvl).Take(3);
            var topByStrength = players.OrderByDescending(player => player.Strength).Take(3);

            Console.WriteLine("          Топ оп уровню: ");
            ShowPlayersInfo(topByLvl.ToList());
            Console.WriteLine("          Топ по силе: ");
            ShowPlayersInfo(topByStrength.ToList());

            Console.ReadLine();
        }

        public static void ShowPlayersInfo(List<Player> players)
        {
            foreach (var player in players)
                Console.WriteLine($"{player.Name}. Уровень - {player.Lvl}, сила - {player.Strength}");

            Console.WriteLine("");
        }
    }

    class Player
    {
        public string  Name { get; private set; }
        public int Lvl { get; private set; }
        public int Strength { get; private set; }

        public Player(string name, int lvl, int strength)
        {
            Name = name;
            Lvl = lvl;
            Strength = strength;
        }
    }
}
