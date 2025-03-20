using UCR.ECCI.PI.Backend.Presentation.Users.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Users.Requests;

/// <summary>
/// Record representing the request to create or update a person
/// </summary>
internal record SetPersonRequest
{
    /// <summary>
    /// DTO representing the person data
    /// </summary>
    public required PersonDto PersonDto { get; init; }
}

