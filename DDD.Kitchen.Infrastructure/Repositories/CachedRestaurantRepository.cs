using DDD.Kitchen.Domain.Aggregate;
using Microsoft.Extensions.Caching.Hybrid;
using Newtonsoft.Json;

namespace DDD.Kitchen.Infrastructure.Repositories;

public sealed class CachedRestaurantRepository(HybridCache cache, IRestaurantRepository restaurantRepository) : IRestaurantRepository
{
    private readonly IRestaurantRepository _restaurantRepository = restaurantRepository;
    private readonly HybridCache _cache = cache;

    private const string Key = "restaurants";
    
    public async Task<Restaurant?> GetRestaurantById(RestaurantId id, CancellationToken cancellationToken = default)
    {
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new PrivateResolver(),
            TypeNameHandling = TypeNameHandling.All,
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
        };
        
        var restaurantKey = $"{Key}_{id.Value}";
        var cachedRestaurant = await _cache.GetOrCreateAsync(restaurantKey, async token =>
            {
                var restaurant = await _restaurantRepository.GetRestaurantById(id, token);

                return JsonConvert.SerializeObject(restaurant, settings);
                
            },
            tags: [Key],
            cancellationToken: cancellationToken);

        return JsonConvert.DeserializeObject<Restaurant>(cachedRestaurant, settings);
    }

    public async Task<IReadOnlyList<Restaurant>> GetRestaurants(CancellationToken cancellationToken = default)
    {
        var cachedRestaurants = await _cache.GetOrCreateAsync(Key, async token =>
            {
                var restaurant = await _restaurantRepository.GetRestaurants(token);

                return restaurant;
            },
            tags: [Key],
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
        
        var restaurantKey = $"{Key}_{restaurant.Id.Value}";
        _ = RemoveCache(restaurantKey);
    }

    public void DeleteRestaurant(Restaurant restaurant)
    {
        _restaurantRepository.DeleteRestaurant(restaurant);
        
        var restaurantKey = $"{Key}_{restaurant.Id.Value}";
        _ = RemoveCache(restaurantKey);
    }
    
    private async Task RemoveCache(string key)
    {
        await _cache.RemoveAsync(key);
    }
}