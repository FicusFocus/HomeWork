using System;

namespace HomeWork_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] helthBar = new string[12];
            string[] manaBbar = new string[12];
            Bar(helthBar, 5, ConsoleColor.Red);
            Console.SetCursorPosition(0, 1);
            Bar(manaBbar, 7, ConsoleColor.Blue);

            Console.Read();        
        }

        static string[] Bar(string[] array, int value, ConsoleColor color)
        {
            array[0] = "[";
            array[array.Length - 1] = "]";

            for (int i = 1; i <= value; i++)
            {
                array[i] = "#";
            }
            for (int i = value + 1; i < array.Length - 1; i++)
            {
                array[i] = "_";
            }

            Console.Write(array[0]);
            ConsoleColor defaultColor = Console.BackgroundColor;
            Console.BackgroundColor = color;

            for (int i = 1; i < array.Length - 1; i++)
            {
                Console.Write(array[i]);
            }
            Console.BackgroundColor = defaultColor;
            Console.Write(array[array.Length - 1]);

            return array;
        }
    }
}
