using System;

namespace HomeWork_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[,] array = new int[3, 3];
            int summ = 0;            

            for(int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(1, 10);
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
            int mult = array[0, 0];

            for (int i = 1; i < array.GetLength(0); i++ )
            {
                mult *= array[i,0];
            }
            for (int i = 0; i < array.GetLength(1); i++)
            {
                summ += array[1, i]; 
            }
            Console.WriteLine("сумма - " + summ);
            Console.WriteLine("Произведение - " + mult);
        }
    }
}
