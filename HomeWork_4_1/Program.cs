using System;

namespace HomeWork_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            bool isWork = true;
            string[] fullName = new string[1];
            string[] position = new string[1];

            while (isWork)
            {
                Console.WriteLine("Выберите действие: ");

                switch 
                {
                    case 1:
                        break;
                }
            }
        }

        static void AddFile(string[] array)
        {
            string[] tempArrey = new string[array.Length + 1];

            for(int i = 0; i < array.Length; i++)
            {
                tempArrey[i] = array[i];
            }
            tempArrey[tempArrey.Length - 1] = Console.ReadLine();
            array = tempArrey;
        }
    }
}
