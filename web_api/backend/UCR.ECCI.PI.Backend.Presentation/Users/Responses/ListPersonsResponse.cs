using UCR.ECCI.PI.Backend.Presentation.Users.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Users.Responses
{
    /// <summary>
    /// Record representing the response to list all persons
    /// </summary>
    internal record ListPersonsResponse
    {
        /// <summary>
        /// The list of persons
        /// </summary>
        public required IEnumerable<PersonDto> Persons { get; init; }
    }
}