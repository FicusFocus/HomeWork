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
            int buyAmount = 0, purchaseNumber;
            Random rnd = new Random();

            Queue<string> buyer = new Queue<string>();

            buyer.Enqueue("buyer №1");
            buyer.Enqueue("buyer №2");
            buyer.Enqueue("buyer №3");
            buyer.Enqueue("buyer №4");
            buyer.Enqueue("buyer №5");
            buyer.Enqueue("buyer №6");

            purchaseNumber = rnd.Next(1, 6);

            for (int i = 0; i < purchaseNumber; i++)
            {
                buyAmount = rnd.Next(1, 500);
                money += buyAmount;

                Console.WriteLine(buyAmount);
                Console.WriteLine(money);
            }
        }
    }
}
