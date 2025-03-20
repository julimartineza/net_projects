using UCR.ECCI.PI.Backend.Application.BuildingServices;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;
using UCR.ECCI.PI.Backend.Domain.Unit.Records;

namespace UCR.ECCI.PI.Backend.Application.UnitServices;

/// <summary>
/// Interface for the physical unit service.
/// </summary>
public interface IPhysicalUnitService
{
    /// <summary>
    /// List all physical units in the system.
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<PhysicalUnit>> ListPhysicalUnitAsync();

    /// <summary>
    /// Set a physical unit in the system.
    /// </summary>
    /// <param name="newPhysicalUnit"></param>
    /// <returns></returns>
    public Task<int> SetPhysicalUnitAsync(PhysicalUnit newPhysicalUnit);

    /// <summary>
    /// Edit a physical unit in the system.
    /// </summary>
    /// <param name="newPhysicalUnitParams"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public Task<int> EditPhysicalUnitAsync(PhysicalUnit newPhysicalUnit);

    /// <summary>
    /// Change the status of a physical unit.
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public Task<int> ChangePhysicalUnitStatusAsync(AdministrativeUnitActiveStatus status);

}