using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UCR.ECCI.PI.Backend.Infrastructure;
using UCR.ECCI.PI.Backend.Application;

namespace UCR.ECCI.PI.Backend.DependencyInjection;

public static class CleanArchitectureExtensions
{
    /// <summary>
    /// Method to register the services of the clean architecture.
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection RegisterCleanArchitectureServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.RegisterInfrastructureLayerServices(configuration);
        services.RegisterApplicationLayerServices();
    
        return services;
    }

}
