using System;

namespace HomeWork_4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Shuffle(array);
        }

        static void Shuffle(int[] array)
        {
            Random rnd = new Random();
            int j = rnd.Next(0, array.Length - 1);

            for(int i = 0; i < array.Length; i++)
            {
                
            }
        }
    }
}