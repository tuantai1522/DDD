using DDD.Domain;
using DDD.Kitchen.Domain.Aggregate;
using MediatR;

namespace DDD.Kitchen.Application.Restaurants.Commands.DeleteRestaurant;

/// <summary>
/// This will delete restaurant.
/// </summary>
/// <param name="restaurantRepository">
/// To work with Restaurant Entity in repository
/// </param>
public sealed class DeleteRestaurantCommandHandler(IRestaurantRepository restaurantRepository) : IRequestHandler<DeleteRestaurantCommand, Result<Guid>>
{
    private readonly IRestaurantRepository _restaurantRepository = restaurantRepository;

    public async Task<Result<Guid>> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await _restaurantRepository.GetRestaurantById(new RestaurantId(request.Id), cancellationToken);

        if (restaurant is null)
        {
            return Result.Failure<Guid>(RestaurantErrors.NotFound(request.Id));
        }
        
        _restaurantRepository.DeleteRestaurant(restaurant);
        
        return Result.Success(restaurant.Id.Value);
    }
}