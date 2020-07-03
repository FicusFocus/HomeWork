using System;

namespace HomeWork_2_8
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Введите exit для выхода");

                switch (Console.ReadLine())
                {
                    case "exit":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("все еще работает");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
    }
}
