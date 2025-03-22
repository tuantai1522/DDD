using DDD.Domain;
using MediatR;

namespace DDD.Kitchen.Application.Restaurants.Commands.CreateRestaurant;

public sealed record CreateRestaurantCommand(string Name, string Street, string ZipCode, string Country) : IRequest<Result<Guid>>;
