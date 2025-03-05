namespace DDD.Domain;

public interface IBaseEntity;

public interface IBaseEntity<out TKey> : IBaseEntity where TKey : IEquatable<TKey>
{
    TKey Id { get; }
}