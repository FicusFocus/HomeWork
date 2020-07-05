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
            int DX = 0, DY = 0;
            char[,] map = ReadMap("map1");

            DrawMap(out plauerX, out plauerY, map, out goldCount);

            Console.CursorVisible = false;

            while (game)
            {
                PlauerMove(map, ref plauerX, ref plauerY, ref DX, ref DY);
                if (map[plauerX, plauerY] == '%')
                {
                    goldNum+= 1;
                    map[plauerX, plauerY] = ' ';
                    Console.SetCursorPosition(0, 20);
                    Console.Write("Собрано - " + goldNum);
                }
            }
        }

        static void PlauerMove(char[,] map, ref int plauerX, ref int plauerY, ref int DX, ref int DY)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

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
                if (map[plauerX + DX, plauerY + DY] != '#')
                {
                    Console.SetCursorPosition(plauerY, plauerX);
                    Console.Write(' ');

                    plauerX += DX;
                    plauerY += DY;

                    Console.SetCursorPosition(plauerY, plauerX);
                    Console.Write('$');
                }
            }
        }

        static void DrawMap(out int plauerX, out int plauerY, char[,] map, out int goldCount)
        {
            plauerX = 0;
            plauerY = 0;
            goldCount = 0;

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);

                    if(map[plauerX, plauerY] == '%')
                    {
                        goldCount++;
                    }
                    if(map[i, j] == '$')
                    {
                        plauerX = i;
                        plauerY = j;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(plauerX + " - X, Y - " + plauerY);
        }

        static char[,] ReadMap(string mapName)
        {
            string[] newFile = File.ReadAllLines($"Maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for(int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];
                }
            }
            return map;
        }
    }
}
