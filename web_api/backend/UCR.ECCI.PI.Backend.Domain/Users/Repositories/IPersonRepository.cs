using UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Users.Entities;

namespace UCR.ECCI.PI.Backend.Domain.Users.Repositories;

public interface IPersonRepository
{
    /// <summary>
    /// Retrieves a person's attributes by its email.Matches similar @param email emails in the database.
    /// </summary>
    /// <param email="email">The email of the user to search.</param>
    /// <returns>the person with the specified email.</returns>
    public Task<Person?> GetPersonAsync(Guid id);

    public Task<IEnumerable<Person>> ListPersonsAsync();

    /// <summary>
    /// Sets a person.
    /// </summary>
    /// <param Person="person">The person to set.</param>
    public Task<int> SetPersonAsync(Person person);

    /// <summary>
    /// Edits a person's information
    /// </summary>
    /// <param Person="person"></param>
    /// <returns>  0 when edited succesfully </returns>
    //public Task<int> EditPersonAsync(Person person);
}
