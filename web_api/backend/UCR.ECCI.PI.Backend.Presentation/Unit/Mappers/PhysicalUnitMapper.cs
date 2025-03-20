using Riok.Mapperly.Abstractions;
using System.ComponentModel.DataAnnotations;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Unit.Entities;
using UCR.ECCI.PI.Backend.Domain.Unit.ValueObjects;
using UCR.ECCI.PI.Backend.Presentation.Unit.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Unit.Mappers;

/// <summary>
/// Class to map physical unit object entity to a dto and vice versa.
/// </summary>
[Mapper]
internal static partial class PhysicalUnitMapper
{
    /// <summary>
    /// Method to map a physical unit entity to a dto.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static PhysicalUnit ToEntity(this PhysicalUnitDto dto)
    {
        var allErrors = new List<string>();

        var name = ValidateAndConvert(dto.Name, StringToName, allErrors);
        var physicalUnitType = ValidateAndConvert(dto.PhysicalUnitType, StringToPhysicalUnitType, allErrors);
        var locatedIn = ValidateAndConvert(dto.LocatedIn, StringToLocatedIn, allErrors);

        if (allErrors.Count > 0)
        {
            throw new ValidationException(string.Join(Environment.NewLine, allErrors));
        }

        return new PhysicalUnit(name, physicalUnitType, locatedIn, dto.Status);
    }

    /// <summary>
    /// Method to pass from Name to string
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Name StringToName(string name) => Name.Create(name);

    /// <summary>
    /// Method to map a physical unit entity to a dto.
    /// </summary>
    /// <param name="physicalUnitType"></param>
    /// <returns></returns>
    public static PhysicalUnitType StringToPhysicalUnitType(string physicalUnitType) => PhysicalUnitType.Create(physicalUnitType);

    /// <summary>
    /// Method to map a physical unit entity to a dto.
    /// </summary>
    /// <param name="locatedIn"></param>
    /// <returns></returns>
    public static LocatedIn StringToLocatedIn(string locatedIn) => LocatedIn.Create(locatedIn);

    /// <summary>
    /// Method to map a physical unit entity to a dto.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public static partial PhysicalUnitDto ToDto(this PhysicalUnit entity);

    /// <summary>
    /// Method to pass from Name to string
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string NameToString(Name name) => name.Value;

    /// <summary>
    /// Method to pass from PhysicalUnitType to string
    /// </summary>
    /// <param name="physicalUnitType"></param>
    /// <returns></returns>
    public static string PhysicalUnitTypeToString(PhysicalUnitType physicalUnitType) => physicalUnitType.Value;

    /// <summary>
    /// Method to pass from LocatedIn to string
    /// </summary>
    /// <param name="locatedIn"></param>
    /// <returns></returns>
    public static string LocatedInToString(LocatedIn locatedIn) => locatedIn.Value;

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
