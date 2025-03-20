using System.Diagnostics.CodeAnalysis;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.ValueObjects;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.LearningSpaces.Entities;

[ExcludeFromCodeCoverage]
public class LearningSpaceValueObjectsFixture
{
    private const string kName = "Lab 4-6";
    private const string kDescription = "PIISBD Lab";
    private const decimal kScaleX = 1;
    private const decimal kScaleY = 1;
    private const decimal kScaleZ = 1;
    private const string kTypeLS = "Laboratorio";
    private const int kFloor = 4;
    private const string kBuildingId = "ANNEXECCI";

    public Name Name { get; }
    public Description Description { get; }
    public Scale ScaleX { get; }
    public Scale ScaleY { get; }
    public Scale ScaleZ { get; }
    public TypeLS TypeLS { get; }
    public Floor Floor { get; set; }
    public BuildingId BuildingId { get; }

    public LearningSpaceValueObjectsFixture()
    {
        Name = Name.Create(kName);
        Description = Description.Create(kDescription);
        ScaleX = Scale.Create(kScaleX);
        ScaleY = Scale.Create(kScaleY);
        ScaleZ = Scale.Create(kScaleZ);
        TypeLS = TypeLS.Create(kTypeLS);
        Floor = Floor.Create(kFloor);
        BuildingId = BuildingId.Create(kBuildingId);
    }
}
