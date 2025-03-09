using DDD.Kitchen.Domain.Aggregate;

namespace DDD.Kitchen.Application.Restaurants.Dtos;

public sealed record RestaurantDto(string Name, IReadOnlyList<MenuItemDto> MenuItems)
{
    public static RestaurantDto MapToRestaurant(Restaurant restaurant)
    {
        return new RestaurantDto(
            restaurant.Name,
            restaurant.MenuItems.Select(menuItem => new MenuItemDto(menuItem.Name, menuItem.Price)).ToList()
        );
    }
}
