using DDD.Domain;
using MediatR;

namespace DDD.Kitchen.Application.Restaurants.Commands.DeleteRestaurant;

public sealed record DeleteRestaurantCommand(Guid Id) : IRequest<Result<Guid>>;
