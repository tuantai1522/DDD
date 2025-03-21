using DDD.Domain;
using DDD.Domain.ValueObjects;

namespace DDD.Kitchen.Domain.Aggregate;

public class Restaurant : Entity, IAggregateRoot
{
    /// <summary>
    /// Name of restaurant
    /// </summary>
    public string Name { get; private set; } = null!;

    /// <summary>
    /// List menu in this restaurant
    /// </summary>
    private readonly List<MenuItem> _menuItems = [];

    public IReadOnlyCollection<MenuItem> MenuItems => _menuItems.ToList();
    
    public Address Address { get; private set; } = null!;

    private Restaurant()
    {
        
    }

    /// <summary>
    /// To create new restaurant
    /// </summary>
    /// <param name="name">
    /// Name of restaurant
    /// </param>
    /// <param name="street">
    /// Name of street
    /// </param>
    /// <param name="zipCode">
    /// zipCode
    /// </param>
    /// <param name="country">
    /// Name of country
    /// </param>
    /// <returns></returns>
    public static Result<Restaurant> Create(string name, string street, string zipCode, string country)
    {
        var restaurant = new Restaurant()
        {
            Name = name,
            Address = Address.Create(street, zipCode, country).Value
        };

        return Result.Success(restaurant);
    }
    
    public void Update(string name, string street, string zipCode, string country)
    {
        Name = name;
        Address = Address.Create(street, zipCode, country).Value;
    }
    
    /// <summary>
    /// To add new menu item
    /// </summary>
    /// <param name="menuItem"></param>
    public void AddMenuItem(MenuItem menuItem) => _menuItems.Add(menuItem);
}