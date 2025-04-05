using DDD.Domain;

namespace DDD.Kitchen.Domain.Aggregate.Restaurant;

public interface IRestaurantRepository : IRepository<Restaurant>
{
    Task<Restaurant?> GetRestaurantById(RestaurantId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// To get all active restaurants in system
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IReadOnlyList<Restaurant>> GetRestaurants(CancellationToken cancellationToken = default);


    /// <summary>
    /// Get restaurants for pagination by id and name
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<Restaurant>> GetRestaurants(string name, int limit, CancellationToken cancellationToken);
    
    
    Task AddRestaurant(Restaurant restaurant, CancellationToken cancellationToken = default);
    
    void UpdateRestaurant(Restaurant restaurant);

    void DeleteRestaurant(Restaurant restaurant);
}