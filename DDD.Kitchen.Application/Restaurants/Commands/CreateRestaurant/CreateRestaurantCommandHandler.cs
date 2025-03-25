using DDD.Domain;
using DDD.Kitchen.Domain.Aggregate;
using MediatR;

namespace DDD.Kitchen.Application.Restaurants.Commands.CreateRestaurant;

/// <summary>
/// This will create new restaurant.
/// </summary>
/// <param name="restaurantRepository">
/// To work with Restaurant Entity in repository
/// </param>
public sealed class CreateRestaurantCommandHandler(IRestaurantRepository restaurantRepository) : IRequestHandler<CreateRestaurantCommand, Result<Guid>>
{
    private readonly IRestaurantRepository _restaurantRepository = restaurantRepository;

    public async Task<Result<Guid>> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var restaurant = Restaurant.Create(request.Name, request.Street, request.ZipCode, request.Country);

        await _restaurantRepository.AddRestaurant(restaurant.Value, cancellationToken);
        
        return Result.Success(restaurant.Value.Id.Value);
    }
}