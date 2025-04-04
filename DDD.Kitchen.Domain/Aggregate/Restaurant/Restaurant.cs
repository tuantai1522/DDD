using DDD.Domain;
using DDD.Domain.ValueObjects;

namespace DDD.Kitchen.Domain.Aggregate.Restaurant;

public sealed class Restaurant : Entity, IAggregateRoot, IAuditableEntity
{
    public RestaurantId Id { get; private init; }

    /// <summary>
    /// Name of restaurant
    /// </summary>
    public string Name { get; private set; } = null!;

    /// <summary>
    /// List of menu items in this restaurant
    /// </summary>
    private List<MenuItem> _menuItems = [];

    public IReadOnlyList<MenuItem> MenuItems
    {
        get => _menuItems.AsReadOnly(); 
        private set => _menuItems = value.ToList();
    }

    public Address Address { get; private set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string? CreatedBy { get; init; }

    public DateTime UpdatedAt { get; set; }

    public string? UpdatedBy { get; private set; }

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
            Id = RestaurantId.CreateNew(),
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