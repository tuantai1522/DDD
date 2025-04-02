using DDD.Domain;

namespace DDD.Kitchen.Application.Restaurants;

/// <summary>
/// Contains error definitions related to Restaurant operations.
/// </summary>
public static class RestaurantErrors
{
    /// <summary>
    /// Generates an error indicating that the restaurant ID was not found.
    /// </summary>
    /// <param name="id">The ID of the restaurant that was not found.</param>
    /// <returns>An <see cref="Error"/> object with the error details.</returns>
    public static Error NotFound(Guid id) => Error.NotFound("404", $"Restaurant Id: {id} can not found");
    
    
    /// <summary>
    /// Error indicating that the query to get restaurants could not be decoded.
    /// </summary>
    public static Error CanNotFindQuery = Error.BadRequest("400", $"Can not decode query to get restaurants");

}