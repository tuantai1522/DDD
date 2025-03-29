using DDD.Domain.ValueObjects;

namespace DDD.Kitchen.Application.Restaurants.Dtos;

public sealed record RestaurantDto(string Name, Address Address, IReadOnlyList<MenuItemDto> MenuItems);
