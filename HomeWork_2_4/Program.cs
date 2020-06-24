using System;

namespace HomeWork_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            char userChar;
            int charCount;

            Console.Write("введите символ: ");
            userChar = Convert.ToChar(Console.ReadLine());
            Console.Write("Введите имя: ");
            name = Console.ReadLine();

            charCount = name.Length + 2;

            for(int i = charCount;i > 0 ;i--)
            {
                Console.Write(userChar);
            }

            Console.WriteLine("\n" + userChar + name + userChar);

            for (int i = charCount; i > 0; i--)
            {
                Console.Write(userChar);
            }
        }
    }
}
