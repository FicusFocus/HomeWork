using System;

namespace Home_Work
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPictures = 52;
            int abreast = 3;
            float numOfAbreast = 52 / 3;
            float picturesLeft = 52 % 3;
            Console.WriteLine("Картинок в ряд - " + numOfAbreast);
            Console.WriteLine("Картинок в остатке - " + picturesLeft);
        }
    }
}
