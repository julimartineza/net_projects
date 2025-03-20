using UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

namespace UCR.ECCI.PI.Backend.Domain.Unit.Entities;

/// <summary>
/// Represents an administrative unit in the system.
/// </summary>
/// <param> </param>
public class AdministrativeUnit
{
    /// <summary>
    /// Intializes a new instance of the <see cref="AdministrativeUnit"/> class.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="administrativeUnitType"></param>
    /// <param name="supervisedBy"></param>
    /// <param name="status"></param>
    public AdministrativeUnit(
        Name name,
        AdministrativeUnitType administrativeUnitType,
        Supervisor supervisedBy,
        bool status)
    {
        Name = name;
        AdministrativeUnitType = administrativeUnitType;
        SupervisedBy = supervisedBy;
        Status = status;
    }

    public Name Name { get; }
    public AdministrativeUnitType AdministrativeUnitType { get; }
    public Supervisor SupervisedBy { get; }
    public bool Status { get; set; }
}
