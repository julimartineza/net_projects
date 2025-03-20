using System;
namespace UCR.ECCI.PI.frontend.Unity.Application.Services
{
    public interface IWhiteboardService
    {
        void BlockWhiteboard();
        bool IsAvailable();
    }
}
