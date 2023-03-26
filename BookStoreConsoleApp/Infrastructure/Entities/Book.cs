using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Infrastructure.Entities
{
  public class Book
  {
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
