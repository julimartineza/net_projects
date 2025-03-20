using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UCR.ECCI.PI.Backend.Domain.Buildings.Repositories;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Repositories;
using UCR.ECCI.PI.Backend.Infrastructure.EntityBuilding.Repositories;
using UCR.ECCI.PI.Backend.Infrastructure.EntityLearningSpace.Repositories;
using UCR.ECCI.PI.Backend.Domain.Unit.Repositories;
using UCR.ECCI.PI.Backend.Infrastructure.EntityUnit.Repositories;
using UCR.ECCI.PI.Backend.Domain.LearningObjects.Repositories;
using UCR.ECCI.PI.Backend.Infrastructure.EntityLearningObject.Repositories;

using UCR.ECCI.PI.Backend.Domain.Users.Repositories;
using UCR.ECCI.PI.Backend.Infrastructure.EntityUser.Repositories;

using UCR.ECCI.PI.Backend.Domain.Trees.Repositories;
using UCR.ECCI.PI.Backend.Infrastructure.EntityTree.Repositories;


namespace UCR.ECCI.PI.Backend.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Method to register the services of the infrastructure layer.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterInfrastructureLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IBuildingRepository, BuildingRepository>();
            services.AddTransient<ILearningSpaceRepository, LearningSpaceRepository>();
            services.AddTransient<IPhysicalUnitRepository, PhysicalUnitRepository>();
            services.AddTransient<IAdministrativeUnitRepository, AdministrativeUnitRepository>();
            services.AddTransient<ILearningObjectRepository, LearningObjectRepository>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();

            services.AddTransient<ITreeRepository, TreeRepository>();


            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Scoped
            );

            return services;
        }
    }
}
