namespace UCR.ECCI.PI.frontend.Domain.Value_Objects
{
    /// <summary>
    /// Value Object for Location of the buildings
    /// </summary>
    public class Location
    {
        private float standartAdjustment = 1.8f;
        public float LocX { get; private set; }
        public float LocY { get; private set; }
        public float LocZ { get; private set; }

        public Location(float locX, float locY, float locZ)
        {
            LocX = locX;
            LocY = locY;
            LocZ = locZ;
        }

        public void setAltitude(float AltitudeGrowth)
        {
            LocY += AltitudeGrowth-standartAdjustment;
        }

        public Location Add(Location other)
        {
            return new Location(LocX + other.LocX, LocY + other.LocY, LocZ + other.LocZ);
        }
    }
}
