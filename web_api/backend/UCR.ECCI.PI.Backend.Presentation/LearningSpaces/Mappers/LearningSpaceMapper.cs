using Riok.Mapperly.Abstractions;
using System.ComponentModel.DataAnnotations;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.Entities;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.ValueObjects;
using UCR.ECCI.PI.Backend.Presentation.LearningSpaces.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.LearningSpaces.Mappers;

/// <summary>
/// Class to map the learning space entity to a dto and vice versa.
/// </summary>
[Mapper]
internal static partial class LearningSpaceMapper
{
    /// <summary>
    /// Method to map a learning space entity to a dto.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public static partial LearningSpaceDto ToDto(this LearningSpace entity);

    /// <summary>
    /// Method to pass from Name to string
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static string NameToString(Name name) => name.Value;

    /// <summary>
    /// Method to pass from Description to string
    /// </summary>
    /// <param name="description"></param>
    /// <returns></returns>
    public static string DescriptionToString(Description description) => description.Value;

    /// <summary>
    /// Method to pass from Scale to string
    /// </summary>
    /// <param name="scale"></param>
    /// <returns></returns>
    public static decimal ScaleToString(Scale scale) => scale.Value;

    /// <summary>
    /// Method to pass from TypeLS to string
    /// </summary>
    /// <param name="typeLS"></param>
    /// <returns></returns>
    public static string TypeLSToString(TypeLS typeLS) => typeLS.Value;

    /// <summary>
    /// Method to pass from Floor to int
    /// </summary>
    /// <param name="floor"></param>
    /// <returns></returns>
    public static int FloorToInt(Floor floor) => floor.Value;

    /// <summary>
    /// Method to pass from BuildingId to string
    /// </summary>
    /// <param name="buildingId"></param>
    /// <returns></returns>
    public static string BuildingIdToString(BuildingId buildingId) => buildingId.Value;

    /// <summary>
    /// Method to map a learning space dto to an entity.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public static LearningSpace ToEntity(this LearningSpaceDto dto)
    {
        var allErrors = new List<string>();

        var name = ValidateAndConvert(dto.Name, StringToName, allErrors);
        var description = ValidateAndConvert(dto.Description, StringToDescription, allErrors);
        var scaleX = ValidateAndConvert(dto.ScaleX, StringToScale, allErrors);
        var scaleY = ValidateAndConvert(dto.ScaleY, StringToScale, allErrors);
        var scaleZ = ValidateAndConvert(dto.ScaleZ, StringToScale, allErrors);
        var typeLS = ValidateAndConvert(dto.TypeLS, StringToTypeLS, allErrors);
        var floor = ValidateAndConvert(dto.Floor, IntToFloor, allErrors);
        var buildingId = ValidateAndConvert(dto.BuildingId, StringToBuildingId, allErrors);

        if (allErrors.Count > 0)
        {
            throw new ValidationException(string.Join(Environment.NewLine, allErrors));
        }

        return new LearningSpace(name, description, scaleX, scaleY, scaleZ, typeLS, floor, buildingId);
    }

    /// <summary>
    /// Method to pass from string to Name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Name StringToName(string name) => Name.Create(name);

    /// <summary>
    /// Method to pass from string to Description
    /// </summary>
    /// <param name="description"></param>
    /// <returns></returns>
    public static Description StringToDescription(string description) => Description.Create(description);

    /// <summary>
    /// Method to pass from string to Scale
    /// </summary>
    /// <param name="scale"></param>
    /// <returns></returns>
    public static Scale StringToScale(decimal scale) => Scale.Create(scale);

    /// <summary>
    /// Method to pass from string to TypeLS
    /// </summary>
    /// <param name="typeLS"></param>
    /// <returns></returns>
    public static TypeLS StringToTypeLS(string typeLS) => TypeLS.Create(typeLS);

    /// <summary>
    /// Method to pass from int to Floor
    /// </summary>
    /// <param name="floor"></param>
    /// <returns></returns>
    public static Floor IntToFloor(int floor) => Floor.Create(floor);

    /// <summary>
    /// Method to pass from string to BuildingId
    /// </summary>
    /// <param name="buildingId"></param>
    /// <returns></returns>
    public static BuildingId StringToBuildingId(string buildingId) => BuildingId.Create(buildingId);

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
