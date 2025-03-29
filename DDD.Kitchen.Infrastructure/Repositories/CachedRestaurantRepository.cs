using DDD.Kitchen.Domain.Aggregate;
using Microsoft.Extensions.Caching.Hybrid;
using Newtonsoft.Json;

namespace DDD.Kitchen.Infrastructure.Repositories;

public sealed class CachedRestaurantRepository(HybridCache cache, IRestaurantRepository restaurantRepository) : IRestaurantRepository
{
    private readonly IRestaurantRepository _restaurantRepository = restaurantRepository;
    private readonly HybridCache _cache = cache;

    public async Task<Restaurant?> GetRestaurantById(RestaurantId id, CancellationToken cancellationToken = default)
    {
        var key = $"restaurant-{id.Value}";
                        
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new PrivateResolver(),
            TypeNameHandling = TypeNameHandling.All,
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
        };
        
        var cachedRestaurant = await _cache.GetOrCreateAsync(key, async token =>
            {
                var restaurant = await _restaurantRepository.GetRestaurantById(id, token);

                return JsonConvert.SerializeObject(restaurant, settings);
                
            },
            tags: ["restaurants"],
            cancellationToken: cancellationToken);

        return JsonConvert.DeserializeObject<Restaurant>(cachedRestaurant, settings);
    }

    public async Task<IReadOnlyList<Restaurant>> GetRestaurants(CancellationToken cancellationToken = default)
    {
        const string key = $"restaurants";

        var cachedRestaurants = await _cache.GetOrCreateAsync(key, async token =>
            {
                var restaurant = await _restaurantRepository.GetRestaurants(token);

                return restaurant;
            },
            tags: ["restaurants"],
            cancellationToken: cancellationToken);

        return cachedRestaurants;
    }

    public async Task AddRestaurant(Restaurant restaurant, CancellationToken cancellationToken = default)
    {
        await _restaurantRepository.AddRestaurant(restaurant, cancellationToken);
    }

    public void UpdateRestaurant(Restaurant restaurant)
    {
        _restaurantRepository.UpdateRestaurant(restaurant);
    }

    public void DeleteRestaurant(Restaurant restaurant)
    {
        _restaurantRepository.DeleteRestaurant(restaurant);
    }
}