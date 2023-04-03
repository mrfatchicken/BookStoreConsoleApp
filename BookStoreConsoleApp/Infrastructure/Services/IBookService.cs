using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Infrastructure.Entities;

namespace BookStore.Infrastructure.Services
{
  public interface IBookService
  {
    List<Book> GetAllBooks();

    Book GetBookById(Guid id);

    void AddBook(Book book);

    void UpdateBook(Book book);

    void DeleteBook(Guid id);

    bool IsBookAvailable(Guid id);

  }
}
