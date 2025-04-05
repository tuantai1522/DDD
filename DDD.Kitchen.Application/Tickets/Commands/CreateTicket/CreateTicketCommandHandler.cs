using DDD.Domain;
using DDD.Kitchen.Application.Restaurants.Commands.CreateRestaurant;
using DDD.Kitchen.Domain.Aggregate.Restaurant;
using DDD.Kitchen.Domain.Aggregate.Ticket;
using MediatR;

namespace DDD.Kitchen.Application.Tickets.Commands.CreateTicket;

/// <summary>
/// This will create new ticket.
/// </summary>
/// <param name="ticketRepository">
/// To work with Ticket Entity in repository
/// </param>
public sealed class CreateTicketCommandHandler(ITicketRepository ticketRepository) : IRequestHandler<CreateTicketCommand, Result<int>>
{
    private readonly ITicketRepository _ticketRepository = ticketRepository;

    public async Task<Result<int>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var tickets = request.Tickets
            .Select(ticket => Ticket.Create(new RestaurantId(ticket.RestaurantId), ticket.TicketLineItems.Select(x => x.ToDomain()).ToList()));

        await _ticketRepository.AddTickets(tickets.Select(x => x.Value).ToList(), cancellationToken);

        return 1;
    }
}