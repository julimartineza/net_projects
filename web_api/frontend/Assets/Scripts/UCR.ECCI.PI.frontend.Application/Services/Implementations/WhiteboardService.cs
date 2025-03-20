using UCR.ECCI.PI.frontend.Unity.Application.Services;

namespace UCR.ECCI.PI.frontend.Unity.Application
{
    public class WhiteboardService : IWhiteboardService
    {
        private bool status;

        public void BlockWhiteboard()
        {
            status = !status;
        }

        public bool IsAvailable()
        {
            return status;
        }
    }
}