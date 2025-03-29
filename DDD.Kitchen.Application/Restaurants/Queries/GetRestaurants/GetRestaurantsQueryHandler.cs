using DDD.Domain;
using DDD.Kitchen.Application.Restaurants.Dtos;
using DDD.Kitchen.Domain.Aggregate;
using MediatR;

namespace DDD.Kitchen.Application.Restaurants.Queries.GetRestaurants;

/// <summary>
/// This will get all available restaurants in system
/// </summary>
/// <param name="restaurantRepository">
/// To work with Restaurant Entity in repository
/// </param>
public sealed class GetRestaurantsQueryHandler(IRestaurantRepository restaurantRepository) 
    : IRequestHandler<GetRestaurantsQuery, Result<IReadOnlyList<RestaurantDto>>>
{
    private readonly IRestaurantRepository _restaurantRepository = restaurantRepository;

    public async Task<Result<IReadOnlyList<RestaurantDto>>> Handle(GetRestaurantsQuery request,
        CancellationToken cancellationToken)
    {
        var restaurants = await _restaurantRepository.GetRestaurants(cancellationToken);

        // To map from Restaurant to RestaurantDto
        IReadOnlyList<RestaurantDto> response = restaurants
            .Select(restaurant => new RestaurantDto(restaurant.Name, restaurant.Address, restaurant.MenuItems
                .Select(item => new MenuItemDto(item.Name, item.Price))
                .ToList()))
            .ToList();

        return Result.Success(response);
    }
}