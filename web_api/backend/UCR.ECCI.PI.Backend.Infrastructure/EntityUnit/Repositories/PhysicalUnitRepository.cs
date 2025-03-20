using Microsoft.EntityFrameworkCore;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;
using UCR.ECCI.PI.Backend.Domain.Unit.Records;
using UCR.ECCI.PI.Backend.Domain.Unit.Repositories;
using UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;

namespace UCR.ECCI.PI.Backend.Infrastructure.EntityUnit.Repositories;

/// <summary>
/// Repository for the physical unit entity.
/// </summary>
internal class PhysicalUnitRepository : IPhysicalUnitRepository
{
    private DatabaseContext _databaseContext { get; set; }

    /// <summary>
    /// Constructor for the physical unit repository.
    /// </summary>
    /// <param name="databaseContext"></param>
    public PhysicalUnitRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    /// <summary>
    /// Implements the method in the IPhysicalUnitRepository interface to list all physical units
    /// </summary>
    /// <returns>List of PhysicalUnit objects</returns>
    public async Task<IEnumerable<PhysicalUnit>> ListPhysicalUnitAsync()
    {
        var physicalUnits = await _databaseContext.GetListPhysicalUnitNotNull()
                    .ToListAsync();

        return physicalUnits.AsEnumerable();
    }

    public async Task<int> SetPhysicalUnitAsync(PhysicalUnit physicalUnit)
    {
        try
        {
            _databaseContext.PhysicalUnit.Add(physicalUnit);
            await _databaseContext.SaveChangesAsync();
            return 0;
        }
        catch (DbUpdateException dbEx)
        {
            Console.WriteLine($"Database update error: {dbEx.Message}");
            return 1;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
            return 2;
        }
    }

    /// <summary>
    /// Implements the method in the IPhysicalUnitRepository interface to edit a physical unit by its id
    /// </summary>
    /// <param name="physicalUnit"></param>
    /// <returns>0 when successful</returns>
    public async Task<int> EditPhysicalUnitAsync(PhysicalUnit name)
    {
        _databaseContext.PhysicalUnit.Update(name);
        await _databaseContext.SaveChangesAsync();
        return 0;
    }

    /// <summary>
    /// Implements the method in the IPhysicalUnitRepository interface to set the status of a physical unit
    /// </summary>
    /// <param name="active"></param>
    /// <returns>0 when successful</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<int> SetPhysicalUnitStatus(AdministrativeUnitActiveStatus active)
    {
        PhysicalUnit? physicalUnitToChange = await _databaseContext.PhysicalUnit.FindAsync(Name.Create(active.Name));
        bool hasphysicalUnitSon;
        bool hasbuildings;
        if (physicalUnitToChange != null)
        {
            if (!active.status)
            {
                hasphysicalUnitSon = await _databaseContext.PhysicalUnit.AnyAsync(au => au.LocatedIn == LocatedIn.Create(physicalUnitToChange.Name.Value));
                hasbuildings = await _databaseContext.Building.AnyAsync(building => building.PhysicalUnitName == Name.Create(physicalUnitToChange.Name.Value));
                if (!hasphysicalUnitSon && !hasbuildings)
                {
                    physicalUnitToChange.Status = false;
                    _databaseContext.PhysicalUnit.Update(physicalUnitToChange);
                    await _databaseContext.SaveChangesAsync();
                }
                else
                {
                    throw new InvalidOperationException("The physical unit has children or buildings assigned so it cannot be deactivated");
                }
            }
            else
            {
                physicalUnitToChange.Status = active.status;
                _databaseContext.PhysicalUnit.Update(physicalUnitToChange);
                await _databaseContext.SaveChangesAsync();
            }
        }
        return 0;
    }
}