using Microsoft.EntityFrameworkCore;
using Felicity.Repository.Person.Entities;
using Felicity.Repository.Person.Repositories.Interfaces;
using Felicity.Repository.Data;

namespace Felicity.Repository.Person.Repositories.Implementations;

internal class PostgresPersonRepository : IPersonRepository
{
    private readonly FelicityDbContext _db;

    public PostgresPersonRepository(FelicityDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<PersonEntity>> GetPersons()
    {
        return await _db.Persons.Include(p => p.Employments).ToListAsync();
    }

    public async Task<PersonEntity?> GetPerson(Guid id)
    {
        return await _db.Persons.Include(p => p.Employments).FirstOrDefaultAsync(p => p.Id == id);
    }
}
