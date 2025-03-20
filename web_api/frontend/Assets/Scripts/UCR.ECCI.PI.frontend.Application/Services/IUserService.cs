using UCR.ECCI.PI.frontend.Unity.Domain;

namespace UCR.ECCI.PI.frontend.Unity.Application
{
    public interface IUserService 
    {
        void UpdatePositionAsync(User user);
    }
}
