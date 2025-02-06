using DDD.Domain.Common;

namespace DDD.Domain.Aggregates.GenderAggregate;

public class Gender : Entity, IAggregateRoot
{
    /// <summary>
    /// Info of Gender
    /// </summary>
    public string Name { get; private set; } = default!;
    
    public string? Description { get; private set; }
    
    private Gender()
    {
        
    }
    
    public Gender(string name, string description)
    {
        Name = name;
        Description = description;
    }
}