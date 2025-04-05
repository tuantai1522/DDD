using DDD.Domain;
using MediatR;

namespace DDD.Kitchen.Application.Tickets.Commands.CreateTicket;

public sealed record CreateTicketCommand(IReadOnlyList<TicketRequest> Tickets) : IRequest<Result<int>>;
