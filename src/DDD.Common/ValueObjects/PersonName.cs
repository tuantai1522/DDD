namespace DDD.Domain.ValueObjects;

/// <summary>
/// Value object of name
/// </summary>
/// <param name="FirstName"></param>
/// <param name="LastName"></param>
/// <param name="MiddleName"></param>
public record PersonName(string FirstName, string LastName, string MiddleName);