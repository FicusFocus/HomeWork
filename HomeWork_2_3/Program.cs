using System;

namespace HomeWork_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterationCount;

            Console.Write("Введите количество итераций: ");
            iterationCount = Convert.ToInt32(Console.ReadLine());

            for (int num = 7; iterationCount > 0; num += 7)
            {
                Console.Write(num + ", ");
                iterationCount--;
            }

            //while (iterationCount-- > 0)
            //{
            //    Console.Write(num + ", ");
            //    num += 7;
            //}
        }
    }
}
