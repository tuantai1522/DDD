using DDD.Kitchen.Domain.Aggregate.Ticket;

namespace DDD.Kitchen.Application.Tickets.Commands.CreateTicket;

public sealed record TicketLineItemRequest(string Name, double Price, double Quantity)
{
    public TicketLineItem ToDomain() 
    {
        return TicketLineItem.Create(Name, Quantity, Price).Value;
    }
}
