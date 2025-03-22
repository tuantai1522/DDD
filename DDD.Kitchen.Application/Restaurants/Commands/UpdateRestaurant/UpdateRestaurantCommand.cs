using DDD.Domain;
using MediatR;

namespace DDD.Kitchen.Application.Restaurants.Commands.UpdateRestaurant;

public sealed record UpdateRestaurantCommand(Guid Id, string Name, string Street, string ZipCode, string Country) : IRequest<Result<Guid>>;
