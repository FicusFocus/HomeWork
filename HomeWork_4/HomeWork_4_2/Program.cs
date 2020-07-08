using System;

namespace HomeWork_4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] helthBar = new char[12];
            char[] manaBbar = new char[12];
            DrawBar(helthBar, 5, ConsoleColor.Red);
            Console.SetCursorPosition(0, 1);
            DrawBar(manaBbar, 7, ConsoleColor.Blue);

            Console.Read();        
        }

        static char[] DrawBar(char[] array, int value, ConsoleColor color, char symbol = '#')
        {
            array[0] = '[';
            array[array.Length - 1] = ']';

            for (int i = 1; i <= value; i++)
            {
                array[i] = '#';
            }
            for (int i = value + 1; i < array.Length - 1; i++)
            {
                array[i] = '_';
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
