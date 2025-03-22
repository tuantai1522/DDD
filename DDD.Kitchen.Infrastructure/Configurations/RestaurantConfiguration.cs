using DDD.Kitchen.Domain.Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Kitchen.Infrastructure.Configurations;

public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
{
    public void Configure(EntityTypeBuilder<Restaurant> builder)
    {
        builder.ToTable("Restaurants", "kitchens");

        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

        builder.HasIndex(p => p.Name).IsUnique();

        // One restaurant has multiple menu items
        builder.HasMany(r => r.MenuItems)
            .WithOne()
            .HasForeignKey(p => p.RestaurantId);

        // Configure address value object
        builder.OwnsOne(property => property.Address)
            .Property(p => p.Street).HasColumnName("Street").HasMaxLength(100).IsRequired();

        builder.OwnsOne(property => property.Address)
            .Property(p => p.ZipCode).HasColumnName("ZipCode").HasMaxLength(100);

        builder.OwnsOne(property => property.Address)
            .Property(p => p.Country).HasColumnName("Country").HasMaxLength(100).IsRequired();

    }
}