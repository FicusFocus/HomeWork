using System;
using System.IO;
using System.Reflection.Metadata;

namespace HomeWork_4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            bool game = true;
            int goldNum = 0, goldCount;
            int plauerX, plauerY;
            char[,] map = ReadMap("map1", out plauerX, out plauerY, out goldCount);

            DrawMap(map);
            Console.CursorVisible = false;

            Console.SetCursorPosition(0, 17);
            Console.Write("Собрано монет - " + goldNum);

            while (game)
            {
                Move(map, ref plauerX, ref plauerY, '$');
                if (map[plauerX, plauerY] == '%')
                {
                    goldNum+= 1;
                    map[plauerX, plauerY] = ' ';
                    Console.SetCursorPosition(0, 17);
                    Console.Write("Собрано монет - " + goldNum);
                }

                if(goldCount == goldNum)
                {
                    Console.WriteLine("Вы собрали все золото!!");
                    game = false;
                }
            }
        }

        static void Move(char[,] map, ref int X, ref int Y, char symbol)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            Console.SetCursorPosition(Y, X);
            Console.Write(' ');
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (map[X - 1, Y] != '#')
                    {
                        X--;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (map[X + 1, Y] != '#')
                    {
                        X++;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (map[X, Y - 1] != '#')
                    {
                        Y--;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (map[X, Y + 1] != '#')
                    {
                        Y++;
                    }
                    break;
            }

            Console.SetCursorPosition(Y, X);
            Console.Write(symbol);
        }

        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static char[,] ReadMap(string mapName, out int plauerX, out int plauerY, out int goldCount)
        {
            plauerX = 0;
            plauerY = 0;
            goldCount = 0;

            string[] newFile = File.ReadAllLines($"Maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for(int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];

                    if (map[i, j] == '$')
                    {
                        plauerX = i;
                        plauerY = j;
                    }

                    if(map[i, j] == '%')
                    {
                        goldCount++;
                    }
                }
            }
            return map;
        }
    }
}
