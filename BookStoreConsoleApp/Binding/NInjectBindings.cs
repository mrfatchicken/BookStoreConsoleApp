using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Infrastructure.Repository;
using BookStore.Infrastructure.Services;

namespace BookStore.Binding
{
  public class NInjectBindings : Ninject.Modules.NinjectModule
  {
    public override void Load()
    {
      Bind<IBookRepository>().To<BookRepository>().When(x => !IsJsonEnv()).WithConstructorArgument("filePath", "Documents/books.txt")
                .WithMetadata("type", "text");
      Bind<IBookRepository>().To<BookJsonRepository>().When(x => IsJsonEnv()).WithConstructorArgument("filePath", "Documents/books.json")
              .WithMetadata("type", "json");
      Bind<IBookService>().To<BookService>();
    }

    private static bool IsJsonEnv() {
#if Json
      return true;
#endif
      return false;
    }
  }
}
