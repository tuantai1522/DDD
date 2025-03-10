using DDD.Kitchen.Application.Behaviours;
using FluentValidation;
using MediatR;

namespace DDD.Kitchen.WebApi.Configuration;

public class ApplicationServiceInstaller : IServiceInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehaviour<,>));

        services.AddValidatorsFromAssembly(
            Application.AssemblyReference.Assembly, 
            includeInternalTypes: true
        );
        
        services.AddMediatR(config => config.RegisterServicesFromAssembly(Application.AssemblyReference.Assembly));

    }
}