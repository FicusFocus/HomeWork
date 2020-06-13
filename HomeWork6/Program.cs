using System;

namespace HomeWork6
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string secondName;
            string profession;
            int age;

            Console.Write("Сообщите Ваше имя: ");
            name = Console.ReadLine();
            Console.Write("Сообщите Фамилию: ");
            secondName = Console.ReadLine();
            Console.Write("Сколько Вам лет: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ваша професия: ");
            profession = Console.ReadLine();

            Console.WriteLine($"Вас зовут {secondName} {name}, Вам {age} лет, по профессии Вы {profession}.");
        }
    }
}
