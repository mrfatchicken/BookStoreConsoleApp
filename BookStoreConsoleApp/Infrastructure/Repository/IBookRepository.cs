using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Infrastructure.Entities;

namespace BookStore.Infrastructure.Repository
{
    public interface IBookRepository
    {
      List<Book> GetAll();
      void SaveAll(List<Book> books);
      void Add(Book book);
      void Update(Book book);
      void Delete(Guid id);
  }
}
