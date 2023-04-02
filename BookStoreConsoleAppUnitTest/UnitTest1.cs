using Ninject;
using System.Reflection;

namespace BookStoreConsoleAppUnitTest
{
  [TestClass]
  public abstract class BaseTest
  {
    [TestMethod]
    public void TestMethod1()
    {
      IKernel kernel = new StandardKernel();
      kernel.Load(Assembly.GetExecutingAssembly());

    }
  }
}