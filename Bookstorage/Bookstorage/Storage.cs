using System;
using System.Collections.Generic;

public class Storage
{
    private List<Book> _books;

    public void TryAddBook(Book newBook)
    {
        foreach (Book book in _books)
        {
            string bookName = book.Name.ToLower();
            string newBookName = newBook.Name.ToLower();

            if (bookName == newBookName)
            {
                Console.WriteLine("Такая книга уже есть.");
                return;
            }
        }

        _books.Add(newBook);
    }

    public void RemoveBook(Book bookToRemove)
    {
        foreach (Book book in _books)
        {
            if (bookToRemove == book)
            {
                _books.Remove(bookToRemove);
                return;
            }
        }

        Console.WriteLine("Данной книги несуществует");
    }

    public void ShowAllBookInfo()
    {
        for (int i = 1; i < _books.Count; i++)
        {
            Console.Write($"{i}) ");
            _books[i].ShowInfo();
        }
    }

    public void FindBooks(int yearOfIssue)
    {
        foreach (Book book in _books)
        {
            if (book.YearOfIssue == yearOfIssue)
                book.ShowInfo();
        }
    }

    public void FindBooks(string name)
    {
        foreach (Book book in _books)
        {
            if (book.Name.ToLower() == name.ToLower())
                book.ShowInfo();
        }
    }

    public void FindBooks(Autors autor)
    {
        foreach (Book book in _books)
        {
            if (book.Autor == autor)
                book.ShowInfo();
        }
    }

    public void FindBooks(Genre genre)
    {
        foreach (Book book in _books)
        {
            if (book.Genre == genre)
                book.ShowInfo();
        }
    }
}