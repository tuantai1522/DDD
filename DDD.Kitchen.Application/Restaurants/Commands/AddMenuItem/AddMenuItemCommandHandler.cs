using DDD.Domain;
using DDD.Kitchen.Domain.Aggregate;
using MediatR;

namespace DDD.Kitchen.Application.Restaurants.Commands.AddMenuItem;

/// <summary>
/// This will create new restaurant.
/// </summary>
/// <param name="restaurantRepository">
/// To work with Restaurant Entity in repository
/// </param>
public sealed class AddMenuItemCommandHandler(IRestaurantRepository restaurantRepository) : IRequestHandler<AddMenuItemCommand, Result<Guid>>
{
    private readonly IRestaurantRepository _restaurantRepository = restaurantRepository;

    public async Task<Result<Guid>> Handle(AddMenuItemCommand request, CancellationToken cancellationToken)
    {
        // Find restaurant by id
        var restaurant = await _restaurantRepository.GetRestaurantById(request.RestaurantId, cancellationToken);

        if (restaurant is null)
        {
            return Result.Failure<Guid>(RestaurantErrors.NotFound(request.RestaurantId));
        }

        // Add Menu Item to that restaurant
        restaurant.AddMenuItem(MenuItem.Create(request.Name, request.Price, request.RestaurantId).Value);
        
        return Result.Success(restaurant.Id);
    }
}