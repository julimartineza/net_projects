using UCR.ECCI.PI.Backend.Domain.Unit.Entities;
using UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Unit.Repositories;
using Id = UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects.Id;
using UCR.ECCI.PI.Backend.Domain.Unit.Records;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

namespace UCR.ECCI.PI.Backend.Application.UnitServices.Implementations;

/// <summary>
/// Represents the administrative unit service.
/// </summary>
public class AdministrativeUnitService : IAdministrativeUnitService
{
    private readonly IAdministrativeUnitRepository _administrativeUnitEntityRepository;

    public AdministrativeUnitService(IAdministrativeUnitRepository administrativeUnitRepository)
    {
        _administrativeUnitEntityRepository = administrativeUnitRepository;
    }

        /// <summary>
    /// Edit an administrative unit.
    /// </summary>
    /// <param name="newAdministrativeUnitParamsparams"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public async Task<int> EditAdministrativeUnitAsync(AdministrativeUnit newAdministrativeUnit)
    {
        // If no errors occurred, proceed with updating both the administrative unit and location
        return await _administrativeUnitEntityRepository.EditAdministrativeUnitAsync(newAdministrativeUnit);
    }

    /// <summary>
    /// Set an administrative unit in the system.
    /// </summary>
    /// <param name="newAdministrativeUnitParams"></param>
    /// <returns></returns>
    public async Task<int> SetAdministrativeUnitAsync(AdministrativeUnit newAdministrativeUnit, AdministrativeUnitLocation newAdministrativeUnitLocation)
    {
        await _administrativeUnitEntityRepository.SetAdministrativeUnitAsync(newAdministrativeUnit);
        await _administrativeUnitEntityRepository.SetAdministrativeUnitLocationAsync(newAdministrativeUnitLocation);

        return 0;
    }

    /// <summary>
    /// Change the status of an administrative unit.
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public async Task<int> ChangeAdministrativeUnitStatusAsync(AdministrativeUnitActiveStatus status)
    {
        return await _administrativeUnitEntityRepository.SetAdministrativeUnitStatus(status);
    }
}
