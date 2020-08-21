using System;
using System.Collections.Generic;

namespace HomeWork_6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            int number;

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
                        string playerName = Console.ReadLine();

                        players.Add(new Player(players.Count + 1, playerName, 1));
                        break;
                    case "2":
                        Console.Write("Введите номер игрока которого желаете найти: ");
                        FindPlayer(players, out number);
                        players[number - 1].ShowInfo();
                        break;

                    case "3":
                        for (int i = 0; i < players.Count; i++)
                            players[i].ShowInfo();
                        break;
                    case "4":
                        Console.WriteLine("Введите номер игрока которого желаете забанить: ");
                        FindPlayer(players, out number);
                        players[number - 1].Flag = false;
                        break;
                    case "5":
                        Console.WriteLine("Введите номер игрока которого желаете разбанить: ");
                        FindPlayer(players, out number);
                        players[number - 1].Flag = true;
                        break;
                    case "6":
                        Console.WriteLine("Введите номер игрока которого желаете удалить: ");
                        FindPlayer(players, out number);
                        players.RemoveAt(number);
                            break;
                    case "7":
                        isWork = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void FindPlayer(List<Player> players, out int number)
        {
            bool isCorrect = true;
            number = Convert.ToInt32(Console.ReadLine());
            if (number > players.Count || number < 0)
            {
                while (isCorrect)
                {
                    if (number > players.Count || number < 0)
                    {
                        Console.WriteLine("Игрока с таким номером не существует. Введите номер повторно.");
                        number = Convert.ToInt32(Console.ReadLine());
                    }
                    else
                        isCorrect = false;
                }
            }
        }
    }

    class Player
    {
        private int _number;
        private string _name;
        private int _lvl;
        public bool Flag;

        public Player(int number, string name, int lvl, bool flag = true)
        {
            _number = number;
            _name = name;
            _lvl = lvl;
            Flag = flag;
        }

        public void ShowInfo()
        {
            string flagName;
            if (Flag == true)
                flagName = "свободен";
            else flagName = "забанен";
            Console.WriteLine($"Номер - {Number}, имя - {Name}, уровень - {Lvl}, состояние - {flagName}");
        }
    }
} 
