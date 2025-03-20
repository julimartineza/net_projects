using UCR.ECCI.PI.Backend.Domain.Buildings.Entities;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;
using UCR.ECCI.PI.Backend.Domain.Unit.Records;

namespace UCR.ECCI.PI.Backend.Domain.Unit.Repositories;

public interface IPhysicalUnitRepository
{
    /// <summary>
    /// Method to set a physical unit.
    /// </summary>
    /// <param name="physicalUnit"></param>
    /// <returns>0 when succesful</returns>
    public Task<int> SetPhysicalUnitAsync(PhysicalUnit physicalUnit);

    /// <summary>
    /// Method to list all physical units.
    /// </summary>
    /// <returns>List of physical units</returns>
    public Task<IEnumerable<PhysicalUnit>> ListPhysicalUnitAsync();

    /// <summary>
    /// Method to get a physical unit by its id.
    /// </summary>
    /// <param name="name"></param>
    /// <returns> 0 when successful</returns>
    public Task<int> EditPhysicalUnitAsync(PhysicalUnit name);

    /// <summary>
    /// Method to set the location of a physical unit.
    /// </summary>
    /// <param name="active"></param>
    /// <returns> 0 when successful</returns>
    public Task<int> SetPhysicalUnitStatus(AdministrativeUnitActiveStatus active);
}
