using UCR.ECCI.PI.Backend.Presentation.Users.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Users.Responses
{
    /// <summary>
    /// Record representing the response when retrieving a person
    /// </summary>
    internal record GetPersonResponse
    {
        /// <summary>
        /// The person's data as a DTO
        /// </summary>
        public PersonDto Person { get; init; }
    }
}