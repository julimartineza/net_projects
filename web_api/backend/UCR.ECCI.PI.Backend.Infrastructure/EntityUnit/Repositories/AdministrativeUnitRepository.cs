using Microsoft.EntityFrameworkCore;
using UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;
using UCR.ECCI.PI.Backend.Domain.Unit.Records;
using UCR.ECCI.PI.Backend.Domain.Unit.Repositories;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using System;

namespace UCR.ECCI.PI.Backend.Infrastructure.EntityUnit.Repositories;

/// <summary>
/// Repository for the administrative unit entity.
/// </summary>
internal class AdministrativeUnitRepository : IAdministrativeUnitRepository
{
    private DatabaseContext _databaseContext { get; set; }

    /// <summary>
    /// Administrative unit repository constructor.
    /// </summary>
    /// <param name="databaseContext"></param>
    public AdministrativeUnitRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    /// <summary>
    /// Implements the method in the IAdministrativeUnitRepository interface to set an administrative unit.
    /// </summary>
    /// <param name="administrativeUnit"></param>
    /// <returns>0 when successful</returns>
    public async Task<int> SetAdministrativeUnitAsync(AdministrativeUnit administrativeUnit)
    {
        try
        {
            _databaseContext.AdministrativeUnit.Add(administrativeUnit);
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
    /// Implements the method in the IAdministrativeUnitRepository interface to set an administrative unit location.
    /// </summary>
    /// <param name="administrativeUnitLocation"></param>
    /// <returns>0 when successful</returns>
    public async Task<int> SetAdministrativeUnitLocationAsync(AdministrativeUnitLocation administrativeUnitLocation)
    {
        try
        {
            _databaseContext.AdministrativeUnitLocation.Add(administrativeUnitLocation);
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
    /// Implements the method in the IAdministrativeUnitRepository interface to list all administrative units hierarchies.
    /// </summary>
    /// <returns>List of administrative units hierarchies</returns>
    public async Task<IEnumerable<AdministrativeHierarchyResult>> ListAdministrativeUnitHierarchiesAsync()
    {
        var administrativeUnitHierarchies = await _databaseContext.Database.SqlQuery<AdministrativeHierarchyResult>($"SELECT * FROM ListBuildingAdministrativeHierarchies()")
        .ToListAsync();

        return administrativeUnitHierarchies.AsEnumerable(); 
    }

    /// <summary>
    /// Implements the method in the IAdministrativeUnitRepository interface to edit an administrative unit.
    /// </summary>
    /// <param name="administrativeUnit"></param>
    /// <returns>0 when successful</returns>
    public async Task<int> EditAdministrativeUnitAsync(AdministrativeUnit administrativeUnit)
    {
        _databaseContext.AdministrativeUnit.Update(administrativeUnit);
        await _databaseContext.SaveChangesAsync();
        return 0;
    }

    /// <summary>
    /// Asynchronously updates an existing administrative unit location in the database.
    /// </summary>
    /// <param name="administrativeUnitLocation">The administrative unit location entity containing updated information.</param>
    /// <returns>
    /// Returns 0 if the update is successful.
    /// Throws exceptions for various error conditions, which are handled by the service layer.
    /// </returns>
    /// <exception cref="KeyNotFoundException">Thrown when the specified administrative unit location is not found.</exception>
    /// <exception cref="Exception">Thrown when a database or general error occurs during the update process.</exception>
    public async Task<int> EditAdministrativeUnitLocationAsync(AdministrativeUnitLocation administrativeUnitLocation)
    {
        try
        {
            // Query the existing location by name from the database
            var existingLocation = await _databaseContext.AdministrativeUnitLocation
                .FirstOrDefaultAsync(x => x.AdministrativeUnitName == administrativeUnitLocation.AdministrativeUnitName);

            // Validate existence of the location
            if (existingLocation == null)
            {
                throw new KeyNotFoundException($"Administrative unit location not found with name: {administrativeUnitLocation.AdministrativeUnitName.Value}");
            }

            // Update the entity properties with new values
            existingLocation.BuildingId.Value = administrativeUnitLocation.BuildingId.Value;

            // Mark the entity as modified in the context
            _databaseContext.AdministrativeUnitLocation.Update(existingLocation);

            // Persist changes to the database
            await _databaseContext.SaveChangesAsync();
            return 0; // Indicates successful update
        }
        catch (DbUpdateException dbEx)
        {
            // Log and handle database-specific update errors
            Console.WriteLine($"Database update error: {dbEx.Message}");
            throw new DbUpdateException($"Failed to update administrative unit location: {dbEx.Message}");
        }
        catch (KeyNotFoundException knfEx)
        {
            // Log and propagate not found errors for handling in service layer
            Console.WriteLine($"Location not found error: {knfEx.Message}");
            throw;
        }
        catch (Exception e)
        {
            // Log and handle any unexpected errors
            Console.WriteLine($"An unexpected error occurred: {e.Message}");
            throw new InvalidOperationException($"Error updating administrative unit location: {e.Message}");
        }
    }

    /// Implements the method in the IAdministrativeUnitRepository interface to set the status of an administrative unit
    /// </summary>
    /// <param name="active"></param>
    /// <returns>0 when successful</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public async Task<int> SetAdministrativeUnitStatus(AdministrativeUnitActiveStatus active)
    {
        AdministrativeUnit? adminUnitToChange = await _databaseContext.AdministrativeUnit.FindAsync(Name.Create(active.Name));
        bool hasAdminUnitSon;
        if (adminUnitToChange != null)
        {
            if (!active.status) {
                hasAdminUnitSon = await _databaseContext.AdministrativeUnit.AnyAsync(au => au.SupervisedBy == Supervisor.Create(adminUnitToChange.Name.Value));
                if (!hasAdminUnitSon)
                {
                    adminUnitToChange.Status = false;
                    _databaseContext.AdministrativeUnit.Update(adminUnitToChange);
                    await _databaseContext.SaveChangesAsync();
                } else
                {
                    throw new InvalidOperationException("The administrative unit has children and cannot be deactivated");
                }
            } else
            {
                adminUnitToChange.Status = active.status;
                _databaseContext.AdministrativeUnit.Update(adminUnitToChange);
                await _databaseContext.SaveChangesAsync();
            }
        }
        return 0;
    }
}
