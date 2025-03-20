namespace UCR.ECCI.PI.frontend.Unity.Domain.Assets.Scripts.UCR.ECCI.PI.frontend.Domain.Value_Objects

// <Summary>
// This class is meant to be used as a value of the buildings that will be used for dimensions of the objects on the interactive map
// </Summary>
{
    public class Dimensions
    {
        public float Large { get; }
        public float Width { get; }
        public float Height { get; }

        public Dimensions(float large, float width, float height)
        {
            Large = large;
            Width = width;
            Height = height;
        }


    }
}
