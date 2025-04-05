using DDD.Domain;
using DDD.Kitchen.Domain.Aggregate;
using DDD.Kitchen.Domain.Aggregate.Restaurant;
using MediatR;

namespace DDD.Kitchen.Application.Restaurants.Commands.UpdateRestaurant;

/// <summary>
/// This will update restaurant.
/// </summary>
/// <param name="restaurantRepository">
/// To work with Restaurant Entity in repository
/// </param>
public sealed class UpdateRestaurantCommandHandler(IRestaurantRepository restaurantRepository) : IRequestHandler<UpdateRestaurantCommand, Result<Guid>>
{
    private readonly IRestaurantRepository _restaurantRepository = restaurantRepository;

    public async Task<Result<Guid>> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantRepository.GetRestaurantById(new RestaurantId(request.Id), cancellationToken);

        if (restaurant is null)
        {
            return Result.Failure<Guid>(RestaurantErrors.NotFound(request.Id));
        }
        
        restaurant.Update(request.Name, request.Street, request.ZipCode, request.Country);
        
        _restaurantRepository.UpdateRestaurant(restaurant);
        
        return Result.Success(restaurant.Id.Value);
    }
}