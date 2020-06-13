using System;

namespace HomeWork4
{
    class Program
    {
        static void Main(string[] args)
        {
            int goldCount;
            int diamondCount;
            int diamondPrice = 5;

            Console.Write("Введите количество золота: ");
            goldCount = Convert.ToInt32(Console.ReadLine());
            Console.Write("Какое кол-во кристалов приобретете? ");
            diamondCount = Convert.ToInt32(Console.ReadLine());

            goldCount -= diamondCount * diamondPrice;

            Console.WriteLine($"Количество кристалов в инвентаре - {diamondCount}. Количество золота в инвентаре - {goldCount}");
        }
    }
}
