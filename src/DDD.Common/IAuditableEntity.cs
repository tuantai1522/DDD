using System.ComponentModel.DataAnnotations;

namespace DDD.Domain;

public interface IAuditableEntity
{
    /// <summary>
    /// Created At is the time when item created
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Created By is the name of whom which created item
    /// </summary>
    [MaxLength(100)]
    public string? CreatedBy { get; init; }

    /// <summary>
    /// Updated At is the time when item was updated with the latest time
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Updated By is the name of whom which updated item
    /// </summary>
    [MaxLength(100)]
    public string? UpdatedBy { get; }
}