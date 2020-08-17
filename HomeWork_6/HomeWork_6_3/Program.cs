using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace HomeWork_6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            List<Player> players = new List<Player>();

            while (isWork)
            {
                Console.WriteLine("1 - добавить игрока\n" +
                                  "2 - поиск игрока\n" +
                                  "3 - вывести список игроков\n" +
                                  "4 - забанить игрока\n" +
                                  "5 - разбанить игрока\n" +
                                  "6 - удалить игрока\n" +
                                  "7 - выход");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Write("Введите имя персонажа: ");
                        string name = Console.ReadLine();
                        Console.Write("\nВведите уровень персонажа: ");
                        int lvl = Convert.ToInt32(Console.ReadLine());

                        players.Add(new Player(name, lvl));
                        break;
                    case "2":
                        Console.WriteLine("Поиск по номеру - 1, поиско по имени - 2: ");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.Write("Введите порядковый номер персонажа: ");
                                int number = Convert.ToInt32(Console.ReadLine());
                                
                                break;
                             case "2":
                                break;
                        }
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        /////////
        public void FindPlayer(List<Player> players, int number)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (i == number)
                {

                }
            }
        }
        /////////
    }

    class Player
    {
        private string _name;
        private int _lvl;
        private bool _flag;
        public int Number { get; private set; }

        public Player(string name, int lvl = 1, bool flag = true)
        {
            _name = name;
            _lvl = lvl;
            _flag = flag;
        }

        public void FindPlayer(List<Player> players, int number)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (i == number)
                    Number = number;
            }
        }
    }
}
