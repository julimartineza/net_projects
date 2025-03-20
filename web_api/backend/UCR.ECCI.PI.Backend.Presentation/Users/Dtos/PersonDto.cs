namespace UCR.ECCI.PI.Backend.Presentation.Users.Dtos;

/// <summary>
/// DTO representing a Person.
/// </summary>
internal record PersonDto
{
    public required Guid PersonId { get; init; }
    public required string FullName { get; init; }
    public required string Nickname { get; init; }
    public required string Username { get; init; }
    public required string Email { get; init; }
}