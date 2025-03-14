using DDD.Domain;
using DDD.Kitchen.Application.Restaurants.Dtos;
using MediatR;

namespace DDD.Kitchen.Application.Restaurants.Queries.GetRestaurantById;

/// <summary>
/// Query to get a restaurant by its unique identifier.
/// </summary>
/// <param name="Id">The unique identifier of the restaurant.</param>
/// <returns>A result containing the restaurant data transfer object.</returns>
public sealed record GetRestaurantByIdQuery(Guid Id) : IRequest<Result<RestaurantDto>>;