using CsvHelper.Configuration;
using Felicity.Repository.Person.Entities;

namespace Felicity.Repository.Person.Mappers;

internal sealed class PersonEntityMap : ClassMap<PersonEntity>
{
    public PersonEntityMap()
    {
        Map(p => p.Id);
        Map(Map => Map.CitizenNumber);
        Map(p => p.FirstName);
        Map(p => p.LastName);
    }
}