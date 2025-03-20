using UCR.ECCI.PI.Backend.Application.UserServices;
using UCR.ECCI.PI.Backend.Domain.Users.Entities;

namespace UCR.ECCI.PI.Backend.Application.UserServices;

public interface IPersonService
{
    /// <summary>
    /// Get a specific person by Id.
    /// </summary>
    /// <param name="id">The person's Id.</param>
    public Task<GetPersonResult> GetPersonAsync(string id);

    /// <summary>
    /// List all persons in the system.
    /// </summary>
    public Task<IEnumerable<ListPersonsResult>> ListPersonsAsync();

    /// <summary>
    /// Set a person in the system.
    /// </summary>
    /// <param name="newPerson">The person to set.</param>
    public Task<int> SetPersonAsync(SetPersonParams newPerson);

}
