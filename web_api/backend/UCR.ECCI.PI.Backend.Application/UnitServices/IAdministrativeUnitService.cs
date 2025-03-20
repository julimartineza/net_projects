using UCR.ECCI.PI.Backend.Application.UnitServices;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;
using UCR.ECCI.PI.Backend.Domain.Unit.Records;

namespace UCR.ECCI.PI.Backend.Application.UnitServices;

/// <summary>
/// Interface for the administrative unit service.
/// </summary>
public interface IAdministrativeUnitService
{
    /// <summary>
    /// Edit an administrative unit.
    /// </summary>
    /// <param name="newAdministrativeUnitparams"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public Task<int> EditAdministrativeUnitAsync(AdministrativeUnit newAdministrativeUnit);

    /// <summary>
    /// Set an administrative unit in the system.
    /// </summary>
    /// <param name="newAdministrativeUnit"></param>
    /// <returns></returns>
    public Task<int> SetAdministrativeUnitAsync(AdministrativeUnit newAdministrativeUnit, AdministrativeUnitLocation newAdministrativeUnitLocation);

    /// <summary>
    /// Change the status of an administrative unit.
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public Task<int> ChangeAdministrativeUnitStatusAsync(AdministrativeUnitActiveStatus status);
}