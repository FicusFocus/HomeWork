using System;

namespace HomeWork_3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[10, 10];
            int maxCount = int.MinValue;

            Random rnd = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(1, 10);
                    Console.Write(array[i, j] + " ");
                    if (maxCount < array[i, j])
                    {
                        maxCount = array[i, j];
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("максимальное значение = " + maxCount + "\n");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == maxCount)
                    {
                        array[i, j] = 0;
                    }
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
