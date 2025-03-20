namespace UCR.ECCI.PI.Backend.Presentation.Users.Dtos
{
    /// <summary>
    /// DTO representing a User.
    /// </summary>
    internal record UserDto
    {
        public required Guid UserId { get; init; }
        public required string Username { get; init; }
        public required string Avatar { get; init; }
        public required bool IsActive { get; init; }
        public required string Email { get; init; }
        public required bool IsPerson { get; init; }
    }
}