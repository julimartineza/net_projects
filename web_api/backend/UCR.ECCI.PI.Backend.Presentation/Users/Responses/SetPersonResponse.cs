using UCR.ECCI.PI.Backend.Presentation.Users.Dtos;

namespace UCR.ECCI.PI.Backend.Presentation.Users.Responses
{
    /// <summary>
    /// Record representing the response after creating or updating a person
    /// </summary>
    internal record SetPersonResponse
    {
        /// <summary>
        /// The created or updated person's ID
        /// </summary>
        public Guid PersonId { get; init; }

        /// <summary>
        /// The person's data as a DTO
        /// </summary>
        public PersonDto Person { get; init; }
    }
}