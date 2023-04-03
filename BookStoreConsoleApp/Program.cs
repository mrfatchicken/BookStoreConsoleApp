using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Ninject;
using BookStore.Infrastructure.Entities;
using BookStore.Infrastructure.Repository;
using BookStore.Infrastructure.Services;

namespace BookStore.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to Book Store");

      IKernel kernel = new StandardKernel();
      kernel.Load(Assembly.GetExecutingAssembly());



      while (true)
      {
        Console.WriteLine("============================================");
        Console.WriteLine("1 - View all books");
        Console.WriteLine("2 - Add a book");
        Console.WriteLine("3 - Update a book");
        Console.WriteLine("4 - Delete a book");
        Console.WriteLine("5 - Exit");

        Console.Write("Enter your choice: ");
        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
        {
          Console.WriteLine("Invalid choice");
          continue;
        }

        switch (choice)
        {
          case 1:
            ViewAllBooks(kernel.Get<IBookService>());
            break;
          case 2:
            AddBook(kernel.Get<IBookService>());
            break;
          case 3:
            UpdateBook(kernel.Get<IBookService>());
            break;
          case 4:
            DeleteBook(kernel.Get<IBookService>());
            break;
          case 5:
            Console.WriteLine("Goodbye!");
            return;
        }
      }
    }

    static void ViewAllBooks(IBookService bookService)
    {
      var books = bookService.GetAllBooks();

      if (books.Count == 0)
      {
        Console.WriteLine("No books available");
        return;
      }

      Console.WriteLine("List of available books:");
      foreach (var book in books)
      {
        Console.WriteLine($"{book.Id} - {book.Title} by {book.Author} ({(book.IsAvailable ? "available" : "not available")})");
      }
    }

    static void AddBook(IBookService bookService)
    {
      var book = new Book();

      Console.Write("Enter title: ");
      book.Title = Console.ReadLine().Trim();

      Console.Write("Enter author: ");
      book.Author = Console.ReadLine().Trim();

      Console.Write("Enter genre: ");
      book.Genre = Console.ReadLine().Trim();

      Console.Write("Enter published year: ");
      int year;
      if (!int.TryParse(Console.ReadLine(), out year))
      {
        Console.WriteLine("Invalid input");
        return;
      }
      book.PublishedYear = year;

      Console.Write("Is available? (y/n): ");
      var input = Console.ReadLine().Trim();
      if (input.Length > 0 && input[0] == 'y')
      {
        book.IsAvailable = true;
      }

      bookService.AddBook(book);

      Console.WriteLine("Book added");
    }

    static void UpdateBook(IBookService bookService)
    {
      Console.Write("Enter book Id: ");
      var idString = Console.ReadLine().Trim();

      Guid id;
      if (!Guid.TryParse(idString, out id))
      {
        Console.WriteLine("Invalid input");
        return;
      }

      var book = bookService.GetBookById(id);

      if (book == null)
      {
        Console.WriteLine("Book not found");
        return;
      }

      Console.WriteLine($"Updating book - {book.Title} by {book.Author}\n");

      Console.Write("Enter new title (empty to keep the same): ");
      var title = Console.ReadLine().Trim();
      if (title.Length > 0)
      {
        book.Title = title;
      }

      Console.Write("Enter new author (empty to keep the same): ");
      var author = Console.ReadLine().Trim();
      if (author.Length > 0)
      {
        book.Author = author;
      }

      Console.Write("Enter new genre (empty to keep the same): ");
      var genre = Console.ReadLine().Trim();
      if (genre.Length > 0)
      {
        book.Genre = genre;
      }

      Console.Write("Enter new published year (empty to keep the same): ");
      var yearString = Console.ReadLine().Trim();
      if (yearString.Length > 0)
      {
        int year;
        if (int.TryParse(yearString, out year))
        {
          book.PublishedYear = year;
        }
      }

      Console.Write("Is available? (y/n): ");
      var input = Console.ReadLine().Trim();
      if (input.Length > 0 && input[0] == 'y')
      {
        book.IsAvailable = true;
      }
      else
      {
        book.IsAvailable = false;
      }

      bookService.UpdateBook(book);
      Console.WriteLine("Book updated");
    }

    static void DeleteBook(IBookService bookService)
    {
      Console.Write("Enter book Id: ");
      var idString = Console.ReadLine().Trim();

      Guid id;
      if (!Guid.TryParse(idString, out id))
      {
        Console.WriteLine("Invalid input");
        return;
      }

      var book = bookService.GetBookById(id);

      if (book == null)
      {
        Console.WriteLine("Book not found");
        return;
      }

      Console.WriteLine($"Are you sure you want to delete the book:\n{book.Title} by {book.Author}? (y/n)");

      var input = Console.ReadLine().Trim();
      if (input.Length > 0 && input[0] == 'y')
      {
        bookService.DeleteBook(id);
        Console.WriteLine("Book deleted");
      }
    }
  }
}
