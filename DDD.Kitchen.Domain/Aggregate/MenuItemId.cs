namespace DDD.Kitchen.Domain.Aggregate;

public readonly record struct MenuItemId(Guid Value)
{
    public static MenuItemId CreateNew() => new (Guid.NewGuid());
}
