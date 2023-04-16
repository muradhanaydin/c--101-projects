using api.Application.AuthorOperations.Commdans.DeleteAuthor;
using api.DBOperations;
using FluentAssertions;
using TestSetup;

namespace Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        private DeleteAuthorQuery query;
        private DeleteAuthorQueryValidator validator;
        public DeleteAuthorQueryValidatorTests(CommonTestFixture fixture){
            this.query = new DeleteAuthorQuery(fixture.Context);
            this.validator = new DeleteAuthorQueryValidator();
        }

        [Fact]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors()
        {
            query.AuthorId = 0;
            validator.Validate(query).Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenCorrectInputAreGiven_Validator_ShouldBeReturnTrue()
        {
            query.AuthorId = 1;
            validator.Validate(query).IsValid.Should().Be(true);
        }
    }
}