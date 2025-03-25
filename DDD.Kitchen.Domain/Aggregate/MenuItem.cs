using DDD.Domain;

namespace DDD.Kitchen.Domain.Aggregate;

public class MenuItem : Entity, IAuditableEntity
{
    public MenuItemId Id { get; private init; }

    public string Name { get; private set; }

    public decimal Price { get; private set; }

    public RestaurantId RestaurantId { get; private init; }

    public DateTime CreatedAt { get; set; }
    
    public string? CreatedBy { get; init; }
    
    public DateTime UpdatedAt { get; set; }
    
    public string? UpdatedBy { get; private set; }

    private MenuItem()
    {

    }

    public static Result<MenuItem> Create(string name, decimal price, RestaurantId restaurantId)
    {
        var menuItem = new MenuItem()
        {
            Id = MenuItemId.CreateNew(),
            Name = name,
            Price = price,
            RestaurantId = restaurantId
        };

        return Result.Success(menuItem);
    }

}