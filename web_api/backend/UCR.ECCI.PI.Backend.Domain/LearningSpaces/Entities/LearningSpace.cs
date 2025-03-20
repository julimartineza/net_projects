using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.ValueObjects;

namespace UCR.ECCI.PI.Backend.Domain.LearningSpaces.Entities;


/// <summary>
/// Represents a learning space in the system.
/// </summary>
public class LearningSpace
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LearningSpace"/> class.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="scaleX"></param>
    /// <param name="scaleY"></param>
    /// <param name="scaleZ"></param>
    /// <param name="typeLS"></param>
    /// <param name="floor"></param>
    /// <param name="buildingId"></param>
    public LearningSpace(
        Name name,
        Description description,
        Scale scaleX,
        Scale scaleY,
        Scale scaleZ,
        TypeLS typeLS,
        Floor floor,
        BuildingId buildingId
        )
    {
        Name = name;
        Description = description;
        ScaleX = scaleX;
        ScaleY = scaleY;
        ScaleZ = scaleZ;
        TypeLS = typeLS;
        Floor = floor;
        BuildingId = buildingId;
    }

    public Name Name { get; }
    public Description Description { get; }
    public Scale ScaleX { get; }
    public Scale ScaleY { get; }
    public Scale ScaleZ { get; }
    public TypeLS TypeLS { get; }
    public Floor Floor { get; }
    public BuildingId BuildingId { get; }
}

