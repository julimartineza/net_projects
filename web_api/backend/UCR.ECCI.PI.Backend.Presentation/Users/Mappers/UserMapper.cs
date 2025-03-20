using Riok.Mapperly.Abstractions;
using System.ComponentModel.DataAnnotations;
using UCR.ECCI.PI.Backend.Application.UserServices;
using UCR.ECCI.PI.Backend.Domain.Users.Entities;
using UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;
using UCR.ECCI.PI.Backend.Presentation.Users.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Users.Mappers
{
    /// <summary>
    /// Class to map the User entity to a DTO and vice versa.
    /// </summary>
    [Mapper]
    internal static partial class UserMapper
    {
        /// <summary>
        /// Maps a User entity to a DTO.
        /// </summary>
        /// <param name="entity">The User entity to map.</param>
        /// <returns>A DTO representing the User entity.</returns>
        public static partial UserDto ToDto(this User entity);

        public static bool MapIsActive(IsActive isActive) => isActive.Value;
        public static bool MapIsPerson(IsPerson isPerson) => isPerson.Value;

        /// <summary>
        /// Converts a UserId to a Guid.
        /// </summary>
        public static Guid UserIdToGuid(PersonId userId) => userId.Value;

        /// <summary>
        /// Converts a Username to a string.
        /// </summary>
        public static string UsernameToString(Username username) => username.Value;

        /// <summary>
        /// Converts an Avatar to a string.
        /// </summary>
        public static string AvatarToString(Avatar avatar) => avatar.Value;

        /// <summary>
        /// Converts an Email to a string.
        /// </summary>
        public static string EmailToString(Email email) => email.Value;

        /// <summary>
        /// Maps a User DTO to an entity.
        /// </summary>
        /// <param name="dto">The DTO to map.</param>
        /// <returns>A User entity representing the DTO.</returns>
        /// <exception cref="ValidationException">Thrown if validation fails during mapping.</exception>
        public static User ToEntity(this UserDto dto)
        {
            var allErrors = new List<string>();

            var userId = ValidateAndConvert(dto.UserId, GuidToUserId, allErrors);
            var username = ValidateAndConvert(dto.Username, StringToUsername, allErrors);
            var avatar = ValidateAndConvert(dto.Avatar, StringToAvatar, allErrors);
            var email = ValidateAndConvert(dto.Email, StringToEmail, allErrors);
            var isActive = new IsActive(dto.IsActive); 

            if (allErrors.Count > 0)
            {
                throw new ValidationException(string.Join(Environment.NewLine, allErrors));
            }

            return new User(userId, username, avatar, isActive, email);
        }

        /// <summary>
        /// Converts a Guid to a UserId.
        /// </summary>
        public static PersonId GuidToUserId(Guid id) => PersonId.Create(id);

        /// <summary>
        /// Converts a string to a Username.
        /// </summary>
        public static Username StringToUsername(string username) => Username.Create(username);

        /// <summary>
        /// Converts a string to an Avatar.
        /// </summary>
        public static Avatar StringToAvatar(string avatar) => Avatar.Create(avatar);

        /// <summary>
        /// Converts a string to an Email.
        /// </summary>
        public static Email StringToEmail(string email) => Email.Create(email);

        /// <summary>
        /// Maps a GetUserResult to a UserDto, excluding the IsPerson field.
        /// </summary>
        /// <param name="userResult">The GetUserResult to map.</param>
        /// <returns>A UserDto representing the UserResult.</returns>
        public static UserDto ToUserDto(this GetUserResult userResult)
        {
            return new UserDto
            {
                UserId = userResult.Id,
                Username = userResult.Username,
                Avatar = userResult.Avatar,
                IsActive = userResult.IsActive,
                Email = userResult.Email,
                IsPerson = true
            };
        }

        /// <summary>
        /// Attempts to convert a value using a specified function, logging errors if the conversion fails.
        /// </summary>
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
}
