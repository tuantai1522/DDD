using DDD.Domain;

namespace DDD.Kitchen.Domain.Aggregate;

public class MenuItem(string name, decimal price, Guid restaurantId) : Entity
{
    public string Name { get; private set; } = name;

    public decimal Price { get; private set; } = price;

    public Guid RestaurantId { get; private set; } = restaurantId;

}