using DDD.Kitchen.Application.Restaurants.Dtos;

namespace DDD.Kitchen.Application.Restaurants.Queries.GetRestaurants;

public sealed record GetRestaurantsResponse
{
    public IReadOnlyList<RestaurantDto> Restaurants { get; init; } = [];
    
    public bool HasMore { get; init; }

    public string? Cursor { get; init; } 
}