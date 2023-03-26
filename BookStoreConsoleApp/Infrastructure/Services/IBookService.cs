using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Infrastructure.Entities;

namespace WpfApp2.Infrastructure.Services
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
