using System;
using System.Collections;
using System.Collections.Generic;

namespace HomeWork_5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int money = 0;
            int purchaseAmount = 0;
            int buyAmount;
            int purchaseNumber;

            Random rnd = new Random();

            Queue<string> buyer = new Queue<string>();

            buyer.Enqueue("buyer №1");
            buyer.Enqueue("buyer №2");
            buyer.Enqueue("buyer №3");
            buyer.Enqueue("buyer №4");
            buyer.Enqueue("buyer №5");
            buyer.Enqueue("buyer №6");

            foreach (var nextBuyer in buyer)
            {
                purchaseNumber = rnd.Next(1, 6);

                for (int i = 0; i < purchaseNumber; i++)
                {
                    buyAmount = rnd.Next(1, 500);
                    purchaseAmount += buyAmount;

                    Console.WriteLine(buyAmount + " - сумма товара");
                    Console.WriteLine(purchaseAmount + " - общая сумма покупки");
                }

                money += purchaseAmount;
                Console.SetCursorPosition(0, 16);
                Console.WriteLine(money + " - счет продавца");
                Console.Read();
                Console.Clear();
            }

            Console.WriteLine($"В кассу поступило - {money} рублей.");
        }
    }
}
