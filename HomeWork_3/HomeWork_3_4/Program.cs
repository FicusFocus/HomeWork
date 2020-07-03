using System;

namespace HomeWork_3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[1];
            int summ = 0;
            string userInput;
            bool isWork = true;

            while (isWork)
            {
                Console.Write("Введите команду.\n" +
                              "1) summ - вывести сумму введенных чиселю\n" +
                              "2) enter - ввести число\n" +
                              "3) exit - выйти из программы.\n");
                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "enter":
                        int[] tempNumbers = new int[numbers.Length + 1];
                        if (numbers[0] == 0)
                        {
                            Console.Write("Введите первое число: ");
                            numbers[0] = Convert.ToInt32(Console.ReadLine());
                        }
                        else
                        {
                            for (int i = 0; i < numbers.Length; i++)
                            {
                                tempNumbers[i] = numbers[i];
                            }
                            Console.Write("Введите число: ");
                            tempNumbers[tempNumbers.Length - 1] = Convert.ToInt32(Console.ReadLine());
                            numbers = tempNumbers;
                        }
                        break;
                    case "summ":
                        for(int i = 0; i < numbers.Length; i++)
                        {
                            Console.Write(numbers[i] + " + ");
                            summ += numbers[i];
                        }
                        Console.WriteLine(" = " + summ);
                        Console.ReadKey();
                        break;
                    case "exit":
                        isWork = false;
                        break;
                }
                Console.Clear();
            }
        }
    }
}
