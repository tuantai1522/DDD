using DDD.Kitchen.Domain.Aggregate.Restaurant;
using DDD.Kitchen.Domain.Aggregate.Ticket;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Kitchen.Infrastructure.Configurations;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Tickets", "kitchens");
        
        builder.Property(o => o.Id).HasConversion(
            ticket => ticket.Value,
            value => new TicketId(value));
        
        builder.Property(o => o.RestaurantId).HasConversion(
            restaurant => restaurant.Value,
            value => new RestaurantId(value));

        // One ticket has multiple ticket line items
        builder.HasMany(r => r.TicketLineItems)
            .WithOne()
            .HasForeignKey(p => p.TicketId);
    }
}