using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Infrastructure.Entities;
using BookStore.Infrastructure.Repository;
using Microsoft.Extensions.Logging;

namespace BookStore.Infrastructure.Services
{
  public class BookService : IBookService
  {
    private readonly IBookRepository _repository;
    private readonly ILogger _logger;

    public BookService(IBookRepository repository, ILogger<BookService> logger)
    {
      _repository = repository;
      _logger = logger;
    }

    public List<Book> GetAllBooks()
    {
      _logger.LogInformation("Get all books");
      return _repository.GetAll();
    }

    public Book GetBookById(Guid id)
    {
      return _repository.GetAll().FirstOrDefault(b => b.Id == id);
    }

    public void AddBook(Book book)
    {
      _logger.LogInformation($"Add Book {book}");
      if (book == null)
        throw new ArgumentNullException(nameof(book), "Book data cannot be empty.");

      if (string.IsNullOrEmpty(book.Title))
        throw new ArgumentNullException(nameof(book.Title), "Title is required.");

      if (string.IsNullOrEmpty(book.Author))
        throw new ArgumentNullException(nameof(book.Author), "Author is required.");

      if (string.IsNullOrEmpty(book.Genre))
        throw new ArgumentNullException(nameof(book.Genre), "Genre is required.");

      // Check if the book already exists in the repository
      if (_repository.GetAll().Any(b => b.Title == book.Title && b.Author == book.Author))
        throw new InvalidOperationException("This book already exists.");

      _repository.Add(book);
    }

    public void UpdateBook(Book book)
    {
      _logger.LogInformation($"Update Book {book}");
      if (book == null)
        throw new ArgumentNullException(nameof(book), "Book data cannot be empty.");

      if (string.IsNullOrEmpty(book.Title))
        throw new ArgumentNullException(nameof(book.Title), "Title is required.");

      if (string.IsNullOrEmpty(book.Author))
        throw new ArgumentNullException(nameof(book.Author), "Author is required.");

      if (string.IsNullOrEmpty(book.Genre))
        throw new ArgumentNullException(nameof(book.Genre), "Genre is required.");

      // Check if the book already exists in the repository
      if (_repository.GetAll().Any(b => b.Id != book.Id && b.Title == book.Title && b.Author == book.Author))
        throw new InvalidOperationException("This book already exists.");

      _repository.Update(book);
    }

    public void DeleteBook(Guid id)
    {
      _logger.LogInformation($"Delete Book id {id}");
      _repository.Delete(id);
    }

    public bool IsBookAvailable(Guid id)
    {
      return _repository.GetAll().FirstOrDefault(b => b.Id == id)!.IsAvailable;
    }
  }
}
