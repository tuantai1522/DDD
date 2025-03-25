using Bogus;
using DDD.Kitchen.Domain.Aggregate;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Kitchen.Infrastructure;

public sealed class KitchenDbContextInitializer(KitchenDbContext context)
{
    private readonly KitchenDbContext _context = context;

    public async Task InitializeAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while seeding the database.", ex);
        }
    }

    private async Task TrySeedAsync()
    {
        if (_context.Restaurants.Any())
            return;

        // Configure faker for MenuItem
        var menuItemFaker = new Faker<MenuItem>()
            .CustomInstantiator(f => MenuItem.Create(
                name: f.Commerce.ProductName(),
                price: decimal.Parse(f.Commerce.Price(min: 1, max: 100)),
                restaurantId: new RestaurantId(Guid.Empty)).Value); // Will be set when adding to restaurant

        // Configure faker for Restaurant
        var restaurantFaker = new Faker<Restaurant>();
        var restaurants = restaurantFaker
            .CustomInstantiator(f =>
            {
                var result = Restaurant.Create(f.Company.CompanyName(), f.Address.StreetName(), f.Address.ZipCode(), f.Address.Country());
                var restaurant = result.Value;
                
                // Add 3-7 menu items per restaurant
                var menuItems = menuItemFaker.Generate(f.Random.Int(30, 70));
                foreach (var menuItem in menuItems)
                {
                    restaurant.AddMenuItem(menuItem);
                }
                
                return restaurant;
            })
            .Generate(100); // Generate 10 restaurants

        await _context.Restaurants.AddRangeAsync(restaurants);
        await _context.SaveChangesAsync();
    }
}

public static class InitializerExtensions
{
    public static async Task InitializeDatabaseAsync(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var initializer = scope.ServiceProvider.GetRequiredService<KitchenDbContextInitializer>();
        await initializer.InitializeAsync(); // Changed from SeedAsync to InitializeAsync
    }
}






