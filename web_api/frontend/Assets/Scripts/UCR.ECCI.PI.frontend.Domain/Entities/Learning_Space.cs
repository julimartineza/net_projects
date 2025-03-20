using UCR.ECCI.PI.frontend.Domain.Value_Objects;

namespace UCR.ECCI.PI.frontend.Unity.Domain
{
    public class Learning_Space
    {
        // Start Value objects and new properties
        public string Name { get; }
        public string Type { get; }

        //Scale
        public Scale Scale { get; }

        //Rotation
        public Rotation Rotation { get; }

        //Location
        public Location Location { get; }

        //  End Value objects


        public Learning_Space(string name, Scale scale)
        {
            this.Name = name;
            this.Scale = scale;
        }
    }
}