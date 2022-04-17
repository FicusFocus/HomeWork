using System;

public class Book
{
    public string Name { get; }
    public int YearOfIssue { get; }
    public Autors Autor { get; }
    public Genre Genre { get; }

    public Book(string name, Autors autor, int yearOfIssue, Genre genre)
    {
        Name = name;
        Autor = autor;
        YearOfIssue = yearOfIssue;
        Genre = genre;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"это книга - {Name} в жантре {Genre}, автор - {Autor}, год выпуска - {YearOfIssue}.");
    }
}
