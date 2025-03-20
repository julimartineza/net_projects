using UCR.ECCI.PI.Backend.Presentation.Users.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Users.Responses
{
    /// <summary>
    /// Represents the response when retrieving a user.
    /// </summary>
    internal record GetUserResponse
    {
        /// <summary>
        /// The user data as a DTO.
        /// </summary>
        public UserDto User { get; init; }

    }
}
