namespace DDD.Domain;

public interface IValidationResult
{
    public static readonly Error ValidationError = new(
        "ValidationError",
        "A validation error has occurred."
    );
    
    Error[] Errors { get; }
}