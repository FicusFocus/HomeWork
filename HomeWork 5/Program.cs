using System;

namespace HomeWork_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount;
            int waitingTimeHour;
            int waitingTimeMin;
            int treatmentTime = 10;

            Console.Write("Введите количество людей в очереди: ");
            peopleCount = Convert.ToInt32(Console.ReadLine());

            waitingTimeHour = peopleCount * treatmentTime / 60;
            waitingTimeMin = peopleCount * treatmentTime % 60;

            Console.WriteLine($"Время ожидания составит - {waitingTimeHour} часов, {waitingTimeMin} минут");
        }
    }
}
