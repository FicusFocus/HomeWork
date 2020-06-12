using System;

namespace Home_Work
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPictures = 52;
            int abreast = 3;
            float numOfAbreast = numOfPictures / abreast;
            float picturesLeft = numOfPictures % abreast;
            Console.WriteLine("Картинок в ряд - " + numOfAbreast);
            Console.WriteLine("Картинок в остатке - " + picturesLeft);
        }
    }
    }
}
