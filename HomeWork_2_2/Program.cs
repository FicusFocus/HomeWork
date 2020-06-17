using System;

namespace HomeWork_2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string consoleComand, message, userName, userPassword, userAttemptLogg, userAttemptPW;
            bool consoleActive = true;
            bool logIn = false;

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
                                          "4) enterMessage - ввеcти скрытое послание\n" +
                                          "5) showAccountInfo - вывести логин и пароль\n" +
                                          "6) showMessage - вывести скрытое послание\n" +
                                          "7) changeSize - изменить размер\n" +
                                          "8) changeColor - изменить цвет конслои\n" +
                                          "9) clear - очистить консоль\n" +
                                          "10) esc - выход");
                        break;

                    case "changeAccount":
                        Console.Write("Придумайте новое имя пользователя: ");
                        userName = Console.ReadLine();
                        Console.Write("Придумайте новый пароль: ");
                        userPassword = Console.ReadLine();
                        break;

                    case "logIn":
                        for (int i = 4; i >= 0; i--)
                        {
                            Console.Write("Введите логин: ");
                            userAttemptLogg = Console.ReadLine();
                            Console.Write("Введите пароль: ");
                            userAttemptPW = Console.ReadLine();

                            if (userAttemptLogg == userName && userAttemptPW == userPassword)
                            {
                                Console.WriteLine("Вы успешно авторизовались");
                                logIn = true;

                                //TODO: желаете оставить секретное послание?
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
                        }
                        else
                        {
                            Console.WriteLine("И снова здравствуйте =)");
                        }
                        break;

                    case "enterMessage":
                        break;

                    case "showAccountInfo":
                        break;

                    case "showMessage":
                        break;

                    case "changeSize":
                        break;

                    case "changeColor":
                        break;

                    case "clear":
                        break;

                    case "esc":
                        consoleActive = false;
                        break;
                }

                Console.WriteLine("введите команду");
            }
        }
    }
}
