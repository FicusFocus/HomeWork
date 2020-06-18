using System;

namespace HomeWork_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string consoleComand, message = "", userName, userPassword, userAttemptLogg, userAttemptPW, consoleColor;
            bool consoleActive = true;
            bool logIn = false, setMessege = false;

            Console.WriteLine("для пользования консолью необходимо зарегистрироваться.");
            Console.Write("Придумайте имя пользователя: ");
            userName = Console.ReadLine();
            Console.Write("Придумайте Ваш пароль: ");
            userPassword = Console.ReadLine();

            Console.WriteLine("Для отображения списка команд введите help");

            while (consoleActive == true)
            {
                consoleComand = Console.ReadLine();

                switch (consoleComand)
                {
                    case "help":
                        Console.WriteLine("1) changeAccount - Изменить данные учетной записи\n" +
                                          "2) logIn - войти в учетную запись\n" +
                                          "3) logOut - выйти из учетной записи\n" +
                                          "4) setMessage - ввеcти скрытое послание\n" +
                                          "5) showAccountInfo - вывести логин и пароль\n" +
                                          "6) showMessage - вывести скрытое послание\n" +
                                          "7) changeColor - изменить цвет конслои\n" +
                                          "8) clear - очистить консоль\n" +
                                          "9) esc - выход");
                        break;
                    case "changeAccount":
                        Console.Write("Придумайте новое имя пользователя: ");
                        userName = Console.ReadLine();
                        Console.Write("Придумайте новый пароль: ");
                        userPassword = Console.ReadLine();
                        break;
                    case "logIn":
                        for (int attemptCount = 4; attemptCount >= 0; attemptCount--)
                        {
                            Console.Write("Введите логин: ");
                            userAttemptLogg = Console.ReadLine();
                            Console.Write("Введите пароль: ");
                            userAttemptPW = Console.ReadLine();

                            if (userAttemptLogg == userName && userAttemptPW == userPassword)
                            {
                                Console.WriteLine("Вы успешно авторизовались!");
                                logIn = true;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Введено неверное имя пользователя или пароль. попробуйте еще раз.");
                            }
                        }
                        break;
                    case "logOut":
                        Console.Write("Вы уверены что хотите дизафторизоваться? y - да, n - нет.");
                        char choice = Convert.ToChar(Console.ReadLine());
                        if(choice == 'y')
                        {
                            logIn = false;
                            Console.WriteLine("Пока, пока!");
                        }
                        else if (choice == 'n')
                        {
                            Console.WriteLine("И снова здравствуйте =)");
                        }
                        else
                        {
                            Console.WriteLine("Неверный символ.");
                        }
                        break;
                    case "setMessage":
                        Console.Write("Введите сообщение: ");
                        message = Console.ReadLine();
                        setMessege = true;
                        break;
                    case "showAccountInfo":
                        if (logIn == true)
                        {
                            Console.WriteLine($"Имя пользователя - {userName}, Пароль - {userPassword}.");
                        }
                        else
                        {
                            Console.WriteLine("Для начала необходимо авторизоваться");
                        }
                        break;
                    case "showMessage":
                        if (setMessege == true)
                        {
                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine("для начала необходимо ввести сообщение.");
                        }
                        break;
                    case "changeColor":
                        Console.WriteLine("выберете цвет консоли:");
                        Console.WriteLine("1)Blue. 2)Red. 3)Green. 4)White. 5)Black");
                        consoleColor = Console.ReadLine();

                        switch (consoleColor)
                        {
                            case "Blue":
                                Console.BackgroundColor = ConsoleColor.Blue;
                                break;
                            case "Red":
                                Console.BackgroundColor = ConsoleColor.Red;
                                break;
                            case "Green":
                                Console.BackgroundColor = ConsoleColor.Green;
                                break;
                            case "White":
                                Console.BackgroundColor = ConsoleColor.White;
                                break;
                            case "Black":
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                            default:
                                Console.WriteLine("Такого цвета нет.");
                                break;
                        }
                        break;
                    case "clear":
                        Console.Clear();
                        Console.WriteLine("Для отображения списка команд введите help");
                        break;
                    case "esc":
                        consoleActive = false;
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда.");
                        break;
                }

                Console.WriteLine("введите команду");
            }
        }
    }
}
