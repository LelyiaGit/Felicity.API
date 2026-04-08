namespace Felicity.Domain.Tests.Person.Validators;

using Felicity.Domain.Person.Models;
using Felicity.Domain.Person.Validators;
using Felicity.Repository.Person.Entities;
using Felicity.Repository.Person.Repositories.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public class PersonPostModelValidatorTests
{
    [Fact]
    public async Task Validator_Fails_When_Id_Is_Empty()
    {
        var repo = new FakeRepo { GetPersonFunc = (id, ct) => Task.FromResult<PersonEntity?>(null) };
        var validator = new PersonPostModelValidator(repo);

        var model = new PersonPostModel { Id = Guid.Empty, Name = "Name" };

        var result = await validator.ValidateAsync(model);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(PersonPostModel.Id));
    }

    [Fact]
    public async Task Validator_Fails_When_Id_Not_Unique()
    {
        var existing = new Felicity.Repository.Person.Entities.PersonEntity { Id = Guid.NewGuid(), Name = "x" };
        var repo = new FakeRepo { GetPersonFunc = (id, ct) => Task.FromResult<PersonEntity?>(existing) };
        var validator = new PersonPostModelValidator(repo);

        var model = new PersonPostModel { Id = existing.Id, Name = "Name" };

        var result = await validator.ValidateAsync(model);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(PersonPostModel.Id));
    }

    [Fact]
    public async Task Validator_Fails_When_Name_Empty()
    {
        var repo = new FakeRepo { GetPersonFunc = (id, ct) => Task.FromResult<PersonEntity?>(null) };
        var validator = new PersonPostModelValidator(repo);

        var model = new PersonPostModel { Id = Guid.NewGuid(), Name = string.Empty };

        var result = await validator.ValidateAsync(model);

        Assert.False(result.IsValid);
        Assert.Contains(result.Errors, e => e.PropertyName == nameof(PersonPostModel.Name));
    }

    [Fact]
    public async Task Validator_Succeeds_For_Valid_Model()
    {
        var repo = new FakeRepo { GetPersonFunc = (id, ct) => Task.FromResult<PersonEntity?>(null) };
        var validator = new PersonPostModelValidator(repo);

        var model = new PersonPostModel { Id = Guid.NewGuid(), Name = "Valid" };

        var result = await validator.ValidateAsync(model);

        Assert.True(result.IsValid);
    }

    private class FakeRepo : IPersonRepository
    {
        public Func<Guid, CancellationToken, Task<PersonEntity?>>? GetPersonFunc { get; set; }

        public Task<IEnumerable<Felicity.Repository.Person.Entities.PersonEntity>> GetPersons(CancellationToken ct)
            => Task.FromResult<IEnumerable<Felicity.Repository.Person.Entities.PersonEntity>>(Array.Empty<Felicity.Repository.Person.Entities.PersonEntity>());

        public Task<Felicity.Repository.Person.Entities.PersonEntity?> GetPerson(Guid id, CancellationToken ct)
            => this.GetPersonFunc is not null ? this.GetPersonFunc(id, ct) : Task.FromResult<Felicity.Repository.Person.Entities.PersonEntity?>(null);

        public Task<Felicity.Repository.Person.Entities.PersonEntity?> PostPerson(Felicity.Repository.Person.Entities.PersonEntity person, CancellationToken ct)
            => Task.FromResult<Felicity.Repository.Person.Entities.PersonEntity?>(person);

        public Task<Felicity.Repository.Person.Entities.PersonEntity?> PutPerson(Felicity.Repository.Person.Entities.PersonEntity person, CancellationToken ct)
            => Task.FromResult<Felicity.Repository.Person.Entities.PersonEntity?>(person);

        public Task DeletePerson(Guid id, CancellationToken ct)
            => Task.CompletedTask;
    }
}
