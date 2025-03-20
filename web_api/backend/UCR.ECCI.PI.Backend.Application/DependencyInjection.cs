using Microsoft.Extensions.DependencyInjection;
using UCR.ECCI.PI.Backend.Application.BuildingServices;
using UCR.ECCI.PI.Backend.Application.BuildingServices.Implementations;
using UCR.ECCI.PI.Backend.Application.LearningObjectServices;
using UCR.ECCI.PI.Backend.Application.LearningObjectServices.Implementations;
using UCR.ECCI.PI.Backend.Application.LearningSpacesServices;
using UCR.ECCI.PI.Backend.Application.LearningSpacesServices.Implementations;
using UCR.ECCI.PI.Backend.Application.TreeServices;
using UCR.ECCI.PI.Backend.Application.TreeServices.Implementations;
using UCR.ECCI.PI.Backend.Application.UnitServices;
using UCR.ECCI.PI.Backend.Application.UnitServices.Implementations;
using UCR.ECCI.PI.Backend.Application.UserServices.Implementations;
using UCR.ECCI.PI.Backend.Application.UserServices;

namespace UCR.ECCI.PI.Backend.Application;

// <summary>
// Represents the dependency injection for the application layer.
// </summary>
public static class DependencyInjection
{
    // <summary>
    // Registers the services of the application layer.
    // </summary>
    // <param name="services">The services collection to register the services.</param>
    public static IServiceCollection RegisterApplicationLayerServices(this IServiceCollection services)
    {
        services.AddTransient<IBuildingService, BuildingService>();
        services.AddTransient<ILearningSpaceService, LearningSpaceService>();
        services.AddTransient<IPhysicalUnitService, PhysicalUnitService>();
        services.AddTransient<IAdministrativeUnitService, AdministrativeUnitService>();
        services.AddTransient<ILearningObjectService, LearningObjectService>();
        services.AddTransient<IPersonService, PersonService>();
        services.AddTransient<IUserService, UserService>();


        services.AddTransient<ITreeService, TreeService>();

        return services;
    }
}
