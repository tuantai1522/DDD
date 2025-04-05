using DDD.Kitchen.Domain.Aggregate;
using DDD.Kitchen.Domain.Aggregate.Restaurant;
using Microsoft.EntityFrameworkCore;

namespace DDD.Kitchen.Infrastructure.Repositories;

public sealed class RestaurantRepository(KitchenDbContext context) : IRestaurantRepository
{
    private readonly KitchenDbContext _context = context;

    public async Task<Restaurant?> GetRestaurantById(RestaurantId id, CancellationToken cancellationToken = default)
    {
        return await _context.Restaurants
            .Include(x => x.MenuItems)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<IReadOnlyList<Restaurant>> GetRestaurants(CancellationToken cancellationToken = default)
    {
        return await _context.Restaurants
            .AsNoTracking()
            .Where(x => x.Active)
            .Include(x => x.MenuItems)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<Restaurant>> GetRestaurants(string name, int limit, CancellationToken cancellationToken)
    {
        return await _context.Restaurants
            .Where(x => string.Compare(x.Name, name) >= 0 && x.Active)
            .OrderBy(x => x.Name)
            .Take(limit + 1)
            .ToListAsync(cancellationToken);
    }

    public async Task AddRestaurant(Restaurant restaurant, CancellationToken cancellationToken = default)
    {
        await _context.Restaurants.AddAsync(restaurant, cancellationToken);
    }

    public void UpdateRestaurant(Restaurant restaurant)
    {
        _context.Restaurants.Update(restaurant);
    }

    public void DeleteRestaurant(Restaurant restaurant)
    {
        _context.Restaurants.Remove(restaurant);
    }
}