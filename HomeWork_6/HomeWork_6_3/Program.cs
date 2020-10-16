﻿using System;
using System.Collections.Generic;

namespace HomeWork_6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerList playerList = new PlayerList();
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Выберите команду:\n" +
                                  "1 - добавить нового игрока\n" +
                                  "2 - забанить игрока\n" +
                                  "3 - разбанить игрока\n" +
                                  "4 - найти игрока\n" + 
                                  "5 - удалить игрока");
                switch (Console.ReadLine())
                {
                    case"1":
                        Console.Write("Введите имя нового игрока: ");
                        string name = Console.ReadLine();
                        playerList.AddPlayer(name);
                        break;

                    case"2":
                        Console.Write("Введите номер игрока которого желаете забанить: ");
                        int number = Convert.ToInt32(Console.ReadLine()) - 1;
                        playerList.Baned(number);
                        break;

                    case"3":
                        Console.Write("Введите номер игрока которого желаете разбанить: ");
                        number = Convert.ToInt32(Console.ReadLine()) - 1;
                        playerList.Unban(number);
                        break;

                    case "4":
                        Console.Write("Введите номер игрока которого желаете найти: ");
                        number = Convert.ToInt32(Console.ReadLine()) - 1;
                        playerList.ShowInfo(number);
                        break;

                    case"5":
                        Console.Write("Введите номер игрока которого желаете удалить: ");
                        number = Convert.ToInt32(Console.ReadLine()) - 1;
                        playerList.Remove(number);
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class PlayerList
    {
        private List<Player> _players = new List<Player>();

        public void ShowInfo(int number)
        {
            if (number > _players.Count || number < 0)
            {
                Console.WriteLine("Игрока с таким порядковым номером не существует.");
            }
            else
            {
                string flag;
                if (_players[number].Ban == true)
                    flag = "свободен";
                else
                    flag = "забанен";
                Console.WriteLine($"{ _players[number].Name}, {_players[number].Lvl} - {flag}");
            }
        }
        public void AddPlayer(string name, int lvl = 1, bool flag = true)
        {
            _players.Add(new Player(name));
            Console.WriteLine($"Вы добавили игрока - {name}. Старотовый уровень - {1}");
        }
        public void Remove(int number)
        {
            if (number > _players.Count || number < 0)
                Console.WriteLine("Игрока с таким порядковым номером не существует.");
            else
                _players.Remove(_players[number]);
        }
        public bool FindPlayer(int number)
        {
            if (number > _players.Count || number < 0)
            {
                Console.WriteLine("Игрока с таким порядковым номером не существует.");
                return false;
            }
            else
            {
                Console.WriteLine(_players[number].Name);
                return true;
            }
        }
        public void Unban(int number)
        {
            if (number > _players.Count || number < 0)
                Console.WriteLine("Игрока с таким порядковым номером не существует.");
            else
                _players[number].Unban();
        }
        public void Baned(int number)
        {
            if (number > _players.Count || number < 0)
                Console.WriteLine("Игрока с таким порядковым номером не существует.");
            else
                _players[number].Baned();
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Lvl { get; private set; }
        public bool Ban { get; private set; }

        public Player(string name, int lvl = 1, bool ban = true)
        {
            Name = name;
            Lvl = lvl;
            Ban = ban;
        }

        public void Unban()
        {
            Ban = true;
        }
        public void Baned()
        {
            Ban = false;
        }
    }
}