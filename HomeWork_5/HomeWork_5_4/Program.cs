using System;
using System.Collections.Generic;

namespace HomeWork_5_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullName;
            bool isWork = true;

            Dictionary<string, string> files = new Dictionary<string, string>();

            while(isWork)
            {
                Console.SetCursorPosition(0, 20);
                Console.Write("Введите help для вывода списка команд.");
                Console.SetCursorPosition(0, 0);
                Console.Write("Введите команду: ");

                switch (Console.ReadLine())
                {
                    case "help":
                        Console.Write("showAll - показать весь список сотрудников.\n" +
                                      "addFole - добавить файл\n" +
                                      "deleteFole - удалить файл\n" +
                                      "exit - выход.");
                        break;
                    case "addFile":
                        Console.Write("\nВедите имя и фамилию: ");
                        fullName = Console.ReadLine();
                        Console.Write("\nВведите должность: ");
                        string position = Console.ReadLine();

                        files.Add(fullName, position);
                        break;
                    case "showAll":
                        foreach (var file in files)
                        {
                            Console.WriteLine($"ФИО - {file.Key}, должность - {file.Value}.");
                        }
                        break;
                    case "deleteFile":
                        Console.Write("Введите ФИО сотрудника досъе которого желаете удалить: ");
                        fullName = Console.ReadLine();

                        foreach (var item in files.Keys)
                        {
                            if (item == fullName)
                            {
                                files.Remove(item);
                                Console.Write("Файл был удален.");
                            }
                        }
                        break;
                    case "exit":
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
