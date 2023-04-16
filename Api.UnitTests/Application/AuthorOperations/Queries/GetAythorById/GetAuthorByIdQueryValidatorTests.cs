using api.Application.AuthorOperations.Queries.GetAuthorById;
using FluentAssertions;
using TestSetup;

namespace Application.AuthorOperations.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryValidatorTests : IClassFixture<CommonTestFixture>
    {
        private GetAuthorByIdQuery query;
        private GetAuthorByIdQueryValidator validator;
        public GetAuthorByIdQueryValidatorTests(CommonTestFixture fixture)
        {
            this.query = new GetAuthorByIdQuery(fixture.Context, fixture.Mapper);
            this.validator = new GetAuthorByIdQueryValidator();
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