using DDD.Kitchen.Domain.Aggregate.Restaurant;
using DDD.Kitchen.Domain.Aggregate.Ticket;
using Microsoft.EntityFrameworkCore;

namespace DDD.Kitchen.Infrastructure;

public class KitchenDbContext(DbContextOptions<KitchenDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("kitchens");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(KitchenDbContext).Assembly);
    }
    
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
}