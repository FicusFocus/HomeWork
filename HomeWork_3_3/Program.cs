﻿using System;

namespace HomeWork_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrey = new int[30];
            Random rnd = new Random();

            for(int i = 0; i < arrey.Length; i++)
            {
                arrey[i] = rnd.Next(0, 100);
                Console.Write(arrey[i] + " ");
            }
            Console.WriteLine();

            for(int i = 1; i < arrey.Length - 1; i++)
            {
                if(arrey[i] > arrey[i + 1] && arrey[i] > arrey[i - 1])
                {
                    Console.WriteLine(arrey[i]);
                }
            }

        }
    }
}
