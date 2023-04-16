using api.Application.AuthorOperations.Commdans.UpdateAuthor;
using api.DBOperations;
using AutoMapper;
using FluentAssertions;
using TestSetup;

namespace Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        private UpdateAuthorQuery query;
        private UpdateAuthorQueryValidator validator;
        public UpdateAuthorQueryValidatorTests(CommonTestFixture fixture)
        {
            this.query = new UpdateAuthorQuery(fixture.Context, fixture.Mapper);
            this.validator = new UpdateAuthorQueryValidator();
        }

        [Theory]
        [InlineData(0,"","")]
        [InlineData(0,"as","ds")]
        [InlineData(1,"","")]
        [InlineData(0,"AHMET","")]
        [InlineData(0,"","HAYRAT")]
        [InlineData(1,"AHMET","")]
        [InlineData(1,"","HAYRAT")]
        [InlineData(0,"AHMET","HAYRAT")]
        public void WhenInvalidInputGiven_Validator_ShouldBeReturn(int id, string name, string surname)
        {
            query.AuthorId = id;
            query.Model = new UpdateAuthorQueryModel(){
                Name = name,
                Surname = surname,
                DateOfBirthDay = DateTime.Now.AddYears(-10)
            };
            validator.Validate(query).Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenCorrectInputAreGiven_Validator_ShouldBeReturnTrue()
        {
            query.AuthorId = 3;
            query.Model = new UpdateAuthorQueryModel(){
                Name = "ELISSA",
                Surname = "JOHNSON",
                DateOfBirthDay = DateTime.Now.AddYears(-12)
            };
            validator.Validate(query).IsValid.Should().Be(true);
        }
    } 
}