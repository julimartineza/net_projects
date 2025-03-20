using Zenject;
using UCR.ECCI.PI.frontend.Unity.Domain;

namespace UCR.ECCI.PI.frontend.Unity.Infrastructure
{
    public class InfrastructureLayerInstaller : Installer<InfrastructureLayerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IBuildingRepository>()
                .To<BuildingRepository>()
                .AsTransient();
            Container.Bind<ILearningSpaceRepository>()
                .To<LearningSpaceRepository>()
                .AsTransient();
            Container.Bind<ILearningObjectRepository>()
                .To<LearningObjectRepository>()
                .AsTransient();
            Container.Bind<ITvRepository>()
                .To<TvRepository>()
                .AsTransient();
            Container.Bind<IProjectorRepository>()
                .To<ProjectorRepository>()
                .AsTransient();
            Container.Bind<ITreeRepository>()
                .To<TreeRepository>()
                .AsTransient();
            Container.Bind<IWhiteboardRepository>()
                .To<WhiteboardRepository>()
                .AsTransient();
            Container.Bind < IEventChannel>()
                .To<SignalEventChannel>()
                .AsSingle();

            SignalBusInstaller.Install(Container);

            DeclareSignals();    
        }

        public void DeclareSignals()
        {
            Container.DeclareSignal<ConnectionSuccessEvent>();
            Container.DeclareSignal<ConnectionFailedEvent>();
        }
    }
}
