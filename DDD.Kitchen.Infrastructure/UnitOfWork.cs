using DDD.Domain;

namespace DDD.Kitchen.Infrastructure;

public class UnitOfWork(KitchenDbContext context) : IUnitOfWork
{
    private readonly KitchenDbContext _context = context;

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}