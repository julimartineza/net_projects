using UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

namespace UCR.ECCI.PI.Backend.Domain.Unit.Entities;


/// <summary>
/// Represents the location of an administrative unit in a building.
/// </summary>
public class AdministrativeUnitLocation
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AdministrativeUnitLocation"/> class.
    /// </summary>
    /// <param name="administrativeUnitName"></param>
    /// <param name="buildingId"></param>
    public AdministrativeUnitLocation(
        Name administrativeUnitName,
        Id buildingId)
    {
        AdministrativeUnitName = administrativeUnitName;
        BuildingId = buildingId;
    }

    public Name AdministrativeUnitName { get; }
    public Id BuildingId { get; }
}
