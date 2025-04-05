using DDD.Domain;
using DDD.Kitchen.Domain.Aggregate;
using DDD.Kitchen.Domain.Aggregate.Restaurant;
using MediatR;

namespace DDD.Kitchen.Application.Restaurants.Commands.AddMenuItem;

public sealed record AddMenuItemCommand(string Name, decimal Price, RestaurantId RestaurantId) : IRequest<Result<Guid>>;
