namespace UCR.ECCI.PI.frontend.Domain.Value_Objects
{
    /// <summary>
    /// Value Object for Characteristic of the buildings
    /// </summary>
    public class Characteristics
    {
        public string Name { get; }
        public string Description { get; }
        public string ID { get; }
        public string Color { get; }
        public string Acronym { get; }

        public Characteristics(string name, string description, string id, string color, string acronym)
        {
            Name = name;
            Description = description;
            ID = id;
            Color = color;
            Acronym = name;
        }

    }
}