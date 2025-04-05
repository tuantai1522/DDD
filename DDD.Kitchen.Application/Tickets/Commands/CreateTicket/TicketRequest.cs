namespace DDD.Kitchen.Application.Tickets.Commands.CreateTicket;

public sealed record TicketRequest(Guid RestaurantId, IReadOnlyList<TicketLineItemRequest> TicketLineItems);
