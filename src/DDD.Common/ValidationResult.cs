namespace DDD.Domain;

public sealed class ValidationResult(Error[] errors)
    : Result(false, IValidationResult.ValidationError), IValidationResult
{
    public Error[] Errors { get; } = errors;

    public static ValidationResult WithErrors(Error[] errors) => new(errors);
}

public sealed class ValidationResult<TValue> 
    : Result<TValue>, IValidationResult
{
    private ValidationResult(Error[] errors) : base(default, false, IValidationResult.ValidationError) => Errors = errors;
    
    public Error[] Errors { get; }

    public static ValidationResult<TValue> WithErrors(Error[] errors) => new(errors);
}