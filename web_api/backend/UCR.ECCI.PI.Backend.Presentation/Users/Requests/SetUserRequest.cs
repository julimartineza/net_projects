using UCR.ECCI.PI.Backend.Presentation.Users.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Users.Requests
{
    /// <summary>
    /// Record representing the request to create or update a user.
    /// </summary>
    internal record SetUserRequest
    {
        /// <summary>
        /// DTO representing the user data.
        /// </summary>
        public required UserDto UserDto { get; init; }
    }
}
