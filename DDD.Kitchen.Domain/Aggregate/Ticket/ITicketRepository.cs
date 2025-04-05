using DDD.Domain;

namespace DDD.Kitchen.Domain.Aggregate.Ticket;

public interface ITicketRepository : IRepository<Ticket>
{
    Task AddTickets(IReadOnlyList<Ticket> tickets, CancellationToken cancellationToken = default);
}