using System.Collections.Generic;

namespace EFCorePreview8.Models
{
  public class Book
  {
    public Book()
    {
      Authors = new HashSet<Author>();
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public virtual ICollection<Author> Authors { get; set; }
  }
}