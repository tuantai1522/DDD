using DDD.Kitchen.Domain.Aggregate.Ticket;

namespace DDD.Kitchen.Infrastructure.Repositories;

public sealed class TicketRepository(KitchenDbContext context) : ITicketRepository
{
    private readonly KitchenDbContext _context = context;

    public async Task AddTickets(IReadOnlyList<Ticket> tickets, CancellationToken cancellationToken = default)
    {
        await _context.Tickets.AddRangeAsync(tickets, cancellationToken);
    }
}