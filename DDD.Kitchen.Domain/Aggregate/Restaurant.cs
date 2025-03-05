using DDD.Domain;

namespace DDD.Kitchen.Domain.Aggregate;

public class Restaurant : Entity, IAggregateRoot
{
    /// <summary>
    /// Name of restaurant
    /// </summary>
    public string Name { get; private set; } = default!;

    /// <summary>
    /// List menu in this restaurant
    /// </summary>
    private readonly List<MenuItem> _menuItems = [];

    public IReadOnlyCollection<MenuItem> MenuItems => _menuItems.ToList();

    private Restaurant()
    {
        
    }

    /// <summary>
    /// To create new restaurant
    /// </summary>
    /// <param name="name">
    /// Name of restaurant
    /// </param>
    /// <returns></returns>
    public static Result<Restaurant> Create(string name)
    {
        var restaurant = new Restaurant()
        {
            Name = name,
        };

        return Result.Success(restaurant);
    }
    
    /// <summary>
    /// To add new menu item
    /// </summary>
    /// <param name="menuItem"></param>
    public void AddMenuItem(MenuItem menuItem) => _menuItems.Add(menuItem);
    
}