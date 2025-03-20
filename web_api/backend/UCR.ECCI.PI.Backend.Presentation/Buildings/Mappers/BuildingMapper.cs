using Riok.Mapperly.Abstractions;
using System.ComponentModel.DataAnnotations;
using UCR.ECCI.PI.Backend.Domain.Buildings.Entities;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Presentation.Buildings.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Buildings.Mappers;

/// <summary>
/// Class to map the building entity to a dto and vice versa.
/// </summary>
[Mapper]
internal static partial class BuildingMapper
{
    /// <summary>
    /// Method to map a building entity to a dto.
    /// </summary>
    /// <param name="entity">Entity to transform</param>
    /// <returns></returns>
    public static partial BuildingDto ToDto(this Building entity);

    /// <summary>
    /// Method to pass from Id to string
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static string IdToString(Id id) => id.Value;

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
    /// Method to pass from Color to string
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static string ColorToString(Color color) => color.Value;

    /// <summary>
    /// Method to pass form Coordinate to decimal
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
    /// Method to pass from TypeBuilding to string
    /// </summary>
    /// <param name="typeBuilding"></param>
    /// <returns></returns>
    public static string TypeBuildingToString(TypeBuilding typeBuilding) => typeBuilding.Value;

    /// <summary>
    /// Method to pass from Floors to int
    /// </summary>
    /// <param name="floors"></param>
    /// <returns></returns>
    public static int FloorsToInt(Floors floors) => floors.Value;

    /// <summary>
    /// Method to map a building dto to an entity.
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    public static Building ToEntity(this BuildingDto dto)
    {
        var allErrors = new List<string>();

        var id = ValidateAndConvert(dto.Id, StringToId, allErrors);
        var name = ValidateAndConvert(dto.Name, StringToName, allErrors);
        var acronym = ValidateAndConvert(dto.Acronym, StringToName, allErrors);
        var description = ValidateAndConvert(dto.Description, StringToDescription, allErrors);
        var physicalUnitName = ValidateAndConvert(dto.PhysicalUnitName, StringToName, allErrors);
        var color = ValidateAndConvert(dto.Color, StringToColor, allErrors);
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
        var typeBuilding = ValidateAndConvert(dto.TypeBuilding, StringToTypeBuilding, allErrors);
        var status = dto.Status;
        var floors = ValidateAndConvert(dto.Floors, IntToFloors, allErrors);

        if (allErrors.Count > 0)
        {
            throw new ValidationException(string.Join(Environment.NewLine, allErrors));
        }

        return new Building(id, name, acronym, description, physicalUnitName, color, locationX, 
            locationY, locationZ, scaleX, scaleY, scaleZ, rotationW, rotationX, rotationY, 
            rotationZ, typeBuilding, status, floors);
    }

    /// <summary>
    /// Method to pass from string to Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static Id StringToId(string id) => Id.Create(id);

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
    /// Method to pass from string to Color
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public static Color StringToColor(string color) => Color.Create(color);

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
    /// Method to pass from string to TypeBuilding
    /// </summary>
    /// <param name="typeBuilding"></param>
    /// <returns></returns>
    public static TypeBuilding StringToTypeBuilding(string typeBuilding) => TypeBuilding.Create(typeBuilding);

    /// <summary>
    /// Method to pass from int to Floors
    /// </summary>
    /// <param name="floors"></param>
    /// <returns></returns>
    public static Floors IntToFloors(int floors) => Floors.Create(floors);

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
