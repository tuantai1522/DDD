using DDD.Kitchen.Domain.Aggregate;
using DDD.Kitchen.Domain.Aggregate.Restaurant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Kitchen.Infrastructure.Configurations;

public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
    public void Configure(EntityTypeBuilder<MenuItem> builder)
    {
        builder.ToTable("MenuItems", "kitchens");

        builder.Property(o => o.Id).HasConversion(
            menuItem => menuItem.Value,
            value => new MenuItemId(value));
        
        builder.Property(o => o.RestaurantId).HasConversion(
            restaurantId => restaurantId.Value,
            value => new RestaurantId(value));
        
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        
        builder.Property(p => p.Price).IsRequired();
    }
}