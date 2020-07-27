using System;
using System.Collections.Generic;
using System.Security.Authentication;

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

            for (int i = 0; i < numbers.Count; i++)
            {
                summ += numbers[i];
            }

            while (isWork)
            {
                Console.Write("Введите команду: ");
                userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case "addNumbers":
                        int value;
                        bool stopInput = true;

                        Console.WriteLine("P.S <stopTyping> для прекращения ввода чисел.");

                        while (stopInput)
                        {
                            Console.Write("\nВведите число: ");
                            userInput = Console.ReadLine();
                            bool result = int.TryParse(userInput, out value);

                            if (result == true)
                            {
                                numbers.Add(value);
                            }
                            else if(userInput == "stopTyping")
                            {
                                stopInput = false;
                            }
                            else
                            {
                                Console.Write("\nНекорректно введено число, повторите попытку ");
                                Console.ReadLine();
                            }
                        }
                            break;
                    case "summ":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            summ += numbers[i];
                        }
                        Console.WriteLine("сумма всех введеных вами чисел: " + summ);
                        break;
                    case "exit":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Некорректная команда, повторите попытку.");
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
