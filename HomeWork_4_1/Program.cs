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
                        Console.Write("Введите название файла который желаете удалить (Фамилию и имя): ");
                        fullName = DeleteFile(fullName);
                        Console.WriteLine("файл удален.");
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
            string[] tempArray = new string[array.Length + 1];

            for(int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }
            tempArray[tempArray.Length - 1] = Console.ReadLine();
            array = tempArray;

            return array;
        }

        static string[] DeleteFile(string[] array)
        {
            string[] tempArray = new string[array.Length - 1];
            string fileName;
            int fileIndex = 0;

            fileName = (Console.ReadLine());

            if (array.Length == 0)
            {
                return array;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == fileName)
                {
                    fileIndex = i;
                }
            }

            if (array.Length <= fileIndex)
            {
                return array;
            }

            for (int i = 0; i < fileIndex; i++)
            {
                tempArray[i] = array[i];
            }
            for (int i = fileIndex + 1; i < array.Length; i++)
            {
                tempArray[i - 1] = array[i];
            }
            array = tempArray;

            return array;
        }
    }
}