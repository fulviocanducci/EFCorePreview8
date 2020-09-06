using System;
using System.Linq;
using EFCorePreview8.Models;
using EFCorePreview8.Services;
using Microsoft.EntityFrameworkCore;

namespace EFCorePreview8
{
  class Program
  {
    static void Main(string[] args)
    {
      DbContextOptionsBuilder<DatabaseContext> builder = new DbContextOptionsBuilder<DatabaseContext>();
      builder.UseSqlServer(@"Server=.\SqlExpress;Database=Sources;User Id=sa;Password=123456;");
      using (DatabaseContext context = new DatabaseContext(builder.Options))
      {
        // //Console.WriteLine(context.Database.EnsureCreated());
        // Author author = new Author
        // {
        //   Name = "Marcos de Souza"
        // };
        // Book book0 = context.Book.Find(1);
        // book0.Authors.Add(author);

        // Console.WriteLine(context.SaveChanges() > 0);

        Book book0 = context.Book.Where(c => c.Id == 1).Include(c => c.Authors).FirstOrDefault();
        Console.Clear();
        Console.WriteLine("{0}", "=================================================");
        Console.WriteLine("{0}", "Livro:");
        Console.WriteLine("{0:000} - {1}", book0.Id, book0.Title);
        Console.WriteLine("{0}", "=================================================");
        Console.WriteLine("{0}", "Autores:");
        foreach (var item in book0.Authors.ToList())
        {
          Console.WriteLine("{0:000} - {1}", item.Id, item.Name);
        }
        Console.WriteLine("{0}", "=================================================");
      }
      Console.WriteLine();
      Console.WriteLine();
    }
  }
}
