using BookConsole.UnitTest.Mock;
using BookStore.Infrastructure.Repository;
using BookStore.Infrastructure.Services;

namespace BookStore.Binding
{
  public class NInjectBindings : Ninject.Modules.NinjectModule
  {
    public override void Load()
    {
      Bind<IBookRepository>().To<MockBookRepository>().WithMetadata("type", "text");
      Bind<IBookService>().To<BookService>();
    }
   
  }
}
