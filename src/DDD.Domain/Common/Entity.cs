using System.ComponentModel.DataAnnotations;

namespace DDD.Domain;

public class Entity
{
    /// <summary>
    /// Initialize a new instance of the Entity class
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
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

    /// <summary>
    /// Updated By is the name of whom which updated item
    /// </summary>
    [MaxLength(100)]
    public string? UpdatedBy { get; private set; }

    /// <summary>
    /// Active is status of this item
    /// </summary>
    public bool Active { get; private set; } = true;
    
    /// <summary>
    /// Define who update this item
    /// </summary>
    /// <param name="updatedBy">
    /// Name of person who updates this item
    /// </param>
    public void SetUpdatedBy(string updatedBy) => UpdatedBy = updatedBy;
    
    /// <summary>
    /// Define when to update this item
    /// </summary>
    /// <param name="updatedAt">
    /// Time when updates this item
    /// </param>
    public void SetUpdatedAt(DateTime updatedAt) => UpdatedAt = updatedAt;
    
    /// <summary>
    /// Define this item active or not
    /// </summary>
    /// <param name="active">
    /// Active of this item
    /// </param>
    public void SetActive(bool active) => Active = active;

}
