using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Infrastructure.Repository;
using WpfApp2.Infrastructure.Services;

namespace BookStoreConsoleApp.Binding
{
  public class NInjectBindings : Ninject.Modules.NinjectModule
  {
    public override void Load()
    {
      Bind<IBookRepository>().To<BookRepository>().When(x => !IsJsonEnv()).WithConstructorArgument("filePath", "Documents/books.txt")
                .WithMetadata("type", "test/text");
      Bind<IBookRepository>().To<BookJsonRepository>().When(x => IsJsonEnv()).WithConstructorArgument("filePath", "Documents/books.json")
              .WithMetadata("type", "test/json");
      Bind<IBookService>().To<BookService>();
    }

    private static bool IsJsonEnv()
    {
#if Json
      return true;
#endif
      return false;
    }
  }
}
