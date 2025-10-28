using System;
using System.Collections.Generic;
using System.Linq; // Required for Average()

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public double Price { get; set; }

    public Book(string title, string author, double price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

}
class Program
{
    static void Main()
    {
        List<Book> books = new List<Book>();

        books.Add(new Book("C# Fundamentals", "John Smith", 450.50));
        books.Add(new Book("ASP.NET Core", "Jane Doe", 550.75));
        books.Add(new Book("LINQ in Action", "Robert Brown", 499.99));

        for (int i = 0; i < books.Count; i++)
        {
            Console.WriteLine(books[i].Title+ books[i].Author + books[i].Price);

        }
        double maxPrice = 0;
        Book maxPriceBook = null;
        for (int i = 0; i < books.Count; i++)
        {
            if(maxPrice < books[i].Price)
            {
                maxPrice = books[i].Price;
                maxPriceBook = books[i];
            }

        }
        Console.WriteLine(maxPriceBook.Title + maxPriceBook.Author+ maxPriceBook.Price);
    }
}
