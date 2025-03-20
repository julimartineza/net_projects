using UCR.ECCI.PI.frontend.Domain.Value_Objects;
namespace UCR.ECCI.PI.frontend.Unity.Domain
{
    public class User
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public Location Location { get; private set; }


        public User(string id, string name, Location location)
        {
            Id = id;
            Name = name;
            Location = location;
        }

        public void Move(Location direction)
        {
            Location = Location.Add(direction);
        }
    }
}
