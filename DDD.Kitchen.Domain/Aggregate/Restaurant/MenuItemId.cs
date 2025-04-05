namespace DDD.Kitchen.Domain.Aggregate.Restaurant;

public readonly record struct MenuItemId(Guid Value)
{
    public static MenuItemId CreateNew() => new (Guid.NewGuid());
}
