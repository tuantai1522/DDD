using System.ComponentModel.DataAnnotations;

namespace DDD.Domain;

public class Entity : IBaseEntity<Guid>

{
    /// <summary>
    /// Initialize a new instance of the Aggregate class
    /// </summary>
    protected Entity() => Id = Guid.NewGuid();

    /// <summary>
    /// Get the unique identifier of this entity
    /// </summary>
    [Key]
    [Required]
    public Guid Id { get; private init; }
    
    /// <summary>
    /// Created At is the time when item created
    /// </summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// Created By is the name of whom which created item
    /// </summary>
    [MaxLength(100)]
    public string? CreatedBy { get; init; }

    /// <summary>
    /// Updated At is the time when item was updated with the latest time
    /// </summary>
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Updated By is the name of whom which updated item
    /// </summary>
    [MaxLength(100)]
    public string? UpdatedBy { get; private set; }

    /// <summary>
    /// Active is status of this item
    /// </summary>
    public bool Active { get; private set; } = true;
    
    private readonly List<IDomainEvent> _domainEvents = [];
    
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;
    
    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    
    /// <summary>
    /// Define who update this item
    /// </summary>
    /// <param name="updatedBy">
    /// PersonName of person who updates this item
    /// </param>
    public void SetUpdatedBy(string updatedBy) => UpdatedBy = updatedBy;
    
    /// <summary>
    /// Define this item active or not
    /// </summary>
    /// <param name="active">
    /// Active of this item
    /// </param>
    public void SetActive(bool active) => Active = active;

}
