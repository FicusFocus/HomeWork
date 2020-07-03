using System;

namespace HomeWork_2_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string userMassage;
            int outputCount;

            Console.Write("Введите сообщение: ");
            userMassage = Console.ReadLine();
            Console.Write("\nСколько раз вывести сообщение: ");
            outputCount = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < outputCount; i++)
            {
                Console.WriteLine((i + 1) + ") " + userMassage);
            }
        }
    }
}
