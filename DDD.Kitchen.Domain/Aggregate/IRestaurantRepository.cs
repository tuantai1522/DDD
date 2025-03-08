using DDD.Domain;

namespace DDD.Kitchen.Domain.Aggregate;

public interface IRestaurantRepository : IRepository<Restaurant>
{
    Task<Restaurant?> GetRestaurantById(Guid restaurantId, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Restaurant>> GetRestaurants(CancellationToken cancellationToken = default);
    
    Task AddRestaurant(Restaurant restaurant, CancellationToken cancellationToken = default);
    
    Task DeleteRestaurantById(Guid restaurantId, CancellationToken cancellationToken = default);
}