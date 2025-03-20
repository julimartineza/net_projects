using Zenject;
using UCR.ECCI.PI.frontend.Unity.Application;
using UCR.ECCI.PI.frontend.Unity.Infrastructure;

namespace UCR.ECCI.PI.frontend.Unity.DependencyInjection
{
    public class CleanArchitectureInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            ApplicationLayerInstaller.Install(Container);
            InfrastructureLayerInstaller.Install(Container);
        }
    }
}