using System.Collections.Generic;

namespace EFCorePreview8.Models
{
  public class Author
  {
    public Author()
    {
      Books = new HashSet<Book>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Book> Books { get; set; }
  }
}