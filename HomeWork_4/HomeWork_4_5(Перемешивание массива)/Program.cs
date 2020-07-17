using System;

namespace HomeWork_4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Shuffle(array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ,");
            }
        }

        static void Shuffle(int[] array)
        {
            Random rnd = new Random();

            for (int i = array.Length - 1; i >= 1; i--)
            {
                int randomPosition = rnd.Next(i + 1);

                int newPosition = array[randomPosition];
                array[randomPosition] = array[i];
                array[i] = newPosition;
            }
        }
    }
}