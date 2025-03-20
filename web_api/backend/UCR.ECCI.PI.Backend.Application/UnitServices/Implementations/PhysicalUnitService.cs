using UCR.ECCI.PI.Backend.Domain.Unit.Entities;
using UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Unit.Repositories;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Unit.Records;

namespace UCR.ECCI.PI.Backend.Application.UnitServices.Implementations;

/// <summary>
/// Represents the physical unit service.
/// </summary>
internal class PhysicalUnitService : IPhysicalUnitService
{
    private readonly IPhysicalUnitRepository _physicalUnitEntityRepository;

    public PhysicalUnitService(IPhysicalUnitRepository physicalUnitRepository)
    {
        _physicalUnitEntityRepository = physicalUnitRepository;
    }

    /// <summary>
    /// List all physical units in the system.
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<PhysicalUnit>> ListPhysicalUnitAsync()
    {
        return await _physicalUnitEntityRepository.ListPhysicalUnitAsync();
    }

    /// <summary>
    /// Set a physical unit in the system.
    /// </summary>
    /// <param name="newPhysicalUnitParams"></param>
    /// <returns></returns>
    public async Task<int> SetPhysicalUnitAsync(PhysicalUnit newPhysicalUnit)
    {
        return await _physicalUnitEntityRepository.SetPhysicalUnitAsync(newPhysicalUnit);
    }


    /// <summary>
    /// Edit a physical unit in the system.
    /// </summary>
    /// <param name="newPhysicalUnitParamsParams"></param>
    /// <param name="name"></param>
    /// <returns></returns>
  public async Task<int> EditPhysicalUnitAsync(PhysicalUnit newPhysicalUnit)
  {    
    return await _physicalUnitEntityRepository.EditPhysicalUnitAsync(newPhysicalUnit);
    }

    /// <summary>
    /// Change the status of a physical unit.
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public async Task<int> ChangePhysicalUnitStatusAsync(AdministrativeUnitActiveStatus status)
    {
        return await _physicalUnitEntityRepository.SetPhysicalUnitStatus(status);
    }
}
