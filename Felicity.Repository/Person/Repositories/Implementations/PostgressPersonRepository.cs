using Felicity.Repository.Person.Entities;
using Felicity.Repository.Person.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Felicity.Repository.Person.Repositories.Implementations;

internal class PostgressPersonRepository : IPersonRepository
{
    private readonly FelicityContext _db;

    public PostgressPersonRepository(FelicityContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<PersonEntity>> GetPersons()
    {
        return await _db.Persons
            .Include(p => p.Employments)
            .ToListAsync();
    }

    public async Task<PersonEntity?> GetPerson(Guid id)
    {
        return await _db.Persons
            .Include(p => p.Employments)
            .SingleOrDefaultAsync(p => p.Id == id);
    }
}
