namespace Felicity.Api.Tests.Person.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Felicity.Api.Person.Controllers;
    using Felicity.Domain.Person.Models;
    using Felicity.Domain.Person.Services.Interfaces;
    using Felicity.Domain.Infrastructure.Classes;
    using Xunit;

    public class PersonControllerTests
    {
        #region GetPersons

        [Fact]
        public async Task GetPersons_ReturnsListFromService()
        {
            var expected = new[]
            {
                new PersonModel { Id = Guid.NewGuid(), Name = "A" },
                new PersonModel { Id = Guid.NewGuid(), Name = "B" }
            };

            var service = new FakePersonService { GetPersonsFunc = () => Task.FromResult<IEnumerable<PersonModel>>(expected) };
            var controller = new PersonController(service);

            var result = await controller.GetPersons();

            Assert.Equal(expected, result);
        }

        #endregion

        #region GetPerson

        [Fact]
        public async Task GetPerson_InvalidGuid_ReturnsBadRequest()
        {
            var service = new FakePersonService();
            var controller = new PersonController(service);

            var result = await controller.GetPerson("not-a-guid");

            var bad = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid GUID format", bad.Value);
        }

        [Fact]
        public async Task GetPerson_NotFound_ReturnsNotFound()
        {
            var service = new FakePersonService { GetPersonFunc = id => Task.FromResult<PersonModel?>(null) };
            var controller = new PersonController(service);

            var result = await controller.GetPerson(Guid.NewGuid().ToString());

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetPerson_Found_ReturnsOk()
        {
            var person = new PersonModel { Id = Guid.NewGuid(), Name = "Found" };
            var service = new FakePersonService { GetPersonFunc = id => Task.FromResult<PersonModel?>(person) };
            var controller = new PersonController(service);

            var result = await controller.GetPerson(person.Id.ToString());

            var ok = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(person, ok.Value);
        }

        #endregion

        #region PostPerson

        [Fact]
        public async Task PostPerson_NullModel_ReturnsBadRequest()
        {
            var service = new FakePersonService();
            var controller = new PersonController(service);

            var result = await controller.PostPerson(null!);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task PostPerson_ServiceCreates_ReturnsCreated()
        {
            var created = new PersonModel { Id = Guid.NewGuid(), Name = "Created" };
            var service = new FakePersonService { PostPersonFunc = m => Task.FromResult<PersonModel?>(created) };
            var controller = new PersonController(service);

            var postModel = new PersonPostModel { Id = Guid.NewGuid(), Name = "Posted" };

            var result = await controller.PostPerson(postModel);

            var createdAt = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(PersonController.GetPerson), createdAt.ActionName);
            Assert.Equal(created, createdAt.Value);
            Assert.Equal(created.Id.ToString(), createdAt.RouteValues!["id"]);
        }

        #endregion

        #region PutPerson

        [Fact]
        public async Task PutPerson_InvalidGuid_ReturnsBadRequest()
        {
            var service = new FakePersonService();
            var controller = new PersonController(service);

            var result = await controller.PutPerson("bad-guid", new PersonPutModel { Name = "x", CitizenNumber = 1 });

            var bad = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid GUID format", bad.Value);
        }

        [Fact]
        public async Task PutPerson_NullModel_ReturnsBadRequest()
        {
            var service = new FakePersonService();
            var controller = new PersonController(service);

            var result = await controller.PutPerson(Guid.NewGuid().ToString(), null!);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task PutPerson_ServiceReturnsModel_ReturnsOk()
        {
            var id = Guid.NewGuid();
            var returned = new PersonModel { Id = id, Name = "Updated" };
            var service = new FakePersonService { PutPersonFunc = (g, m) => Task.FromResult<PersonModel?>(returned) };
            var controller = new PersonController(service);

            var result = await controller.PutPerson(id.ToString(), new PersonPutModel { Name = "n", CitizenNumber = 2 });

            var ok = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(returned, ok.Value);
        }

        #endregion

        #region DeletePerson

        [Fact]
        public async Task DeletePerson_InvalidGuid_ReturnsBadRequest()
        {
            var service = new FakePersonService();
            var controller = new PersonController(service);

            var result = await controller.DeletePerson("bad");

            var bad = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid GUID format", bad.Value);
        }

        [Fact]
        public async Task DeletePerson_ServiceReturnsNull_ReturnsBadRequest()
        {
            var service = new FakePersonService { DeletePersonFunc = id => Task.FromResult<OperationResult<NoResult>?>(null) };
            var controller = new PersonController(service);

            var result = await controller.DeletePerson(Guid.NewGuid().ToString());

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeletePerson_ServiceReturnsResult_ReturnsOk()
        {
            var op = new OperationResult<NoResult> { ResultObject = null };
            var service = new FakePersonService { DeletePersonFunc = id => Task.FromResult<OperationResult<NoResult>?>(op) };
            var controller = new PersonController(service);

            var result = await controller.DeletePerson(Guid.NewGuid().ToString());

            var ok = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(op, ok.Value);
        }

        #endregion

        private class FakePersonService : IPersonService
        {
            public Func<Task<IEnumerable<PersonModel>>>? GetPersonsFunc { get; set; }
            public Func<Guid, Task<PersonModel?>>? GetPersonFunc { get; set; }
            public Func<PersonPostModel, Task<PersonModel?>>? PostPersonFunc { get; set; }
            public Func<Guid, PersonPutModel, Task<PersonModel?>>? PutPersonFunc { get; set; }
            public Func<Guid, Task<OperationResult<NoResult>?>>? DeletePersonFunc { get; set; }

            public Task<IEnumerable<PersonModel>> GetPersons()
                => this.GetPersonsFunc is not null ? this.GetPersonsFunc() : Task.FromResult<IEnumerable<PersonModel>>(Array.Empty<PersonModel>());

            public Task<PersonModel?> GetPerson(Guid id)
                => this.GetPersonFunc is not null ? this.GetPersonFunc(id) : Task.FromResult<PersonModel?>(null);

            public Task<PersonModel?> PostPerson(PersonPostModel postModel)
                => this.PostPersonFunc is not null ? this.PostPersonFunc(postModel) : Task.FromResult<PersonModel?>(null);

            public Task<PersonModel?> PutPerson(Guid id, PersonPutModel putModel)
                => this.PutPersonFunc is not null ? this.PutPersonFunc(id, putModel) : Task.FromResult<PersonModel?>(null);

            public Task<OperationResult<NoResult>?> DeletePerson(Guid id)
                => this.DeletePersonFunc is not null ? this.DeletePersonFunc(id) : Task.FromResult<OperationResult<NoResult>?>(null);
        }
    }
}