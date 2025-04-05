using DDD.Kitchen.Domain.Aggregate;
using DDD.Kitchen.Domain.Aggregate.Restaurant;
using DDD.Kitchen.Domain.Aggregate.Ticket;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Kitchen.Infrastructure.Configurations;

public class TicketLineItemConfiguration : IEntityTypeConfiguration<TicketLineItem>
{
    public void Configure(EntityTypeBuilder<TicketLineItem> builder)
    {
        builder.ToTable("TicketLineItems", "kitchens");

        builder.Property(o => o.Id).HasConversion(
            ticketLineItem => ticketLineItem.Value,
            value => new TicketLineItemId(value));
        
        builder.Property(o => o.TicketId).HasConversion(
            ticket => ticket.Value,
            value => new TicketId(value));
        
        builder.Property(p => p.Price).IsRequired();
        
        builder.Property(p => p.Quantity).IsRequired();
        
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

    }
}