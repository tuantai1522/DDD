using DDD.Domain;
using DDD.Kitchen.Application.Restaurants.Dtos;
using MediatR;

namespace DDD.Kitchen.Application.Restaurants.Queries.GetRestaurants;

public sealed record GetRestaurantsQuery : IRequest<Result<IReadOnlyList<RestaurantDto>>>
{
    
}