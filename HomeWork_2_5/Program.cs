using System;

namespace HomeWork_2_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "159753";
            string input;

            Console.WriteLine("Введите пароль");

            for (int tryCount = 3; tryCount > 0; tryCount --)
            {
                input = Console.ReadLine();

                if(input == password)
                {
                    Console.WriteLine("Пароль введен верно.");
                    break;
                }
                else
                {
                    Console.WriteLine("Повторите попытку.");
                }
            }
        }
    }
}