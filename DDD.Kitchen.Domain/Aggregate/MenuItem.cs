using DDD.Domain;

namespace DDD.Kitchen.Domain.Aggregate;

public class MenuItem : Entity
{
    public string Name { get; private set; }

    public decimal Price { get; private set; }

    public Guid RestaurantId { get; private set; }
    
    private MenuItem()
    {
        
    }
    
    public static Result<MenuItem> Create(string name, decimal price, Guid restaurantId)
    {
        var menuItem = new MenuItem()
        {
            Name = name,
            Price = price,
            RestaurantId = restaurantId
        };

        return Result.Success(menuItem);
    }
}