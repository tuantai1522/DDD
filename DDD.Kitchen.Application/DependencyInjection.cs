using DDD.Kitchen.Application.Behaviours;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DDD.Kitchen.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            options.AddOpenBehavior(typeof(ValidationPipelineBehaviour<,>));
        });

        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));
         
        return services;
    }
}