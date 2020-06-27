using System;
using System.ComponentModel.DataAnnotations;

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

            if(arrey[0] > arrey[1])
            {
                Console.WriteLine(arrey[0]);
            }
            for(int i = 1; i < arrey.Length - 1; i++)
            {
                if(arrey[i] > arrey[i + 1] && arrey[i] > arrey[i - 1])
                {
                    Console.WriteLine(arrey[i]);
                }
            }
            if (arrey[arrey.Length - 1] > arrey[arrey.Length - 2])
            {
                Console.WriteLine(arrey[arrey.Length - 1]);
            }
        }
    }
}
