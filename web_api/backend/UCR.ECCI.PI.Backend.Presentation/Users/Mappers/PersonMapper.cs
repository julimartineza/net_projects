using Riok.Mapperly.Abstractions;
using System.ComponentModel.DataAnnotations;
using UCR.ECCI.PI.Backend.Domain.Users.Entities;
using UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;
using UCR.ECCI.PI.Backend.Presentation.Users.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Users.Mappers;

/// <summary>
/// Class to map the Person entity to a DTO and vice versa.
/// </summary>
[Mapper]
internal static partial class PersonMapper
{
    /// <summary>
    /// Maps a Person entity to a DTO.
    /// </summary>
    /// <param name="entity">The Person entity to map.</param>
    /// <returns>A DTO representing the Person entity.</returns>
    public static partial PersonDto ToDto(this Person entity);

    /// <summary>
    /// Converts a PersonId to a Guid.
    /// </summary>
    /// <param name="personId">The PersonId to convert.</param>
    /// <returns>The Guid value of the PersonId.</returns>
    public static Guid PersonIdToGuid(PersonId personId) => personId.Value;

    /// <summary>
    /// Converts a FullName to a string.
    /// </summary>
    /// <param name="fullName">The FullName to convert.</param>
    /// <returns>The string value of the FullName.</returns>
    public static string FullNameToString(FullName fullName) => fullName.Value;

    /// <summary>
    /// Converts a Nickname to a string.
    /// </summary>
    /// <param name="nickname">The Nickname to convert.</param>
    /// <returns>The string value of the Nickname.</returns>
    public static string NicknameToString(Nickname nickname) => nickname.Value;

    /// <summary>
    /// Converts a Username to a string.
    /// </summary>
    /// <param name="username">The Username to convert.</param>
    /// <returns>The string value of the Username.</returns>
    public static string UsernameToString(Username username) => username.Value;

    /// <summary>
    /// Converts an Email to a string.
    /// </summary>
    /// <param name="email">The Email to convert.</param>
    /// <returns>The string value of the Email.</returns>
    public static string EmailToString(Email email) => email.Value;

    /// <summary>
    /// Maps a Person DTO to an entity.
    /// </summary>
    /// <param name="dto">The DTO to map.</param>
    /// <returns>A Person entity representing the DTO.</returns>
    /// <exception cref="ValidationException">Thrown if validation fails during mapping.</exception>
    public static Person ToEntity(this PersonDto dto)
    {
        var allErrors = new List<string>();

        var personId = ValidateAndConvert(dto.PersonId, GuidToPersonId, allErrors);
        var fullName = ValidateAndConvert(dto.FullName, StringToFullName, allErrors);
        var nickname = ValidateAndConvert(dto.Nickname, StringToNickname, allErrors);
        var username = ValidateAndConvert(dto.Username, StringToUsername, allErrors);
        var email = ValidateAndConvert(dto.Email, StringToEmail, allErrors);

        if (allErrors.Count > 0)
        {
            throw new ValidationException(string.Join(Environment.NewLine, allErrors));
        }

        return new Person(fullName, nickname, username, email, personId);
    }

    /// <summary>
    /// Converts a Guid to a PersonId.
    /// </summary>
    /// <param name="id">The Guid to convert.</param>
    /// <returns>The PersonId created from the Guid.</returns>
    public static PersonId GuidToPersonId(Guid id) => PersonId.Create(id);

    /// <summary>
    /// Converts a string to a FullName.
    /// </summary>
    /// <param name="name">The string to convert.</param>
    /// <returns>The FullName created from the string.</returns>
    public static FullName StringToFullName(string name) => FullName.Create(name);

    /// <summary>
    /// Converts a string to a Nickname.
    /// </summary>
    /// <param name="nickname">The string to convert.</param>
    /// <returns>The Nickname created from the string.</returns>
    public static Nickname StringToNickname(string nickname) => Nickname.Create(nickname);

    /// <summary>
    /// Converts a string to a Username.
    /// </summary>
    /// <param name="username">The string to convert.</param>
    /// <returns>The Username created from the string.</returns>
    public static Username StringToUsername(string username) => Username.Create(username);

    /// <summary>
    /// Converts a string to an Email.
    /// </summary>
    /// <param name="email">The string to convert.</param>
    /// <returns>The Email created from the string.</returns>
    public static Email StringToEmail(string email) => Email.Create(email);

    /// <summary>
    /// Attempts to convert a value using a specified function, logging errors if the conversion fails.
    /// </summary>
    /// <typeparam name="TInput">The input type.</typeparam>
    /// <typeparam name="TOutput">The output type.</typeparam>
    /// <param name="value">The value to convert.</param>
    /// <param name="converter">The conversion function.</param>
    /// <param name="errors">A list to log errors.</param>
    /// <returns>The converted value, or the default of <typeparamref name="TOutput"/> on failure.</returns>
    private static TOutput ValidateAndConvert<TInput, TOutput>(TInput value, Func<TInput, TOutput> converter, List<string> errors)
    {
        try
        {
            return converter(value);
        }
        catch (Exception ex)
        {
            errors.Add(ex.Message);
            return default;
        }
    }
}
