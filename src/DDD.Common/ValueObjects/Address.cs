namespace DDD.Domain.ValueObjects;

/// <summary>
/// Value object of address
/// </summary>
public record Address
{
    public string Street { get; init; }
    public string? ZipCode { get; init; }
    public string Country { get; init; }

    private Address()
    {
        
    }

    private Address(string street, string zipCode, string country)
    {
        Street = street;
        ZipCode = zipCode;
        Country = country;
    }

    public static Result<Address> Create(string street, string zipCode, string country)
    {
        return new Address(street, zipCode, country);
    }
}