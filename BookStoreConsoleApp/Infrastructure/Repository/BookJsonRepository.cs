using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BookStore.Infrastructure.Entities;

namespace BookStore.Infrastructure.Repository
{

  public class BookJsonRepository : IBookRepository
  {
    private readonly string _filePath;

    public BookJsonRepository(string filePath = "books.json")
    {
      _filePath = filePath;
    }

    public List<Book> GetAll()
    {
      string json = File.ReadAllText(_filePath);
      List<Book> books = JsonConvert.DeserializeObject<List<Book>>(json);

      if (books == null)
      {
        books = new List<Book>();
      }

      return books;
    }

    public void Add(Book book)
    {
      if (IsBookAvailable(book.Title, book.Author))
      {
        throw new InvalidOperationException("Book already exists.");
      }

      List<Book> books = GetAll();
      books.Add(book);
      SaveAll(books);
    }

    public void Update(Book book)
    {
      List<Book> books = GetAll();
      int index = books.FindIndex(b => b.Id == book.Id);

      if (index != -1)
      {
        books[index] = book;
        SaveAll(books);
      }
      else
      {
        throw new ArgumentException(nameof(book));
      }
    }

    public void Delete(Book book)
    {
      List<Book> books = GetAll();
      Book bookToRemove = books.Find(b => b.Title == book.Title && b.Author == book.Author);

      if (bookToRemove != null)
      {
        books.Remove(bookToRemove);
        SaveAll(books);
      }
      else
      {
        throw new ArgumentException(nameof(book));
      }
    }

    public void SaveAll(List<Book> books)
    {
      string json = JsonConvert.SerializeObject(books, Newtonsoft.Json.Formatting.Indented);
      File.WriteAllText(_filePath, json);
    }

    private bool IsBookAvailable(string title, string author)
    {
      List<Book> books = GetAll();
      return books.Any(b => b.Title == title && b.Author == author);
    }

    public void Delete(Guid id)
    {
      List<Book> books = GetAll();
      Book bookToRemove = books.FirstOrDefault(b => b.Id == id);
      if (bookToRemove != null)
      {
        books.Remove(bookToRemove);
        SaveAll(books);
      }
    }
  }
}
