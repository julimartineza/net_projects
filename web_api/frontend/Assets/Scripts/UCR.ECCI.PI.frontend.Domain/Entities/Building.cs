using UCR.ECCI.PI.frontend.Domain.Value_Objects;

namespace UCR.ECCI.PI.frontend.Unity.Domain
{
    public class Building
    {
        // Start Value objects and new properties

        public bool Status { get; }
        public string Type { get; }
        public int floors { get; }

        //Scale
        public Scale Scale { get; }

        //Rotation
        public Rotation Rotation { get; }

        //Location
        public Location Location { get; }

        //Characteristics
        public Characteristics Characteristics { get; }

        //  End Value objects


        public Building(bool status, string type, Scale scale, Rotation rotation, Location location, Characteristics characteristics, int floors)
        {
            this.Status = status;
            this.Type = type;
            this.Scale = scale;
            this.Rotation = rotation;
            this.Location = location;
            this.Characteristics = characteristics;
            this.floors = floors;
        }
    }
}