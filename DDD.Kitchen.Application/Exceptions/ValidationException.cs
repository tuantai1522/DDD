using DDD.Domain;

namespace DDD.Kitchen.Application.Exceptions;

public class ValidationException(Error[] errors) : Exception("Validation error occurred")
{
    public Error[] Errors { get; } = errors;
}

