using System.Numerics;

namespace UCR.ECCI.PI.frontend.Unity.Infrastructure
{
    public class BuildingDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string acronym { get; set; }
        public string physicalUnitName { get; set; }
        public string description { get; set; }
        public string color { get; set; }
        public float locationx { get; set; }
        public float locationy { get; set; }
        public float locationz { get; set; }
        public float scalex { get; set; }
        public float scaley { get; set; }
        public float scalez { get; set; }
        public float rotationw { get; set; }
        public float rotationx { get; set; }
        public float rotationy { get; set; }
        public float rotationz { get; set; }
        public string typeBuilding { get; set; }
        public bool status { get; set; }
        public int floors { get; set; }
    }
}
