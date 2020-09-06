using EFCorePreview8.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCorePreview8.Services
{
  public class DatabaseContext : DbContext
  {
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
    : base(options)
    {

    }
    public DbSet<Author> Author { get; set; }
    public DbSet<Book> Book { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Author>(config =>
      {
        config.ToTable("Autors");
        config.HasKey(x => x.Id);
        config.Property(x => x.Id)
          .UseIdentityColumn();
        config.Property(x => x.Name)
          .HasMaxLength(100)
          .IsRequired();
        config.HasMany(x => x.Books)
          .WithMany(x => x.Authors)
          .UsingEntity(x =>
          {
            x.ToTable("AuthorsBooks");
          });
      });
      modelBuilder.Entity<Book>(config =>
      {
        config.ToTable("Books");
        config.HasKey(x => x.Id);
        config.Property(x => x.Id)
          .UseIdentityColumn();
        config.Property(x => x.Title)
              .HasMaxLength(100)
              .IsRequired();
        config.HasMany(x => x.Authors)
              .WithMany(x => x.Books);
      });
    }
  }
}