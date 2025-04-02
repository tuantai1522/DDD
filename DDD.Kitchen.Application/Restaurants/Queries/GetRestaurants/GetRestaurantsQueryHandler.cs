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
    : IRequestHandler<GetRestaurantsQuery, Result<GetRestaurantsResponse>>
{
    private readonly IRestaurantRepository _restaurantRepository = restaurantRepository;

    public async Task<Result<GetRestaurantsResponse>> Handle(GetRestaurantsQuery request,
        CancellationToken cancellationToken)
    {
        var name = string.Empty;

        if (!string.IsNullOrEmpty(request.Cursor))
        {
            var decodedCursor = CursorRestaurant.Decode(request.Cursor);

            // Can not decode cursor
            if (decodedCursor == null)
            {
                return Result.Failure<GetRestaurantsResponse>(RestaurantErrors.CanNotFindQuery);
            }
            
            name = decodedCursor.Name;
        }
        
        var restaurants = await _restaurantRepository.GetRestaurants(name, request.Limit, cancellationToken);

        // To map from Restaurant to RestaurantDto
        List<RestaurantDto> items = restaurants
            .Select(restaurant => new RestaurantDto(restaurant.Name, restaurant.Address, restaurant.MenuItems
                .Select(item => new MenuItemDto(item.Name, item.Price))
                .ToList()))
            .ToList();
        
        var hasMore = items.Count > request.Limit;

        name = hasMore ? restaurants[^1].Name : string.Empty;
        
        // Remove last item if hasMore
        items.RemoveAt(items.Count - 1);

        return Result.Success(new GetRestaurantsResponse()
        {
            Restaurants = items,
            Cursor = name != string.Empty
                ? CursorRestaurant.Encode(name)
                : null,
            HasMore = hasMore
        });
    }
}