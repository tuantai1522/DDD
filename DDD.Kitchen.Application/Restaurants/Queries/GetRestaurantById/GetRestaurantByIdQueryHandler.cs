using DDD.Domain;
using DDD.Kitchen.Application.Restaurants.Dtos;
using DDD.Kitchen.Domain.Aggregate;
using DDD.Kitchen.Domain.Aggregate.Restaurant;
using MediatR;

namespace DDD.Kitchen.Application.Restaurants.Queries.GetRestaurantById;

/// <summary>
/// This will get all available restaurants in system
/// </summary>
/// <param name="restaurantRepository">
/// To work with Restaurant Entity in repository
/// </param>
public sealed class GetRestaurantByIdQueryHandler(IRestaurantRepository restaurantRepository) 
    : IRequestHandler<GetRestaurantByIdQuery, Result<RestaurantDto>>
{
    private readonly IRestaurantRepository _restaurantRepository = restaurantRepository;

    public async Task<Result<RestaurantDto>> Handle(GetRestaurantByIdQuery request,
        CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantRepository.GetRestaurantById(new RestaurantId(request.Id), cancellationToken);

        return restaurant is null
            ? Result.Failure<RestaurantDto>(RestaurantErrors.NotFound(request.Id))
            : Result.Success(new RestaurantDto(restaurant.Name, restaurant.Address, restaurant.MenuItems.Select(item => new MenuItemDto(item.Name, item.Price)).ToList()));
    }
}