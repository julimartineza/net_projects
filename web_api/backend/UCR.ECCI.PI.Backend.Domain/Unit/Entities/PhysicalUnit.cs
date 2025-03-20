using UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

namespace UCR.ECCI.PI.Backend.Domain.Unit.Entities;

/// <summary>
/// Represents a physical unit in the system.
/// </summary>
public class PhysicalUnit
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PhysicalUnit"/> class.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="physicalUnitType"></param>
    /// <param name="locatedIn"></param>
    /// <param name="status"></param>
    public PhysicalUnit(
        Name name,
        PhysicalUnitType physicalUnitType,
        LocatedIn locatedIn,
        bool status)
    {
        Name = name;
        PhysicalUnitType = physicalUnitType;
        LocatedIn = locatedIn;
        Status = status;
    }

    public Name Name { get; }
    public PhysicalUnitType PhysicalUnitType { get; }
    public LocatedIn LocatedIn { get; }
    public bool Status { get; set; }
}

