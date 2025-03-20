using Riok.Mapperly.Abstractions;
using System.ComponentModel.DataAnnotations;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;
using UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;
using UCR.ECCI.PI.Backend.Presentation.Unit.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Unit.Mappers;

/// <summary>
/// Class to map the administrative unit entity to a dto and vice versa.
/// </summary>
[Mapper]
internal static partial class AdministrativeUnitMapper
{
    /// <summary>
    /// Method to map an administrative unit entity to a dto.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Name StringToName(string name) => Name.Create(name);

    /// <summary>
    /// Method to map an administrative unit entity to a dto.
    /// </summary>
    /// <param name="administrativeUnitType"></param>
    /// <returns></returns>
    public static AdministrativeUnitType StringToAdministrativeUnitType(string administrativeUnitType) => AdministrativeUnitType.Create(administrativeUnitType);

    /// <summary>
    /// Method to map an administrative unit entity to a dto.
    /// </summary>
    /// <param name="supervisor"></param>
    /// <returns></returns>
    public static Supervisor StringToSupervisor(string supervisor) => Supervisor.Create(supervisor);

    /// <summary>
    /// Method to map an administrative unit entity to a dto.
    /// </summary>
    /// <param name="buildingId"></param>
    /// <returns></returns>
    public static Id StringToId(string buildingId) => Id.Create(buildingId);

    /// <summary>
    /// Method to map an administrative unit entity to a dto.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string NameToString(Name name) => name.Value;

    /// <summary>
    /// Method to map an administrative unit entity to a dto.
    /// </summary>
    /// <param name="administrativeUnitType"></param>
    /// <returns></returns>
    public static string AdministrativeUnitTypeToString(AdministrativeUnitType administrativeUnitType) => administrativeUnitType.Value;

    /// <summary>
    /// Method to map an administrative unit entity to a dto.
    /// </summary>
    /// <param name="supervisor"></param>
    /// <returns></returns>
    public static string SupervisorToString(Supervisor supervisor) => supervisor.Value;

    /// <summary>
    /// Method to map an administrative unit entity to a dto.
    /// </summary>
    /// <param name="buildingId"></param>
    /// <returns></returns>
    public static string IdToString(Id buildingId) => buildingId.Value;

    /// <summary>
    /// Method to map an administrative unit entity to a dto.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static AdministrativeUnit ToEntity(this AdministrativeUnitDto dto)
    {
        var allErrors = new List<string>();

        var name = ValidateAndConvert(dto.Name, StringToName, allErrors);
        var administrativeUnitType = ValidateAndConvert(dto.AdministrativeUnitType, StringToAdministrativeUnitType, allErrors);
        var supervisor = ValidateAndConvert(dto.SupervisedBy, StringToSupervisor, allErrors);

        if (allErrors.Count > 0)
        {
            throw new ValidationException(string.Join(Environment.NewLine, allErrors));
        }

        return new AdministrativeUnit(name, administrativeUnitType, supervisor, dto.Status);
    }

    /// <summary>
    /// Method to map an administrative unit location entity to a dto.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static AdministrativeUnitLocation ToLocationEntity(this AdministrativeUnitDto dto)
    {
        var allErrors = new List<string>();

        var name = ValidateAndConvert(dto.Name, StringToName, allErrors);
        var buildingId = ValidateAndConvert(dto.BuildingId, StringToId, allErrors);

        if (allErrors.Count > 0)
        {
            throw new ValidationException(string.Join(Environment.NewLine, allErrors));
        }

        return new AdministrativeUnitLocation(name, buildingId);
    }

    /// <summary>
    /// Attempts to convert a specified value using a provided conversion function. 
    /// If the conversion fails, an error message is added to the provided error list, 
    /// and a default value is returned.
    /// </summary>
    /// <typeparam name="TInput">The type of the input value to be converted.</typeparam>
    /// <typeparam name="TOutput">The type of the output value after conversion.</typeparam>
    /// <param name="value">The input value to convert.</param>
    /// <param name="converter">A function that defines how to convert the input value.</param>
    /// <param name="errors">A list to which any error messages will be added if the conversion fails.</param>
    /// <returns>
    /// The converted value if successful; otherwise, the default value of <typeparamref name="TOutput"/>.
    /// </returns>
    /// <remarks>
    /// This method catches any exceptions thrown by the <paramref name="converter"/> function and logs the error message.
    /// </remarks>
    private static TOutput ValidateAndConvert<TInput, TOutput>(TInput value, Func<TInput, TOutput> converter, List<string> errors)
    {
        try
        {
            return converter(value);
        }
        catch (Exception ex)
        {
            errors.Add(ex.Message);
            return default!;
        }
    }
}
