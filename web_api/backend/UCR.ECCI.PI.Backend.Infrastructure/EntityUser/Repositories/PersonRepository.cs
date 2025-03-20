using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCR.ECCI.PI.Backend.Domain.Buildings.ValueObjects;
using UCR.ECCI.PI.Backend.Domain.Users.Entities;
using UCR.ECCI.PI.Backend.Domain.Users.Repositories;
using UCR.ECCI.PI.Backend.Domain.Users.ValueObjects;

namespace UCR.ECCI.PI.Backend.Infrastructure.EntityUser.Repositories;

internal class PersonRepository : IPersonRepository
{
    private readonly DatabaseContext _databaseContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="PersonRepository"/> class with the provided database context.
    /// </summary>
    /// <param name="databaseContext">The database context used for accessing the database.</param>
    public PersonRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    /// <summary>
    /// Retrieves a person by their id.
    /// </summary>
    /// <param name="email">The email of the person to retrieve.</param>
    /// <returns>A person entity, or null if not found.</returns>
    //public async Task<Person?> GetPersonAsync(string email)
    //{
    //    return await _databaseContext.Person
    //        .FirstOrDefaultAsync(p => p.Email.Value == email);
    //}

    public Task<Person?> GetPersonAsync(Guid id)
    {
        return Task.FromResult(_databaseContext.Person
        .AsEnumerable()
        .FirstOrDefault(u => u.PersonId.GetValue() == id));
        //return await _databaseContext.Person.FindAsync(PersonId.Create(id));
    }

    /// <summary>
    /// Lists all persons in the database.
    /// </summary>
    /// <returns>An enumerable collection of persons.</returns>
    public async Task<IEnumerable<Person>> ListPersonsAsync()
    {
        return await _databaseContext.Person.ToListAsync();
    }

    /// <summary>
    /// Adds a new person to the database.
    /// </summary>
    /// <param name="person">The person entity to add.</param>
    /// <returns>0 if successful.</returns>
    public async Task<int> SetPersonAsync(Person person)
    {
        _databaseContext.Person.Add(person);
        await _databaseContext.SaveChangesAsync();
        return 0;
    }
}
