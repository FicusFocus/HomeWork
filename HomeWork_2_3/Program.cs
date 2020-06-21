using System;

namespace HomeWork_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 7, num2 = 7;
            int iterationCount = 14;

            for (int i = 0; i < iterationCount; i++)
            {
                Console.Write(num1 + "; ");
                num1 += num2;
            }
        }

    }
}
