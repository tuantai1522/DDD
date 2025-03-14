namespace DDD.Kitchen.Application.Restaurants.Dtos;

public sealed record RestaurantDto(string Name, IReadOnlyList<MenuItemDto> MenuItems);
