using DDD.Domain;
using MediatR;

namespace DDD.Kitchen.Application.Restaurants.Commands.UpdateRestaurant;

public sealed record UpdateRestaurantCommand(Guid Id, string Name) : IRequest<Result<Guid>>;
