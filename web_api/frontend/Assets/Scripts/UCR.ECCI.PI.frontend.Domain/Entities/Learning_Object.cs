using UCR.ECCI.PI.frontend.Domain.Value_Objects;

namespace UCR.ECCI.PI.frontend.Unity.Domain
{
    public class Learning_Object
    {
        // Start Value objects and new properties

        public string Id { get; }
        public string Type { get; }

        //Scale
        public Scale Scale { get; }

        //Rotation
        public Rotation Rotation { get; }

        //Location
        public Location Location { get; }

        public string LearningSpaceName { get; }

        //  End Value objects


        public Learning_Object(string id, string type, Scale scale, Rotation rotation, Location location, string learningSpaceName)
        {
            this.Id = id;
            this.Type = type;
            this.Scale = scale;
            this.Rotation = rotation;
            this.Location = location;
            this.LearningSpaceName = learningSpaceName;
        }
    }
}