using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace UCR.ECCI.PI.frontend.Unity.Infrastructure
{
    public record TreeDto 
    {
        public int Id { get; set;  }
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public double LocationZ { get; set; }
        public double Scale { get; set; }
    }
}
