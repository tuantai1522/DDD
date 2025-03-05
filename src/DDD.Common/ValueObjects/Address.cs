namespace DDD.Domain.ValueObjects;

/// <summary>
/// Value object of address
/// </summary>
/// <param name="Street"></param>
/// <param name="ZipCode"></param>
/// <param name="Country"></param>

public record Address(string Street, string ZipCode, string Country);