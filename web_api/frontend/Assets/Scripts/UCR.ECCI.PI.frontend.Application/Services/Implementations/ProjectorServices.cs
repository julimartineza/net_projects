using UCR.ECCI.PI.frontend.Unity.Domain;

namespace UCR.ECCI.PI.frontend.Unity.Application.Implementations
{
    public class ProjectorServices : IProjectorService
    {
        private readonly IProjectorRepository _projector;

        public ProjectorServices(IProjectorRepository projector)
        {
            _projector = projector;
        }

        public void ChangeStatus()
        {
            _projector.ChangeStatus(); 
        }
        
        public bool IsOn()
        {
            return _projector.IsOn();
        }
    }
}
