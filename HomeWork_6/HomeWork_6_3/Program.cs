using System;
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
                        playerList.Add(name);
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
                Console.WriteLine("Игрока с таким порядковым номером не существует.");
            else
                _players[number].ShowInfo();
        }
        public void Add(string name, int lvl = 1, bool flag = true)
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
        public void Find(int number)
        {
            if (number > _players.Count || number < 0)
                Console.WriteLine("Игрока с таким порядковым номером не существует.");
            else
                Console.WriteLine(_players[number].Name);
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
                _players[number].Ban();
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Lvl { get; private set; }
        public bool Baned { get; private set; }

        public Player(string name, int lvl = 1, bool ban = true)
        {
            Name = name;
            Lvl = lvl;
            Baned = ban;
        }
        public void ShowInfo()
        {
            if(Baned == false)
                Console.WriteLine($"{Name}, {Lvl} уровень - забанен");
            else
                Console.WriteLine($"{Name}, {Lvl} уровень - свободен");
        }
        public void Unban()
        {
            Baned = true;
        }
        public void Ban()
        {
            Baned = false;
        }
    }
}