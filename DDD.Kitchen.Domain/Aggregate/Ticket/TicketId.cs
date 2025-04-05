using DDD.Kitchen.Domain.Aggregate.Restaurant;

namespace DDD.Kitchen.Domain.Aggregate.Ticket;

public readonly record struct TicketId(Guid Value)
{
    public static TicketId CreateNew() => new (Guid.NewGuid());
}
