namespace DDD.Kitchen.Application.Restaurants.Commands.CreateRestaurant;

public sealed record CreateRestaurantRequest(string Name, string Street, string ZipCode, string Country);
