using UCR.ECCI.PI.frontend.Domain.Value_Objects;

namespace UCR.ECCI.PI.frontend.Unity.Domain.Events
{
    public class UserMovementEvent : IEvent
    {
        public Location NewPosition { get; }
        public Location Direction { get; }

        public UserMovementEvent(Location newPosition, Location direction)
        {
            NewPosition = newPosition;
            Direction = direction;
        }
    }
}
