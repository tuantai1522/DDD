using DDD.Domain;
using MediatR;

namespace DDD.Kitchen.Application.Restaurants.Commands.AddMenuItem;

public sealed record AddMenuItemCommand(string Name, decimal Price, Guid RestaurantId) : IRequest<Result<Guid>>;
