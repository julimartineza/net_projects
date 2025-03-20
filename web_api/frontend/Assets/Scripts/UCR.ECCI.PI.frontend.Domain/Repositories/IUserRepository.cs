using System.Threading.Tasks;
using UCR.ECCI.PI.frontend.Domain.Value_Objects;

namespace UCR.ECCI.PI.frontend.Unity.Domain
{
    public interface IUserRepository 
    {
        Task UpdatePositionAsync(Location location);
    }
}
