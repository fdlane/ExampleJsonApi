using ExampleJsonApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleJsonApi;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
  public DbSet<Bar> Bars => Set<Bar>();
  public DbSet<Foo> Foos => Set<Foo>();
  public DbSet<Person> People => Set<Person>();

  protected override void OnConfiguring(DbContextOptionsBuilder builder)
  {
    builder.UseSqlite("Data Source=SampleDb.db");
    builder.UseAsyncSeeding(async (dbContext, _, cancellationToken) =>
    {
      dbContext.Set<Person>().Add(new Person
      {
        FirstName = "John",
        LastName = "Doe",
        Children =
        {
          new Person
          {
            FirstName = "Baby",
            LastName = "Doe"
          }
        }
      });
      await dbContext.SaveChangesAsync(cancellationToken);
    });
  }
}
