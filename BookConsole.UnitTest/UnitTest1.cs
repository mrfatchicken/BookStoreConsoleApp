using BookStore.Infrastructure.Entities;

namespace BookConsole.UnitTest
{
  public class UnitTest1 : BaseTest
  {
    [Fact]
    public void AddBook_ShouldAddBookToList()
    {
      // Arrange
      var book = new Book("The Hitchhiker's Guide to the Galaxy", "Douglas Adams", "Del Rey", 2000);

      // Act
      this.BookRepository.Add(book);

      // Assert
      Xunit.Assert.Equal(true, this.BookRepository.GetAll().Any(x => x.Title == book.Title));
    }

    [Fact]
    public void RemoveBook_ShouldRemoveBookFromList()
    {
      // Arrange
      var book = new Book("The Lord of the Rings", "J.R.R. Tolkien", "Houghton Mifflin", 2000);
      this.BookRepository.Add(book);

      // Act
      this.BookRepository.Delete(book.Id);

      // Assert
      Xunit.Assert.Equal(false, this.BookRepository.GetAll().Contains(book));
    }
  }
}