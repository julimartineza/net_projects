using System.Collections;
using System.Collections.Generic;

namespace UCR.ECCI.PI.frontend.Unity.Domain
{
    public interface IWhiteboardRepository
    {
        // public Whiteboard GetWhiteboard(string name);
        //Methods to use in the application layer (as services)
        public void ChangeStatus();
        public bool IsOn();
    }
}