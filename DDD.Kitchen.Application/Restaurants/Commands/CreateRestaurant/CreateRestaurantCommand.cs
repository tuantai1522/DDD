using DDD.Domain;
using MediatR;

namespace DDD.Kitchen.Application.Restaurants.Commands.CreateRestaurant;

public sealed record CreateRestaurantCommand(string Name) : IRequest<Result<Guid>>;
