using Felicity.Domain.Person.Models;
using Repo = Felicity.Repository.Person.Entities;

namespace Felicity.Domain.Person.Mappers;

internal static class PersonMapper
{
    public static PersonModel ToModel(Repo.PersonEntity entity)
    {
        if (entity == null) return null!;

        return new PersonModel
        {
            Id = entity.Id,
            CitizenNumber = entity.CitizenNumber,
            Name = entity.Name
        };
    }

    public static IEnumerable<PersonModel> ToModels(IEnumerable<Repo.PersonEntity> entities)
        => entities?.Select(ToModel) ?? Enumerable.Empty<PersonModel>();

    public static Repo.PersonEntity ToEntity(PersonPostModel postModel)
    {
        return new Repo.PersonEntity
        {
            Id = postModel.Id,
            CitizenNumber = postModel.CitizenNumber,
            Name = postModel.Name
        };
    }
    public static Repo.PersonEntity ToEntity(PersonPutModel putModel, Guid id)
    {
        return new Repo.PersonEntity
        {
            Id = id,
            CitizenNumber = putModel.CitizenNumber,
            Name = putModel.Name
        };
    }
}
