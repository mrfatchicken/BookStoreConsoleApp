using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Entities
{
  public class Book
  {
    public Book(string title, string author, string genre, int publishedYear, bool isAvailable = true)
    {
      Title = title;
      Author = author;
      Genre = genre;
      PublishedYear = publishedYear;
      IsAvailable = isAvailable;
    }

    public Book() { }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int PublishedYear { get; set; }
    public bool IsAvailable { get; set; }

    public override string ToString()
    {
      return $"{Title} by {Author}";
    }


  }
}
