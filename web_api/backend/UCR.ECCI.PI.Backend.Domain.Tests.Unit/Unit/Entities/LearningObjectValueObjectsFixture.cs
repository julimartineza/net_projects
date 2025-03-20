using System.Diagnostics.CodeAnalysis;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.ValueObjects;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Unit.Entities;

[ExcludeFromCodeCoverage]
public class LearningObjectValueObjectsFixture
{
    public Id Id { get; }
    public TypeLS TypeLO { get; }
    public Coordinate Coordinate { get; }
    public Dimensions Dimensions { get; }
    public Name Name { get; }
    public LearningObjectValueObjectsFixture()
    {
        Id = Id.Create("TV1");
        TypeLO = TypeLS.Create("TV");
        Coordinate = Coordinate.Create(1);
        Dimensions = Dimensions.Create(1);
        Name = Name.Create("TV1");

    }
}
