namespace DDD.Kitchen.Domain.Aggregate.Ticket;

public readonly record struct TicketLineItemId(Guid Value)
{
    public static TicketLineItemId CreateNew() => new (Guid.NewGuid());
}
