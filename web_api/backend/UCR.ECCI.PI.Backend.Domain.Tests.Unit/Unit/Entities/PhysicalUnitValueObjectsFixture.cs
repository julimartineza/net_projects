using UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using System.Reflection.Metadata;
using System.Diagnostics.CodeAnalysis;

namespace UCR.ECCI.PI.Backend.Domain.Tests.Unit.Unit.Entities;

[ExcludeFromCodeCoverage]
public class PhysicalUnitValueObjectsFixture
{
    private const string kName = "Rodrigo Facio";
    private const string kPhysicalUnitType = "Classroom";
    private const string kLocatedIn = "UCR";
    private const bool kStatus = true;

    public Name Name { get; }
    public PhysicalUnitType PhysicalUnitType { get; }
    public LocatedIn LocatedIn { get; }
    public bool Status { get; }

    public PhysicalUnitValueObjectsFixture()
    {
        Name = Name.Create(kName);
        PhysicalUnitType = PhysicalUnitType.Create(kPhysicalUnitType);
        LocatedIn = LocatedIn.Create(kLocatedIn);
        Status = kStatus;
    }
}
