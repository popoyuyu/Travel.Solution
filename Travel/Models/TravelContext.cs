using Microsoft.EntityFrameworkCore;

namespace Travel.Models
{
  public class TravelContext : DbContext
  {
    public TravelContext(DbContextOptions<TravelContext> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Destination>()
          .HasData(
            new Destination { DestinationId = 1, Country = "USA", City = "Seattle", Rating = 5, Review = "very nice" },
            new Destination { DestinationId = 2, Country = "USA", City = "Portland", Rating = 4, Review = "very rainy" },
            new Destination { DestinationId = 3, Country = "USA", City = "Los Angeles", Rating = 7, Review = "very sunny" },
            new Destination { DestinationId = 4, Country = "China", City = "Hong Kong", Rating = 5, Review = "very small" }
          );
    }

    public DbSet<Destination> Destinations { get; set; }
  }
}