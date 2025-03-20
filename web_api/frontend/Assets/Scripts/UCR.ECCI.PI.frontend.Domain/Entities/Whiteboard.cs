using System.Collections;
using System.Collections.Generic;
using UCR.ECCI.PI.frontend.Domain.Value_Objects;

namespace UCR.ECCI.PI.frontend.Unity.Domain
{
    public class Whiteboard : Learning_Object
    {
        public Whiteboard(string id, string type, Scale scale, Rotation rotation, Location location, string nameLS)
            : base(id, type, scale, rotation, location, nameLS)
        {
            // Whiteboard starts off
            StatusWhiteboard = false;
        }

        public bool StatusWhiteboard { get; set; }
    }
}