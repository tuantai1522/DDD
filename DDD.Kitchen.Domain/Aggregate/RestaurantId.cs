namespace DDD.Kitchen.Domain.Aggregate;

public readonly record struct RestaurantId(Guid Value)
{
    public static RestaurantId CreateNew() => new (Guid.NewGuid());

}
