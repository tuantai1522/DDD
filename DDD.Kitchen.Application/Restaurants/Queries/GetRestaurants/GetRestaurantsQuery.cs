using DDD.Domain;
using DDD.Kitchen.Application.Restaurants.Dtos;
using MediatR;

namespace DDD.Kitchen.Application.Restaurants.Queries.GetRestaurants;

public sealed record GetRestaurantsQuery : IRequest<Result<GetRestaurantsResponse>>
{
    public int Limit { get; init; } = 10;
    
    public string? Cursor { get; init; }
}