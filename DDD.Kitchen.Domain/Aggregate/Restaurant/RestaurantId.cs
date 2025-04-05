namespace DDD.Kitchen.Domain.Aggregate.Restaurant;

public readonly record struct RestaurantId(Guid Value)
{
    public static RestaurantId CreateNew() => new (Guid.NewGuid());
    
    public static implicit operator Guid(RestaurantId id) => id.Value;  // Chuyển đổi tự động sang Guid
    public static implicit operator RestaurantId(Guid id) => new(id);   // Chuyển đổi tự động từ Guid

}
