using System;
using System.Collections.Generic;

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
                        string playerName = Console.ReadLine();

                        players.Add(new Player(players.Count + 1, playerName, 1));
                        break;

                    case "2":
                        Console.Write("Введите номер игрока которого желаете найти: ");
                        int number = Convert.ToInt32(Console.ReadLine()) - 1;

                        if (number > players.Count || number < 0)
                        {
                            Console.WriteLine("Игрока с таким номером не существует.");
                            break;
                        }
                        players[number].ShowInfo();
                        break;

                    case "3":
                        Console.WriteLine("Введите номер игрока которого желаете найти: ");
                        number = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (number > players.Count || number < 0)
                        {
                            Console.WriteLine("Игрока с таким номером не существует.");
                            break;
                        }
                        for (int i = 0; i < players.Count; i++)
                            players[i].ShowInfo();
                        break;

                    case "4":
                        Console.WriteLine("Введите номер игрока которого желаете забанить: ");
                        number = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (number > players.Count || number < 0)
                        {
                            Console.WriteLine("Игрока с таким номером не существует.");
                            break;
                        }
                        else
                            players[number].Flag = false;
                        break;
                    case "5":
                        Console.WriteLine("Введите номер игрока которого желаете разбанить: ");
                        number = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (number > players.Count || number < 0)
                        {
                            Console.WriteLine("Игрока с таким номером не существует.");
                            break;
                        }
                        else
                            players[number].Flag = true;
                        break;
                    case "6":
                        Console.WriteLine("Введите номер игрока которого желаете удалить: ");
                        number = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (number > players.Count || number < 0)
                        {
                            Console.WriteLine("Игрока с таким номером не существует.");
                            break;
                        }
                        else
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
    }

    class Player
    {
        public int Number;
        public string Name;
        public int Lvl;
        public bool Flag;

        public Player(int number, string name, int lvl, bool flag = true)
        {
            Number = number;
            Name = name;
            Lvl = lvl;
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
