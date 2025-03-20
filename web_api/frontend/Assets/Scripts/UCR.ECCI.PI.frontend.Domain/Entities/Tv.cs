using System.Collections;
using System.Collections.Generic;
using UCR.ECCI.PI.frontend.Domain.Value_Objects;

namespace UCR.ECCI.PI.frontend.Unity.Domain
{
    public class Tv : Learning_Object
    {
        public Tv(string id, string type, Scale scale, Rotation rotation, Location location, string nameLS)
            : base(id, type, scale, rotation, location, nameLS)
        {
            // Tv starts off
            StatusTv = false;
        }

        public bool StatusTv { get; set; } 
    }
}
