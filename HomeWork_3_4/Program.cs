using System;

namespace HomeWork_3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[1];
            int[] tempNumber = new int[1];
            int summ = int.MinValue;
            string userInput;
            bool isWork = true;

            while (isWork)
            {
                Console.Write("Введите команду.\n" +
                              "1) summ - вывести сумму введенных чиселю\n" +
                              "2) enter - ввести числа\n" +
                              "3) exit - выйти из программы.\n");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "enter":

                        break;
                    case "summ":
                        break;
                    case "exit":
                        isWork = false;
                        break;
                }
                    
            }
            
        }
    }
}
