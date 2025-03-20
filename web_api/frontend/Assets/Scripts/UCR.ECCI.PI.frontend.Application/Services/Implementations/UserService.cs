using UCR.ECCI.PI.frontend.Unity.Domain;
using UCR.ECCI.PI.frontend.Unity.Domain.Events; 
using Zenject;


namespace UCR.ECCI.PI.frontend.Unity.Application.Services.Implementations
{
    internal class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IEventChannel _eventChannel;

        public UserService(IUserRepository userRepository, IEventChannel eventChannel)
        {
            _userRepository = userRepository;
            _eventChannel = eventChannel;
        }

        public void UpdatePositionAsync(User user)
        {
            _eventChannel.Publish(new UserMovementEvent(user.Location,user.Location));
        }
    }
}
