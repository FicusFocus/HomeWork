using System;
using System.Collections.Generic;

namespace HomeWork_5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            string userInput;
            int summ = 0;

            List<int> numbers = new List<int>();

            numbers.Add(7);
            numbers.Add(5);
            numbers.Add(6);
            numbers.Add(3);
            numbers.Add(8);
            numbers.Add(5);

            for (int i = 0; i < numbers.Count; i++)
            {
                summ += numbers[i];
            }

            while (isWork)
            {
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "addNumber":
                        break;
                }
            }
        }
    }
}
