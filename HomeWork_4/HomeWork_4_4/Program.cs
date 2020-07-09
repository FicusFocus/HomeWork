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
            int directoinX = 0, directoinY = 0;
            char[,] map = ReadMap("map1", out plauerX, out plauerY, out goldCount);

            DrawMap(map);
            Console.CursorVisible = false;

            Console.SetCursorPosition(0, 17);
            Console.Write("Собрано монет - " + goldNum);

            while (game)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                ChangeDirection(ref directoinX, ref directoinY, key);
                if(map[plauerX + directoinX, plauerY + directoinY] != '#')
                {
                    Console.SetCursorPosition(plauerY, plauerX);
                    Console.Write(' ');

                    Move(ref plauerX, ref plauerY, directoinX, directoinY);

                    Console.SetCursorPosition(plauerY, plauerX);
                    Console.Write('$');
                }

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

        static void ChangeDirection(ref int DX, ref int DY, ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    DX = -1; DY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    DX = 1; DY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    DX = 0; DY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    DX = 0; DY = 1;
                    break;
            }
        }

        static void Move(ref int X, ref int Y, int DX, int DY)
        {
            X += DX;
            Y += DY;
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
