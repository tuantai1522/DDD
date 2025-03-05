using System.Linq.Expressions;

namespace DDD.Domain;

public interface IGenericRepository<TEntity, TKey>
    where TEntity : IBaseEntity<TKey>, IAggregateRoot
    where TKey : IEquatable<TKey>
{
    /// <summary>
    /// Find an entity by id and its related object
    /// </summary>
    /// <param name="id">
    /// ID is primary key of entity
    /// </param>
    /// <returns></returns>
    Task<TEntity?> FindByIdAsync(TKey id);

    /// <summary>
    /// Find an entity by condition and its related object
    /// </summary>
    /// <param name="predicate">
    /// Predicate is the condition to filter on that entity
    /// </param>
    /// <returns></returns>
    Task<TEntity?> FindEntityByConditionAsync(Expression<Func<TEntity, bool>> predicate);
    
    /// <summary>
    /// Find all entities of type T with conditions if exists and include other properties
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyList<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>>? predicate = null);
    
    /// <summary>
    /// Find entites that match query
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    Task<int> CountByConditionAsync(Expression<Func<TEntity, bool>>? filter = null);

    /// <summary>
    /// This will add new record
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<TEntity> AddAsync(TEntity entity);

    /// <summary>
    /// This will add new list of records
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

    /// <summary>
    /// This will execute delete on entity by conditions
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<int> DeleteByAsync(Expression<Func<TEntity, bool>> predicate);
}