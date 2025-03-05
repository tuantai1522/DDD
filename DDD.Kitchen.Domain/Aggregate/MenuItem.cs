using DDD.Domain;

namespace DDD.Kitchen.Domain.Aggregate;

public class MenuItem(string name, double price) : Entity
{
    public string Name { get; private set; } = name;

    public double Price { get; private set; } = price;

}