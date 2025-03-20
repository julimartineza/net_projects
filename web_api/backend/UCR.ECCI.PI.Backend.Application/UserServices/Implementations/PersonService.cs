using UCR.ECCI.PI.Backend.Domain.Users.Entities;
using UCR.ECCI.PI.Backend.Domain.Users.Repositories;
using UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;
using Microsoft.VisualBasic;
using UCR.ECCI.PI.Backend.Domain.Buildings.Entities;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using System.Net;

namespace UCR.ECCI.PI.Backend.Application.UserServices.Implementations;

internal class PersonService : IPersonService
{
    private readonly IPersonRepository _personEntityRepository;

    public PersonService(IPersonRepository personEntityRepository)
    {
        _personEntityRepository = personEntityRepository;

    }

    /// <summary>
    /// Retrieves a person's attributes by its email.Matches similar @param email emails in the database.
    /// </summary>
    /// <param email="email">The email of the user to search.</param>
    /// <returns>the person with the specified email.</returns>
    public async Task<GetPersonResult> GetPersonAsync(string id)
    {
        Guid varTemp = new Guid(id);
        var person = await _personEntityRepository.GetPersonAsync(varTemp);
        if (person == null) throw new KeyNotFoundException("Person not found.");
        return new GetPersonResult(person.PersonId.Value, person.FullName.Value, person.Nickname.Value, person.Username.Value, person.Email.Value);
    }

    public async Task<IEnumerable<ListPersonsResult>> ListPersonsAsync()
    {
        var personList = new List<ListPersonsResult>();
        var persons = await _personEntityRepository.ListPersonsAsync();

        foreach (var person in persons)
        {
            personList.Add(new ListPersonsResult(
                person.PersonId.Value,
                person.FullName.Value,
                person.Nickname.Value,
                person.Username.Value,
                person.Email.Value
            ));
        }

        return personList.AsEnumerable();
    }

    /// <summary>
    /// Sets a person.
    /// </summary>
    /// <param Person="person">The person to set.</param>
    public async Task<int> SetPersonAsync(SetPersonParams newPerson)
    {
        // Initialize a list to store all validation errors that may occur during the process
        var errors = new List<string>();

        try
        {

            T CreateWithErrors<T>(Func<T> createFunc, string propertyName)
            {
                try
                {
                    return createFunc();
                }
                catch (Exception ex)
                {
                    errors.Add($"{propertyName} error: {ex.Message}");
                    return default;
                }
            }


            var person = new Person(
                CreateWithErrors(() => FullName.Create(newPerson.FullName), nameof(newPerson.FullName)),
                CreateWithErrors(() => Nickname.Create(newPerson.Nickname), nameof(newPerson.Nickname)),
                CreateWithErrors(() => Username.Create(newPerson.Username), nameof(newPerson.Username)),
                CreateWithErrors(() => Email.Create(newPerson.Email), nameof(newPerson.Email)),
                CreateWithErrors(() => PersonId.Create(newPerson.Id), nameof(newPerson.Id))
            );

            return await _personEntityRepository.SetPersonAsync(person);
        }
        catch (Exception ex)
        {
            // Handle exceptions, combining multiple errors if they exist
            string combinedErrors;
            if (ex is AggregateException aggregateEx)
            {
                combinedErrors = string.Join(Environment.NewLine, aggregateEx.InnerExceptions.Select(e => e.Message));
            }
            else
            {
                combinedErrors = ex.Message;
                if (ex.InnerException != null)
                {
                    combinedErrors += $" | Inner Exception: {ex.InnerException.Message}";
                }
            }

            var except = new Exception(combinedErrors)
            {
                HResult = ex.HResult
            };

            throw except;
        }
    }
}