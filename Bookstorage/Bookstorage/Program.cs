using System.Collections.Generic;
using System;

//Создать хранилище книг.
//Каждая книга имеет название, автора и год выпуска (можно добавить еще параметры). 
//В хранилище можно 
//    добавить книгу, 
//    убрать книгу, 
//    показать все книги 
//    и показать книги по указанному параметру (по названию, по автору, по году выпуска).

public class Program
{

    static void Main(string[] args)
    {
        Storage _storage = new Storage();
        bool isWork = true;

        while (isWork)
        {
            Console.WriteLine("Выберите операцию: \n" +
                              "     1 - показать все книги\n" +
                              "     2 - и показать книги по указанному параметру (по названию, по автору, по году выпуска, по жанру)\n" +
                              "     3 - добавить книгу\n" +
                              "     4 - убрать книгу");

            switch (Console.ReadLine())
            {
                case "1":
                    _storage.ShowAllBookInfo();
                    break;

                case "2": //TODO: Вынеси в функцию ато хуйня какая-то

                    Console.WriteLine("1 - По автору. \n" +
                                      "2 - По названию.\n" +
                                      "3 - По году выпуска.\n" +
                                      "4 - По жанру.");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            string userInput = Console.ReadLine();

                            try
                            {
                                userInput.ToLower
                            }
                            catch (Exception)
                            {

                                throw;
                            }

                            break;

                        case "2":
                            _storage.FindBooks(Console.ReadLine());
                            break;

                        case "3":
                            break;

                        case "4":
                            break;
                    }

                    break;

                case "3":
                    break;

                case "4":
                    break;

                default:
                    Console.WriteLine("Данного пункта не существует, пожалуйста, повторите ввод.");
                    break;
            }
        }
    }
}