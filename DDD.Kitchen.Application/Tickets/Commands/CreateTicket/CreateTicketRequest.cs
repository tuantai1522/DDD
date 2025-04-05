namespace DDD.Kitchen.Application.Tickets.Commands.CreateTicket;

public sealed record CreateTicketRequest(IReadOnlyList<TicketRequest> Tickets);