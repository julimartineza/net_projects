namespace UCR.ECCI.PI.frontend.Unity.Domain
{

    public class Tree
    {
        public int Id { get; }
        public double LocationX { get; }
        public double LocationY { get; }
        public double LocationZ { get; }
        public double Scale { get; }

        public Tree(int id, double locationX, double locationY, double locationZ, double scale)
        {
            Id = id;
            LocationX = locationX;
            LocationY = locationY;
            LocationZ = locationZ;
            Scale = scale;
        }
    }
}
