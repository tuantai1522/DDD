using DDD.Kitchen.Domain.Aggregate;
using DDD.Kitchen.Infrastructure;
using DDD.Kitchen.Infrastructure.Interceptors;
using DDD.Kitchen.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DDD.Kitchen.WebApi.Configuration;

public class InfrastructureServiceInstaller : IServiceInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<KitchenDbContext>(options =>
        {
            var auditableInterceptor = services.BuildServiceProvider().GetService<UpdateAuditableEntitiesInterceptor>();
            
            options
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .AddInterceptors(auditableInterceptor!);
                
        });
        
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        
        services.AddScoped<KitchenDbContextInitializer>();
        
        services.AddSingleton<UpdateAuditableEntitiesInterceptor>();

    }
}