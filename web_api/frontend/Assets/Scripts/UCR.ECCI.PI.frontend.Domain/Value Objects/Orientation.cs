namespace UCR.ECCI.PI.frontend.Domain.Value_Objects
{
    /// <summary>
    /// Value Object for Rotate of the buildings
    /// </summary>
    public class Rotation
    {
        public float RotW { get; }
        public float RotX { get; }
        public float RotY { get; }
        public float RotZ { get; }

        public Rotation(float rotW, float rotX, float rotY, float rotZ)
        {
            RotW = rotW;
            RotX = rotX;
            RotY = rotY;
            RotZ = rotZ;
        }
    }
}
