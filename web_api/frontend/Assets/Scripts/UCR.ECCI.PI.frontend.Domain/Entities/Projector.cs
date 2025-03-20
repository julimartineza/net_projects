using System.Collections;
using System.Collections.Generic;
using UCR.ECCI.PI.frontend.Domain.Value_Objects;

namespace UCR.ECCI.PI.frontend.Unity.Domain
{
    public class Projector : Learning_Object
    {
        public Projector(string id, string type, Scale scale, Rotation rotation, Location location, string nameLS)
            : base(id, type, scale, rotation, location, nameLS)
        {
            // Projector starts off
           ProjectorStatus = false;
        }

        public bool ProjectorStatus { get; set; } 
    }
}
