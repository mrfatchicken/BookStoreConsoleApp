using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Infrastructure.Entities;
using WpfApp2.Infrastructure.Repository;
using Xunit;

namespace BookStoreConsoleAppUnitTest
{

  public class SampleTests
  {
    [Fact]
    public void AddBook_ShouldAddBookToList()
    {
      // Arrange
      var book = new Book("The Hitchhiker's Guide to the Galaxy", "Douglas Adams", "Del Rey",2000);
      var bookRepo = new BookRepository("test/books.txt");

      // Act
      bookRepo.Add(book);

      // Assert
      Xunit.Assert.Equal(true, bookRepo.GetAll().Contains(book));
    }

    [Fact]
    public void RemoveBook_ShouldRemoveBookFromList()
    {
      // Arrange
      var book = new Book("The Lord of the Rings", "J.R.R. Tolkien", "Houghton Mifflin", 2000);
      var bookRepo = new BookRepository("test/books.txt");
      bookRepo.Add(book);

      // Act
      bookRepo.Delete(book.Id);

      // Assert
      Xunit.Assert.Equal(false, bookRepo.GetAll().Contains(book));
    }

    //[Fact]
    //public void GenerateInventoryReport_ShouldReturnReportString()
    //{
    //  // Arrange
    //  var book1 = new Book("1984", "George Orwell", "Secker and Warburg", 2000);
    //  var book2 = new Book("Animal Farm", "George Orwell", "Secker and Warburg", 2000);
    //  var book3 = new Book("Brave New World", "Aldous Huxley", "Chatto & Windus", 2000);
    //  var book4 = new Book("Fahrenheit 451", "Ray Bradbury", "Ballantine Books", 2000);
    //  var bookStore = new BookStore();
    //  bookStore.AddBook(book1);
    //  bookStore.AddBook(book2);
    //  bookStore.AddBook(book3);
    //  bookStore.AddBook(book4);

    //  var expectedReport = "Inventory Report\n"
    //      + "----------------\n"
    //      + "Title: 1984, Author: George Orwell, Publisher: Secker and Warburg, Price: $9.99\n"
    //      + "Title: Animal Farm, Author: George Orwell, Publisher: Secker and Warburg, Price: $6.99\n"
    //      + "Title: Brave New World, Author: Aldous Huxley, Publisher: Chatto & Windus, Price: $7.99\n"
    //      + "Title: Fahrenheit 451, Author: Ray Bradbury, Publisher: Ballantine Books, Price: $8.99\n"
    //      + "Total value of inventory: $33.96";

    //  // Act
    //  var report = bookStore.GenerateInventoryReport();

    //  // Assert
    //  report.Should().Be(expectedReport);
    //}

    //[Fact]
    //public void SaveInventory_ShouldCallWriteAllLines()
    //{
    //  // Arrange
    //  var fileUtilsSubstitute = Substitute.For<IFileUtils>();
    //  var bookStore = new BookStore(fileUtilsSubstitute);

    //  // Act
    //  bookStore.SaveInventory();

    //  // Assert
    //  fileUtilsSubstitute.Received().WriteAllLines(Arg.Any<string>(), Arg.Any<string[]>());
    //}
  }
}
