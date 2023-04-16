
using api.Application.AuthorOperations.Commdans.CreateAuthor;
using api.DBOperations;
using AutoMapper;
using FluentAssertions;
using TestSetup;

namespace Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        private CreateAuthorQueryValidator validator;      
        public CreateAuthorQueryValidatorTests(){
            this.validator = new CreateAuthorQueryValidator();
        }

        [Fact]
        public void WhenInvalidInputValue_Validator_ShouldBeReturnErrors()
        {
            validator.Validate(new CreateAuthorQueryModel(){
                Name = "",
                Surname = "",
                DateOfBirthDay = DateTime.Now.AddYears(-10)
            }).Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenCorrectInputAreGiven_Validator_ShouldBeReturnTrue()
        {
            validator.Validate(new CreateAuthorQueryModel(){
                Name = "JOHN",
                Surname = "ARTHUR",
                DateOfBirthDay = DateTime.Now.AddYears(-10)
            }).IsValid.Should().Be(true);
        }
    }
}