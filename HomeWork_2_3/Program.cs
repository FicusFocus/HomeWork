using System;

namespace HomeWork_2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = 7;

            for (int iterationCount = 14; iterationCount > 0; iterationCount --)
            {
                Console.Write(num + "; ");
                num += 7;
            }
        }
    }
}
