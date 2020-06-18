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

            while (iterationCount-- > 0)
            {
                Console.Write(num + ", ");
                num += 7;
            }
        }
    }
}
