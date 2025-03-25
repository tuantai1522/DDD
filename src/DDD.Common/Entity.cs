namespace DDD.Domain;

public abstract class Entity
{
    /// <summary>
    /// Active is status of this item
    /// </summary>
    public bool Active { get; private set; } = true;
    
    private readonly List<IDomainEvent> _domainEvents = [];
    
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;
    
    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}
