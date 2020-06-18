using System;

namespace HomeWork_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int iterationCount, num = 7;

            Console.Write("Введите количество итераций: ");
            iterationCount = Convert.ToInt32(Console.ReadLine());

            for (; iterationCount > 0; iterationCount--)
            {
                Console.Write(num + ", ");
                num += 7;
            }
        }
    }
}
