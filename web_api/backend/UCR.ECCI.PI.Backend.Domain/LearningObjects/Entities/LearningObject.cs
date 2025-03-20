using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.ValueObjects;

namespace UCR.ECCI.PI.Backend.Domain.LearningObjects.Entities;

/// <summary>
/// Represents a learning object
/// </summary>
public class LearningObject
{
    /// <summary>
    /// Constructor for LearningObject
    /// </summary>
    /// <param name="id"></param>
    /// <param name="typeLO"></param>
    /// <param name="locationX"></param>
    /// <param name="locationY"></param>
    /// <param name="locationZ"></param>
    /// <param name="scaleX"></param>
    /// <param name="scaleY"></param>
    /// <param name="scaleZ"></param>
    /// <param name="rotationW"></param>
    /// <param name="rotationX"></param>
    /// <param name="rotationY"></param>
    /// <param name="rotationZ"></param>
    /// <param name="learningSpaceName"></param>
    public LearningObject(
        Id id,
        TypeLS typeLO,
        Coordinate locationX,
        Coordinate locationY,
        Coordinate locationZ,
        Dimensions scaleX,
        Dimensions scaleY,
        Dimensions scaleZ,
        Coordinate rotationW,
        Coordinate rotationX,
        Coordinate rotationY,
        Coordinate rotationZ,
        Name learningSpaceName
        )
    {
        Id = id;
        TypeLO = typeLO;
        LocationX = locationX;
        LocationY = locationY;
        LocationZ = locationZ;
        ScaleX = scaleX;
        ScaleY = scaleY;
        ScaleZ = scaleZ;
        RotationW = rotationW;
        RotationX = rotationX;
        RotationY = rotationY;
        RotationZ = rotationZ;
        LearningSpaceName = learningSpaceName;
    }

    public Id Id { get; }
    public TypeLS TypeLO { get; }
    public Coordinate LocationX { get; }
    public Coordinate LocationY { get; }
    public Coordinate LocationZ { get; }
    public Dimensions ScaleX { get; }
    public Dimensions ScaleY { get; }
    public Dimensions ScaleZ { get; }
    public Coordinate RotationW { get; }
    public Coordinate RotationX { get; }
    public Coordinate RotationY { get; }
    public Coordinate RotationZ { get; }
    public Name LearningSpaceName { get; }
}