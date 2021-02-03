using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HomeWork_6_8
{
    class Map
    {
        private char[,] _map;
        public int PositionX;
        public int PositionY;

        public Map(string mapName)
        {
            ReadMap(mapName);
            DrowMap();
        }

        private void ReadMap(string mapName)
        {
            string[] newFile = File.ReadAllLines($"Maps/{mapName}.txt");
            _map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    _map[i, j] = newFile[i][j];
                    if(_map[i, j] == '@')
                    {
                        PositionX = i;
                        PositionY = j;
                    }

                }
            }
        }

        private void DrowMap()
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    Console.Write(_map[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
