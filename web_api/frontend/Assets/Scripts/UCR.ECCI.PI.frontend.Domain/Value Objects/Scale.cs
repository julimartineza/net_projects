namespace UCR.ECCI.PI.frontend.Domain.Value_Objects
{
    /// <summary>
    /// Value Object for Scale of the buildings
    /// </summary>
    public class Scale
    {
        public float ScaleX { get; }
        public float ScaleY { get; private set; }
        public float ScaleZ { get; }

        public Scale(float scaleX, float scaleY, float scaleZ)
        {
            ScaleX = scaleX;
            ScaleY = scaleY;
            ScaleZ = scaleZ;
        }

        public void setHeight(float newHeight)
        {
            ScaleY = newHeight;
        }
    }
}