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

    public async Task<IEnumerable<PersonEntity>> GetPersons(CancellationToken ct)
    {
        return await _db.Persons
            .AsNoTracking()
            .Include(p => p.Employments)
            .ToListAsync(ct);
    }

    public async Task<PersonEntity?> GetPerson(Guid id, CancellationToken ct)
    {
        return await _db.Persons
          .AsNoTracking()
          .Include(p => p.Employments)
          .FirstOrDefaultAsync(p => p.Id == id, ct);
    }

    public async Task<PersonEntity?> PostPerson(PersonEntity person, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(person);

        _db.Persons.Add(person);
        await _db.SaveChangesAsync(ct);

        return person;
    }

    public async Task<PersonEntity?> PutPerson(PersonEntity person, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(person);

        var existing = await _db.Persons
            .FirstOrDefaultAsync(p => p.Id == person.Id, ct);

        if (existing == null)
            return null;

        existing.Name = person.Name;
        existing.CitizenNumber = person.CitizenNumber;

        await _db.SaveChangesAsync(ct);

        return existing;
    }
}
