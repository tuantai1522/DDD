using DDD.Kitchen.Domain.Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Kitchen.Infrastructure.Configurations;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        
        builder.HasIndex(p => p.Name).IsUnique();
        
        // One restaurant has multiple menu items
        builder.HasMany(r => r.MenuItems)
            .WithOne()
            .HasForeignKey(p => p.RestaurantId);
    }
}