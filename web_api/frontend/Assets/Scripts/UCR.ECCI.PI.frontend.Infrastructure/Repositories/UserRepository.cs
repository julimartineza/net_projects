using System.Diagnostics;
using System.Threading.Tasks;
using UCR.ECCI.PI.frontend.Domain.Value_Objects;
using UCR.ECCI.PI.frontend.Unity.Domain;

namespace UCR.ECCI.PI.frontend.Unity.Infrastructure
{
    public class UserRepository : IUserRepository
    {
        public Task UpdatePositionAsync(Location newLocation)
        {
            // Handle position update (e.g., broadcasting to clients, logging, etc.)
            string value = "Position updated to: "+newLocation.LocX + newLocation.LocY + newLocation.LocZ;
            return Task.CompletedTask;
        }
    }
}
