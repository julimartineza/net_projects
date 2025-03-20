using System.Numerics;

namespace UCR.ECCI.PI.frontend.Unity.Infrastructure
{
    public class LearningSpaceDto
    {
        public string name { get; set; }
        public string description { get; set; }
        public float scaleX { get; set; }
        public float scaleY { get; set; }
        public float scaleZ { get; set; }
        public string typeLS { get; set; }
        public int floor { get; set; }
        public string buildingId { get; set; }

    }
}
