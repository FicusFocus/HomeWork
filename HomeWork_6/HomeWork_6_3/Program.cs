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
                        Console.Write("Ввыедите имя нового игрока: ");
                        string name = Console.ReadLine();
                        playerList.AddPlayer(name);
                        break;
                    case"2":
                        Console.Write("Введите номер игрока которого желаете забанить: ");
                        int number = Convert.ToInt32(Console.ReadLine()) - 1;
                        bool isCorrect;
                        isCorrect = playerList.PlayerFinder(number);
                        if (isCorrect)
                        {
                            playerList.ChangeFlagFalse(number);
                        }
                        break;
                    case"3":
                        Console.Write("Введите номер игрока которого желаете разбанить: ");
                        number = Convert.ToInt32(Console.ReadLine()) - 1;
                        isCorrect = playerList.PlayerFinder(number);
                        if (isCorrect)
                        {
                            playerList.ChangeFlagTrue(number);
                        }
                        break;
                    case "4":
                        Console.Write("Введите номер игрока которого желаете найти: ");
                        number = Convert.ToInt32(Console.ReadLine()) - 1;
                        isCorrect = playerList.PlayerFinder(number);
                        if (isCorrect)
                        {
                            playerList.PlayerInfo(number);
                        }
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

        public void PlayerInfo(int number)
        {
            string flag;
            if (_players[number].Flag == true)
                flag = "свободен";
            else
                flag = "забанен";
            Console.WriteLine($"{ _players[number].Name}, {_players[number].Lvl} - {flag}");
        }
        public void AddPlayer(string name, int lvl = 1, bool flag = true)
        {
            _players.Add(new Player(name));
            Console.WriteLine($"Вы добавили игрока - {name}. Старотовый уровень - {1}");
        }
        public void Remove(int number)
        {
            _players.Remove(_players[number]);
        }
        public bool PlayerFinder(int number)
        {
            if (number > _players.Count)
            {
                Console.WriteLine("Игрока с таким порядковым номером не существует.");
                return false;
            }
            else 
            for (int i = 0; i < _players.Count; i++)
            {
                if (number == i)
                {
                    Console.WriteLine(_players[i].Name);
                }
            }
            return true;
        }
        public void ChangeFlagTrue(int number)
        {
            _players[number].ChangeFlagTrue(_players, number);
        }
        public void ChangeFlagFalse(int number)
        {
            _players[number].ChangeFlagFalse(_players, number);
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Lvl { get; private set; }
        public bool Flag { get; private set; }

        public Player(string name, int lvl = 1, bool flag = true)
        {
            Name = name;
            Lvl = lvl;
            Flag = flag;
        }

        public void ChangeFlagTrue(List<Player> players, int number)
        {
            players[number].Flag = true;
        }
        public void ChangeFlagFalse(List<Player> players, int number)
        {
            players[number].Flag = false;
        }
    }
}
