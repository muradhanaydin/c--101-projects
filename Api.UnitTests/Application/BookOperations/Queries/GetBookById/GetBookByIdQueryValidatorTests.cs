using api.Application.BookOperations.Queries.GetBookById;
using FluentAssertions;
using TestSetup;

namespace Application.BookOperations.Queries.GetBookById
{
    public class GetBookByIdQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        private GetBookByIdQuery query;
        private GetBookByIdQueryValidator validator;
        public GetBookByIdQueryValidatorTests(CommonTestFixture fixture)
        {
            this.query = new GetBookByIdQuery(fixture.Context, fixture.Mapper);
            this.validator = new GetBookByIdQueryValidator();
        }

        [Fact]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors()
        {
            query.BookId = 0;            
            validator.Validate(query).Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenAlreayExistInputAreGiven_Validator_ShouldBeReturnTrue()
        {
            query.BookId = 15;
            validator.Validate(query).IsValid.Should().Be(true);
        }
    }
}