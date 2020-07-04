using System;

namespace HomeWork_4_3
{
    class Program
    {
        static void Main(string[] args)
        {
            GetValue();
        }

        static int GetValue()
        {
            int value;
            string str;


            while (true)
            {
                Console.Write("Введите число: ");
                str = Console.ReadLine();
                bool result = int.TryParse(str, out value);

                if (result == true)
                {
                    Console.Clear();
                    Console.WriteLine($"Введенное число - {value}");
                    return value;
                }
                else
                {
                    Console.Write("\nНекорректно введено число, аовторите попытку ");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
