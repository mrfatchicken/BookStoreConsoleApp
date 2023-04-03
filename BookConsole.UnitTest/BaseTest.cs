using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BookStore.Infrastructure.Repository;
using BookStore.Infrastructure.Services;
using Ninject;
using NSubstitute;

namespace BookConsole.UnitTest
{
  public abstract class BaseTest
  {
    protected IBookRepository BookRepository { get; set; }
    protected IBookService BookService { get; set;}

    protected BaseTest()
    {
      BookRepository = Substitute.For<BookRepository>("books.txt");
      BookService = Substitute.For<BookService>(BookRepository);
    }
  }
}
