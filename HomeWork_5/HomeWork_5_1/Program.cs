using System;
using System.Collections.Generic;

namespace HomeWork_5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;

            Dictionary<string, int> numbering = new Dictionary<string ,int>();
            numbering.Add("one", 1);
            numbering.Add("two", 2);
            numbering.Add("three", 3);
            numbering.Add("four", 4);

            while (true)
            {
                Console.WriteLine("Введите слово ключ.");
                userInput = Console.ReadLine();

                if (numbering.ContainsKey(userInput))
                {
                Console.WriteLine(numbering[userInput]);
                }
                else
                {
                    Console.WriteLine("Данного слова не обнаружено");
                }
                Console.ReadLine();
                Console.Clear();
            }
        }

    }
}
