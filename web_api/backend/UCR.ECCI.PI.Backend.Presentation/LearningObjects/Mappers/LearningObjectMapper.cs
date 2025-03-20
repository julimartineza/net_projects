using Riok.Mapperly.Abstractions;
using System.ComponentModel.DataAnnotations;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.LearningObjects.Entities;
using UCR.ECCI.PI.Backend.Domain.LearningSpaces.ValueObjects;
using UCR.ECCI.PI.Backend.Presentation.LearningObjects.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.LearningObjects.Mappers;

/// <summary>
/// Class to map the learning object entity to a dto and vice versa.
/// </summary>
[Mapper]
internal static partial class LearningObjectMapper
{
    /// <summary>
    /// Method to map a learning object entity to a dto.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public static partial LearningObjectDto ToDto(this LearningObject entity);

    /// <summary>
    /// Method to pass from Id to string
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static string IdToString(Id id) => id.Value;

    /// <summary>
    /// Method to pass from TypeLO to string
    /// </summary>
    /// <param name="typeLO"></param>
    /// <returns></returns>
    public static string TypeLOToString(TypeLS typeLO) => typeLO.Value;

    /// <summary>
    /// Method to pass from Coordinate to decimal
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    public static decimal CoordinateToDecimal(Coordinate location) => location.Value;

    /// <summary>
    /// Method to pass from Dimensions to decimal
    /// </summary>
    /// <param name="scale"></param>
    /// <returns></returns>
    public static decimal ScaleToDecimal(Dimensions scale) => scale.Value;

    /// <summary>
    /// Method to pass from LearningSpaceName to string
    /// </summary>
    /// <param name="learningSpaceName"></param>
    /// <returns></returns>
    public static string LearningSpaceNameToString(Name learningSpaceName) => learningSpaceName.Value;

    /// <summary>
    /// Method to map a learning object dto to an entity.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    public static LearningObject ToEntity(this LearningObjectDto dto)
    {
        var allErrors = new List<string>();

        var code = ValidateAndConvert(dto.Id, StringToId, allErrors);
        var name = ValidateAndConvert(dto.TypeLO, StringToTypeLO, allErrors);
        var locationX = ValidateAndConvert(dto.LocationX, DecimalToCoordinate, allErrors);
        var locationY = ValidateAndConvert(dto.LocationY, DecimalToCoordinate, allErrors);
        var locationZ = ValidateAndConvert(dto.LocationZ, DecimalToCoordinate, allErrors);
        var scaleX = ValidateAndConvert(dto.ScaleX, DecimalToScale, allErrors);
        var scaleY = ValidateAndConvert(dto.ScaleY, DecimalToScale, allErrors);
        var scaleZ = ValidateAndConvert(dto.ScaleZ, DecimalToScale, allErrors);
        var rotationW = ValidateAndConvert(dto.RotationW, DecimalToCoordinate, allErrors);
        var rotationX = ValidateAndConvert(dto.RotationX, DecimalToCoordinate, allErrors);
        var rotationY = ValidateAndConvert(dto.RotationY, DecimalToCoordinate, allErrors);
        var rotationZ = ValidateAndConvert(dto.RotationZ, DecimalToCoordinate, allErrors);
        var learningSpaceName = ValidateAndConvert(dto.LearningSpaceName, StringToLearningSpaceName, allErrors);

        // Lanzamos la excepción solo si hay errores acumulados
        if (allErrors.Count > 0)
        {
            throw new ValidationException(string.Join(Environment.NewLine, allErrors));
        }

        return new LearningObject(code, name, locationX, locationY, locationZ, scaleX, scaleY, scaleZ, rotationW, 
            rotationX, rotationY, rotationZ, learningSpaceName);
    }

    /// <summary>
    /// Method to pass from string to Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Id StringToId(string id) => Id.Create(id);

    /// <summary>
    /// Method to pass from string to TypeLO
    /// </summary>
    /// <param name="typeLO"></param>
    /// <returns></returns>
    public static TypeLS StringToTypeLO(string typeLO) => TypeLS.Create(typeLO);

    /// <summary>
    /// Method to pass from decimal to Coordinate
    /// </summary>
    /// <param name="location"></param>
    /// <returns></returns>
    public static Coordinate DecimalToCoordinate(decimal location) => Coordinate.Create(location);

    /// <summary>
    /// Method to pass from decimal to Dimensions
    /// </summary>
    /// <param name="scale"></param>
    /// <returns></returns>
    public static Dimensions DecimalToScale(decimal scale) => Dimensions.Create(scale);

    /// <summary>
    /// Method to pass from string to LearningSpaceName
    /// </summary>
    /// <param name="learningSpaceName"></param>
    /// <returns></returns>
    public static Name StringToLearningSpaceName(string learningSpaceName) => Name.Create(learningSpaceName);

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
