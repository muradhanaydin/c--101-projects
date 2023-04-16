using api.Application.BookOperations.Commands.DeleteBook;
using api.DBOperations;
using FluentAssertions;
using TestSetup;

namespace Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        private DeleteBookQuery query;
        private DeleteBookQueryValidator validator;
        public DeleteBookQueryValidatorTests(CommonTestFixture fixture)
        {
            this.query = new DeleteBookQuery(fixture.Context);
            this.validator = new DeleteBookQueryValidator();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeErrors(int id)
        {
            query.BookId = id;            
            validator.Validate(query).Errors.Count.Should().BeGreaterThan(0);
        }
        
        [Fact]
        public void WhenCorrectInputAreGiven_Validator_ShouldBwReturnTrue()
        {
            query.BookId = 1;
            validator.Validate(query).IsValid.Should().Be(true);
        }
    }
}