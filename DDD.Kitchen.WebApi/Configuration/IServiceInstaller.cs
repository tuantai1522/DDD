namespace DDD.Kitchen.WebApi.Configuration;

public interface IServiceInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}