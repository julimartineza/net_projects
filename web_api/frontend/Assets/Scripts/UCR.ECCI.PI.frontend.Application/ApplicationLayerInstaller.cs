using System.ComponentModel;
using UCR.ECCI.PI.frontend.Unity.Application.Implementations;
using UCR.ECCI.PI.frontend.Unity.Application.Services;
using Zenject;

namespace UCR.ECCI.PI.frontend.Unity.Application
{
    public class ApplicationLayerInstaller : Installer<ApplicationLayerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IBuildingService>()
                .To<BuildingService>()
                .AsTransient();
            Container.Bind<ILearningSpaceService>()
                .To<LearningSpaceService>()
                .AsTransient();
            Container.Bind<ILearningObjectService>()
                .To<LearningObjectService>()
                .AsTransient();
            Container.Bind<ITvService>()
               .To<TvServices>()
               .AsTransient();
            Container.Bind<IWhiteboardService>()
               .To<WhiteboardService>()
               .AsTransient();
            Container.Bind<IProjectorService>()
              .To<ProjectorServices>()
              .AsTransient();
            Container.Bind<ITreeService>()
                .To<TreeService>()
                .AsTransient();
        }
    }
}