using DDD.Kitchen.Domain.Aggregate;
using DDD.Kitchen.Infrastructure;
using DDD.Kitchen.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DDD.Kitchen.WebApi.Configuration;

public class InfrastructureServiceInstaller : IServiceInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<KitchenDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        
        services.AddScoped<KitchenDbContextInitializer>();

    }
}