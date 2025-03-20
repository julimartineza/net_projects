using System.Data.SqlTypes;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;

namespace UCR.ECCI.PI.Backend.Domain.Buildings.Entities;

/// <summary>
/// Represents a building in the system.
/// </summary>
public class Building
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Building"/> class with physical characteristics.
    /// </summary>
    /// <param name="id">The identifier of the building.</param>
    /// <param name="name">The name of the building.</param>
    /// <param name="description">The description of the building.</param>
    /// <param name="color">The color of the building for .</param>
    /// <param name="latitude">The latitude coordinate of the building.</param>
    /// <param name="longitude">The longitude coordinate of the building.</param>
    /// <param name="length">The length of the building.</param>
    /// <param name="width">The width of the building.</param>
    /// <param name="orientation">The orientation of the building.</param>
    /// <param name="typeBuilding">The type of the building.</param>

    public Building(
        Id id,
        Name name,
        Name acronym,
        Description description,
        Name physicalUnitName,
        Color color,
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
        TypeBuilding typeBuilding,
        bool status,
        Floors floors
    )
    {
        Id = id;
        Name = name;
        Acronym = acronym;
        Description = description;
        PhysicalUnitName = physicalUnitName;
        Color = color;
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
        TypeBuilding = typeBuilding;
        Status = status;
        Floors = floors;
    }

    public Id Id { get; }
    public Name Name { get; }
    public Name Acronym { get; }
    public Description Description { get; }
    public Name PhysicalUnitName { get; }
    public Color Color { get; }
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
    public TypeBuilding TypeBuilding { get; }
    public bool Status { get; set; }
    public Floors Floors { get; }

}

