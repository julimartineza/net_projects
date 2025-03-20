using UCR.ECCI.PI.frontend.Unity.Domain;

namespace UCR.ECCI.PI.frontend.Unity.Domain
{
    public class ConnectionFailedEvent:IEvent
    {
        public string ErrorMessage { get; }

        public ConnectionFailedEvent(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
