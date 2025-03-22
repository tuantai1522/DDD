namespace DDD.Kitchen.Application.Restaurants.Commands.UpdateRestaurant;

public sealed record UpdateRestaurantRequest(string Name, string Street, string ZipCode, string Country);
