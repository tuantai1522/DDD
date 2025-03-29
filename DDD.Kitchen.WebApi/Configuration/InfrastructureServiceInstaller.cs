using DDD.Domain;
using DDD.Kitchen.Domain.Aggregate;
using DDD.Kitchen.Infrastructure;
using DDD.Kitchen.Infrastructure.Interceptors;
using DDD.Kitchen.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Hybrid;

namespace DDD.Kitchen.WebApi.Configuration;

public class InfrastructureServiceInstaller : IServiceInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        // Add cache
        services.AddStackExchangeRedisCache(option =>
        {
            string connectionString = configuration.GetConnectionString("Redis")!;

            option.Configuration = connectionString;
        });
        
        services.AddHybridCache(option =>
        {
            option.DefaultEntryOptions = new HybridCacheEntryOptions()
            {
                LocalCacheExpiration = TimeSpan.FromMinutes(5),
                Expiration = TimeSpan.FromMinutes(5)
            };
        });

        services.AddDbContextPool<KitchenDbContext>(options =>
        {
            var auditableInterceptor = services.BuildServiceProvider().GetService<UpdateAuditableEntitiesInterceptor>();
            
            options
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .AddInterceptors(auditableInterceptor!);
                
        });
        
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        services.Decorate<IRestaurantRepository, CachedRestaurantRepository>();
        
        services.AddScoped<KitchenDbContextInitializer>();
        
        services.AddSingleton<UpdateAuditableEntitiesInterceptor>();

    }
}