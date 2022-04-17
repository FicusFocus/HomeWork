using System;

class Program
{
    static void Main(string[] args)
    {
        string userInputString = Console.ReadLine();
        string[] wsordsArrey = userInputString.Split();

        foreach (string word in wsordsArrey)
            Console.WriteLine(word);

        Console.ReadLine();
    }
}
