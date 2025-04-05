using DDD.Domain;
using DDD.Kitchen.Domain.Aggregate.Restaurant;

namespace DDD.Kitchen.Domain.Aggregate.Ticket;

public sealed class TicketLineItem : Entity, IAuditableEntity
{
    public TicketLineItemId Id { get; private init; }
    
    public TicketId TicketId { get; private init; }
    
    /// <summary>
    /// Amount of menu item
    /// </summary>
    public double Quantity { get; private init; }

    public string Name { get; private init; } = null!;
    
    /// <summary>
    /// Current price of the menu item
    /// </summary>
    public double Price { get; private init; }

    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; init; }

    public DateTime UpdatedAt { get; set; }
    public string? UpdatedBy { get; private set; }
    
    private TicketLineItem()
    {

    }

    public static Result<TicketLineItem> Create(string name, double quantity, double price)
    {
        var ticketLineItem = new TicketLineItem()
        {
            Id = TicketLineItemId.CreateNew(),
            Price = price,
            Quantity = quantity,
            Name = name,
        };

        return Result.Success(ticketLineItem);
    }
}