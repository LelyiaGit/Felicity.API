namespace Felicity.Domain.Tests.Person.Validators
{
    using Felicity.Domain.Person.Models;
    using Felicity.Domain.Person.Validators;
    using FluentValidation.Results;
    using Xunit;

    public class PersonPutModelValidatorTests
    {
        [Fact]
        public void Validator_Fails_When_Name_Is_Empty()
        {
            var model = new PersonPutModel { CitizenNumber = 123, Name = string.Empty };
            var validator = new PersonPutModelValidator();

            ValidationResult result = validator.Validate(model);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == nameof(PersonPutModel.Name));
        }

        [Fact]
        public void Validator_Fails_When_Name_Too_Long()
        {
            var longName = new string('a', 101);
            var model = new PersonPutModel { CitizenNumber = 1, Name = longName };
            var validator = new PersonPutModelValidator();

            var result = validator.Validate(model);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == nameof(PersonPutModel.Name));
        }

        [Fact]
        public void Validator_Succeeds_For_Valid_Model()
        {
            var model = new PersonPutModel { CitizenNumber = 42, Name = "Valid Name" };
            var validator = new PersonPutModelValidator();

            var result = validator.Validate(model);

            Assert.True(result.IsValid);
        }
    }
}