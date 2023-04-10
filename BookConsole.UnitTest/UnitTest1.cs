using BookStore.Infrastructure.Entities;

namespace BookConsole.UnitTest
{
  public class UnitTest1 : BaseTest
  {
    [Theory]
    [InlineData("The Hitchhiker's Guide to the Galaxy", "Douglas Adams", "Del Rey", 2000)]
    [InlineData("The Guide to the Galaxy", "Douglas Adams", "Del Rey", 2001)]
    public void AddBook_ShouldAddBookToList(string title, string genre, string author, int publishYear)
    {
      // Arrange
      var book = new Book(title, author, genre, publishYear);

      // Act
      this.BookService.AddBook(book);

      // Assert
      Xunit.Assert.Contains(this.BookService.GetAllBooks(), x => x.Title == book.Title);
    }

    [Fact]
    public void RemoveBook_ShouldRemoveBookFromList()
    {
      // Arrange
      var book = new Book("The Lord of the Rings", "J.R.R. Tolkien", "Houghton Mifflin", 2000);
      this.BookService.AddBook(book);

      // Act
      this.BookService.DeleteBook(book.Id);

      // Assert
      Xunit.Assert.DoesNotContain(book, this.BookService.GetAllBooks());
    }

    [Theory]
    [InlineData("The Hitchhiker's Guide to the Galaxy", "Douglas Adams", "Del Rey", 2000)]
    [InlineData("The Guide to the Galaxy", "Douglas Adams", "Del Rey", 2001)]
    public void DeleteBook_ShouldNotContainBook(string title, string genre, string author, int publishYear)
    {
      // Arrange
      var book = new Book(title, author, genre, publishYear);

      // Act
      this.BookService.AddBook(book);

      if (this.BookService.GetAllBooks().Any(x => x.Title == book.Title))
      {
        this.BookService.DeleteBook(this.BookService.GetAllBooks().Single(x => x.Title == book.Title).Id);
      }

      // Assert
      Xunit.Assert.DoesNotContain(this.BookService.GetAllBooks(), x => x.Title == book.Title);
    }

    [Theory]
    [InlineData("The Hitchhiker's Guide to the Galaxy", "Douglas Adams", "Del Rey", 2000)]
    [InlineData("The Guide to the Galaxy", "Douglas Adams", "Del Rey", 2001)]
    public void Addd_ShouldNotDuplicate(string title, string genre, string author, int publishYear)
    {
      // Arrange
      var book = new Book(title, author, genre, publishYear);

      // Act
      this.BookService.AddBook(book);
      Action act = () => this.BookService.AddBook(book);

      // Assert
      Xunit.Assert.Throws<InvalidOperationException>(act);
    }

  }
}