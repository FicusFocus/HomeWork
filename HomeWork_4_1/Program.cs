using System;

namespace HomeWork_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            string[] fullName = new string[0];
            string[] position = new string[0];

            while (isWork)
            {
                Console.WriteLine("Выберите действие: \n" +
                                  "1) addFile - добавить досье.\n" +
                                  "2) showAll - показать список.\n" +
                                  "3) deleteFile - удолить досье.\n" +
                                  "4) findFile - найти досье по фамилии.\n" +
                                  "5) exit - закрыть программу.");

                switch (Console.ReadLine())
                {
                    case "addFile":
                        Console.Write("Введите фамилию и имя: ");
                        fullName = AddFile(fullName);
                        Console.WriteLine("\nВведите должность: ");
                        position = AddFile(position);
                        break;
                    case "showAll":
                        for (int i = 0; i < fullName.Length; i++)
                        {
                            Console.WriteLine((i + 1) + ") " + fullName[i] + " - " + position[i]);
                        }
                        break;
                    case "findFile":
                        Console.Write("Введите фамилию и имя человека которого хотите найти: ");
                        string name;
                        name = Console.ReadLine();
                        for (int i = 0; i < fullName.Length; i++)
                        {
                            if (name == fullName[i])
                            {
                                Console.Write(fullName[i] + " - " + position[i]);
                            }
                        }
                        break;
                    case "deleteFile":
                        break;
                    case "exit":
                        isWork = false;
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        static string[] AddFile(string[] array)
        {
            string[] tempArrey = new string[array.Length + 1];

            for(int i = 0; i < array.Length; i++)
            {
                tempArrey[i] = array[i];
            }
            tempArrey[tempArrey.Length - 1] = Console.ReadLine();
            array = tempArrey;
            return array;
        }
    }
}
