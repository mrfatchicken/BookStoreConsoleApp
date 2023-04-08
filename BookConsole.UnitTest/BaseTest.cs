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
  public abstract class BaseTest : IDisposable
  {
    protected IBookService BookService { get; set;}

    protected BaseTest()
    {
      IKernel kernel = new StandardKernel();
      kernel.Load(Assembly.GetExecutingAssembly());
      BookService = kernel.Get<IBookService>();
    }

    public void Dispose() {
      File.Delete("mockBooks.txt");
    }
  }
}
