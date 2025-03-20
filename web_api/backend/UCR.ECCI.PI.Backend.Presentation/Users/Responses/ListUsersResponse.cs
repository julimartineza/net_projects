using UCR.ECCI.PI.Backend.Presentation.Users.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Users.Responses
{
    /// <summary>
    /// Record representing the response to list all users
    /// </summary>
    internal record ListUsersResponse
    {
        /// <summary>
        /// The list of users
        /// </summary>
        public required IEnumerable<UserDto> Users { get; init; }
    }
}
