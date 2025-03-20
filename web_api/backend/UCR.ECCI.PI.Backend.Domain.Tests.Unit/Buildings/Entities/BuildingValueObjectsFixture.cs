using System.Diagnostics.CodeAnalysis;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Unit.Entities;

[ExcludeFromCodeCoverage]
public class BuildingValueObjectsFixture
{
    private const string kId = "ECCIANNEX";
    private const string kName = "Annex";
    private const string kAcronym = "AN";
    private const string kDescription = "Secondary Building of computer school";
    private const string kPhysicalUnit = "Finca 1";
    private const string kColor = "Grey";
    private const decimal kLocationX = 318.7m;
    private const decimal kLocationY = 3.25m;
    private const decimal kLocationZ = 162.0m;
    private const decimal kScaleX = 13.5099m;
    private const decimal kScaleY = 5.0m;
    private const decimal kScaleZ = 36.4422m;
    private const decimal kRotationW = 0.0m;
    private const decimal kRotationX = 0.0m;
    private const decimal kRotationY = 23.946m;
    private const decimal kRotationZ = 0.0m;
    private const string kTypeBuilding = "School";
    private const bool kStatus = true;
    private const int kFloors = 6;

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

    public BuildingValueObjectsFixture()
    {
        Id = Id.Create(kId);
        Name = Name.Create(kName);
        Acronym = Name.Create(kAcronym);
        Description = Description.Create(kDescription);
        PhysicalUnitName = Name.Create(kPhysicalUnit);
        Color = Color.Create(kColor);
        LocationX = Coordinate.Create(kLocationX);
        LocationY = Coordinate.Create(kLocationY);
        LocationZ = Coordinate.Create(kLocationZ);
        ScaleX = Dimensions.Create(kScaleX);
        ScaleY = Dimensions.Create(kScaleY);
        ScaleZ = Dimensions.Create(kScaleZ);
        RotationW = Coordinate.Create(kRotationW);
        RotationX = Coordinate.Create(kRotationX);
        RotationY = Coordinate.Create(kRotationY);
        RotationZ = Coordinate.Create(kRotationZ);
        TypeBuilding = TypeBuilding.Create(kTypeBuilding);
        Status = kStatus;
        Floors = Floors.Create(kFloors);
    }
}
