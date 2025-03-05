using DDD.Domain;

namespace DDD.Kitchen.Domain.Aggregate;

public interface IRestaurantRepository : IGenericRepository<Restaurant, Guid>
{
    
}