using UCR.ECCI.PI.Backend.Domain.Buildings.Entities;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;
using UCR.ECCI.PI.Backend.Domain.Unit.Records;

namespace UCR.ECCI.PI.Backend.Domain.Unit.Repositories;

public interface IAdministrativeUnitRepository
{
    /// <summary>
    /// Method to list all administrative units.
    /// </summary>
    /// <param name="administrativeUnit"></param>
    /// <returns> 0 when edited successful</returns>
    public Task<int> EditAdministrativeUnitAsync(AdministrativeUnit administrativeUnit);

    /// <summary>
    /// Method to edit administrative unit location
    /// </summary>
    /// <param name="administrativeUnit"></param>
    /// <returns> 0 when edited successful</returns>
    public Task<int> EditAdministrativeUnitLocationAsync(AdministrativeUnitLocation administrativeUnitLocation);

    /// <summary>
    /// Method to set an administrative unit.
    /// </summary>
    /// <param name="administrativeUnit"></param>
    /// <returns> 0 when successful </returns>
    public Task<int> SetAdministrativeUnitAsync(AdministrativeUnit administrativeUnit);

    /// <summary>
    /// Method to set the location of an administrative unit.
    /// </summary>
    /// <param name="administrativeUnitLocation"></param>
    /// <returns> 0 when successful </returns>
    public Task<int> SetAdministrativeUnitLocationAsync(AdministrativeUnitLocation administrativeUnitLocation);

    /// <summary>
    /// Method to list all administrative units hierarchies.
    /// </summary>
    /// <returns> list of the administrative hierarchy </returns>
    public Task<IEnumerable<AdministrativeHierarchyResult>> ListAdministrativeUnitHierarchiesAsync();

    /// <summary>
    /// Method to set the status of an administrative unit.
    /// </summary>
    /// <param name="active"></param>
    /// <returns> 0 when successful </returns>
    public Task<int> SetAdministrativeUnitStatus(AdministrativeUnitActiveStatus active);
}